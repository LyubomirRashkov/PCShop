using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Models.Laptop;
using PCShop.Core.Services.Interfaces;
using PCShop.Extensions;
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

		/// <summary>
		/// Constructor of LaptopController class
		/// </summary>
		/// <param name="laptopService">The ILaptopService needed for functionality</param>
		/// <param name="clientService">The IClientService needed for functionality</param>
		public LaptopController(
			ILaptopService laptopService,
			IClientService clientService)
		{
			this.laptopService = laptopService;
			this.clientService = clientService;
		}

		/// <summary>
		/// HttpGet action to retrieve all active laptops
		/// </summary>
		/// <returns>Collection of all active laptops</returns>
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var laptops = await this.laptopService.GetAllLaptopsAsync();

			return View(laptops);
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
			catch (Exception)
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
			catch (Exception)
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
				catch (Exception)
				{
					return Unauthorized();
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
			catch (Exception)
			{
				this.ModelState.AddModelError("", "Something went wrong... :)");

				return View(model);
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
			catch (Exception)
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
			catch (Exception)
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
		public async Task<IActionResult> MyLaptops()
		{
			var userId = this.User.Id();

			try
			{
				var userLaptops = await this.laptopService.GetUserLaptopsAsync(userId);

				return View(userLaptops);
			}
			catch (Exception)
			{
				return NotFound();
			}
		}
	}
}
