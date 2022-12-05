using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Laptop;
using PCShop.Core.Services.Interfaces;
using PCShop.Extensions;
using PCShop.Infrastructure.Data.Models.Account;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Infrastructure.Constants.DataConstant.RoleConstants;

namespace PCShop.Controllers
{
	/// <summary>
	/// Laptop controller class
	/// </summary>
	[Authorize]
	public class LaptopController : Controller
	{
		private readonly ILaptopService laptopService;
		private readonly IClientService clientService;
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;

		/// <summary>
		/// Constructor of LaptopController class
		/// </summary>
		/// <param name="laptopService">The ILaptopService needed for functionality</param>
		/// <param name="clientService">The IClientService needed for functionality</param>
		/// <param name="userManager">The UserManager<c>User</c></param>
		/// <param name="signInManager">The SignInManager<c>User</c></param>
		public LaptopController(
			ILaptopService laptopService,
			IClientService clientService,
			UserManager<User> userManager,
			SignInManager<User> signInManager)
		{
			this.laptopService = laptopService;
			this.clientService = clientService;
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		/// <summary>
		/// HttpGet action to retrieve all active laptops according to specified criteria
		/// </summary>
		/// <param name="query">The entity that holds the specified criteria</param>
		/// <returns>Collection of all active laptops according to specified criteria</returns>
		[HttpGet]
		public async Task<IActionResult> Index([FromQuery] AllLaptopsQueryModel query)
		{
			var result = await this.laptopService.GetAllLaptopsAsync(
				query.Cpu,
				query.Ram,
				query.SsdCapacity,
				query.VideoCard,
				query.Keyword,
				query.Sorting,
				query.CurrentPage);

			query.TotalLaptopsCount = result.TotalLaptopsCount;

			query.Cpus = await this.laptopService.GetAllCpusNames();
			query.Rams = await this.laptopService.GetAllRamsValues();
			query.SsdCapacities = await this.laptopService.GetAllSsdCapacitiesValues();
			query.VideoCards = await this.laptopService.GetAllVideoCardsNames();

			query.Laptops = result.Laptops;

			return View(query);
		}

		/// <summary>
		/// HttpGet action to retrieve detailed information about a specific laptop
		/// </summary>
		/// <param name="id">Laptop unique identifier</param>
		/// <returns>Detailed information about the laptop</returns>
		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			try
			{
				var laptop = await this.laptopService.GetLaptopByIdAsLaptopDetailsExportViewModelAsync(id);

				return View(laptop);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Action to mark a specific laptop as deleted
		/// </summary>
		/// <param name="id">Laptop unique identifier</param>
		/// <returns>Redirection to /Laptop/Index</returns>
		[HttpGet]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var laptop = await this.laptopService.GetLaptopByIdAsLaptopDetailsExportViewModelAsync(id);

				if (this.User.IsInRole(SuperUser)
					&& (laptop.Seller is null || this.User.Id() != laptop.Seller.UserId))
				{
					return Unauthorized();
				}

				await this.laptopService.DeleteLaptopAsync(id);

				return RedirectToAction(nameof(Index));
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// HttpGet action to return the form for adding a laptop
		/// </summary>
		/// <returns>The form for adding a laptop</returns>
		[HttpGet]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Add()
		{
			if (this.User.IsInRole(SuperUser))
			{
				var userId = this.User.Id();

				try
				{
					var numberOfActiveSales = await this.clientService.GetNumberOfActiveSales(userId);

					if (numberOfActiveSales == MaxNumberOfAllowedSales)
					{
						ViewData["Title"] = "Add a laptop";

						return View("AddNotAllowed");
					}
				}
				catch (PCShopException)
				{
					return View("Error");
				}
			}

			return View();
		}

		/// <summary>
		/// HttpPost action to add a laptop
		/// </summary>
		/// <param name="model">Laptop import model</param>
		/// <returns>Redirection to /Laptop/Details</returns>
		[HttpPost]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Add(LaptopImportViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return View(model);
			}

			string? userId = null;

			if (this.User.IsInRole(SuperUser))
			{
				userId = this.User.Id();
			}

			try
			{
				int id = await this.laptopService.AddLaptopAsync(model, userId);

				return RedirectToAction(nameof(Details), new { id });
			}
			catch (PCShopException)
			{
				return View("Error");
			}
		}

		/// <summary>
		/// HttpGet action to return the form for editing a laptop
		/// </summary>
		/// <param name="id">Laptop unique identifier</param>
		/// <returns>The form for editing a laptop</returns>
		[HttpGet]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				var laptop = await this.laptopService.GetLaptopByIdAsLaptopEditViewModelAsync(id);

				if (this.User.IsInRole(SuperUser)
					&& (laptop.Seller is null || this.User.Id() != laptop.Seller.UserId))
				{
					return Unauthorized();
				}

				return View(laptop);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// HttpPost action to edit a laptop
		/// </summary>
		/// <param name="model">Laptop import model</param>
		/// <returns>Redirection to /Laptop/Details</returns>
		[HttpPost]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Edit(LaptopEditViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return View();
			}

			try
			{
				var laptop = await this.laptopService.GetLaptopByIdAsLaptopEditViewModelAsync(model.Id);

				if (this.User.IsInRole(SuperUser)
					&& (laptop.Seller is null || this.User.Id() != laptop.Seller.UserId))
				{
					return Unauthorized();
				}

				int id = await this.laptopService.EditLaptopAsync(model);

				return RedirectToAction(nameof(Details), new { id });
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// HttpGet action to retrieve all active laptop sales of the currently logged in user
		/// </summary>
		/// <returns>Collection of all active laptop sales of the currently logged in user</returns>
		[HttpGet]
		[Authorize(Roles = SuperUser)]
		public async Task<IActionResult> Mine()
		{
			var userId = this.User.Id();

			try
			{
				var userLaptops = await this.laptopService.GetUserLaptopsAsync(userId);

				return View(userLaptops);
			}
			catch (PCShopException)
			{
				return View("Error");
			}
		}

		/// <summary>
		/// HttpGet action to buy a laptop
		/// </summary>
		/// <param name="id">Laptop unique identifier</param>
		/// <returns>The corresponding view</returns>
		[HttpGet]
		public async Task<IActionResult> Buy(int id)
		{
			if (this.User.IsInRole(Administrator))
			{
				return Unauthorized();
			}

			try
			{
				var userId = this.User.Id();

				if (this.User.IsInRole(SuperUser))
				{
					var laptopSeller = (await this.laptopService.GetLaptopByIdAsLaptopEditViewModelAsync(id)).Seller;

					if (laptopSeller is not null && laptopSeller.UserId == userId)
					{
						return Unauthorized();
					}
				}

				ViewData["Title"] = "Buy a laptop";

				await this.laptopService.MarkLaptopAsBought(id);

				var client = await this.clientService.BuyProduct(userId);

				if (client.CountOfPurchases == RequiredNumberOfPurchasesToBeSuperUser)
				{
					var user = await this.userManager.FindByIdAsync(userId);

					await this.userManager.AddToRoleAsync(user, SuperUser);

					await this.signInManager.SignOutAsync();

					await this.signInManager.SignInAsync(user, false);

					return View("PromoteToSuperUser");
				}

				return View("PurchaseMade");
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}
	}
}
