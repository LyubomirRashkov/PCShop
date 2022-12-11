using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Laptop;
using PCShop.Core.Services.Interfaces;
using PCShop.Extensions;
using System.Security.Claims;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Core.Constants.Constant.GlobalConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;
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
		private readonly IUserService userService;

		/// <summary>
		/// Constructor of LaptopController class
		/// </summary>
		/// <param name="laptopService">The ILaptopService needed for functionality</param>
		/// <param name="clientService">The IClientService needed for functionality</param>
		/// <param name="userService">The IUserService needed for functionality</param>
		public LaptopController(
			ILaptopService laptopService,
			IClientService clientService,
			IUserService userService)
		{
			this.laptopService = laptopService;
			this.clientService = clientService;
			this.userService = userService;
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

			query.Cpus = await this.laptopService.GetAllCpusNamesAsync();
			query.Rams = await this.laptopService.GetAllRamsValuesAsync();
			query.SsdCapacities = await this.laptopService.GetAllSsdCapacitiesValuesAsync();
			query.VideoCards = await this.laptopService.GetAllVideoCardsNamesAsync();

			query.Laptops = result.Laptops;

			return View(query);
		}

        /// <summary>
        /// HttpGet action to retrieve detailed information about a specific laptop
        /// </summary>
        /// <param name="id">Laptop unique identifier</param>
        /// <param name="information">Laptop additional information</param>
        /// <returns>Detailed information about the laptop</returns>
        [HttpGet]
		public async Task<IActionResult> Details(int id, string information)
		{
			try
			{
				var laptop = await this.laptopService.GetLaptopByIdAsLaptopDetailsExportViewModelAsync(id);

				if (information.ToLower() != laptop.GetInformation().ToLower())
				{
					return NotFound();
				}

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

				TempData[TempDataMessage] = ProductSuccessfullyDeleted;

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

						return View(AddNotAllowedViewName);
					}
				}
				catch (PCShopException)
				{
					return View(ErrorCommonViewName);
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

				TempData[TempDataMessage] = ProductSuccessfullyAdded;

				return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
			}
			catch (PCShopException)
			{
				return View(ErrorCommonViewName);
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

				TempData[TempDataMessage] = ProductSuccessfullyEdited;

				return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
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
				return View(ErrorCommonViewName);
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

				await this.laptopService.MarkLaptopAsBoughtAsync(id);

				var client = await this.clientService.BuyProduct(userId);

				var isNowPromotedToSuperUser = await this.userService.ShouldBePromotedToSuperUser(client);

				if (isNowPromotedToSuperUser)
				{
					return View(PromoteToSuperUserViewName);
				}

				return View(PurchaseMadeViewName);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}
	}
}
