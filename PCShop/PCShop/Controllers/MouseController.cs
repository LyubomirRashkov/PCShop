using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Mouse;
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
	/// Mouse controller class
	/// </summary>
	[Authorize]
	public class MouseController : Controller
	{
		private readonly IMouseService mouseService;
		private readonly IClientService clientService;
		private readonly IUserService userService;

		/// <summary>
		/// Constructor of MouseController class
		/// </summary>
		/// <param name="mouseService">The IMouseService needed for functionality</param>
		/// <param name="clientService">The IClientService needed for functionality</param>
		/// <param name="userService">The IUserService needed for functionality</param>
		public MouseController(
			IMouseService mouseService,
			IClientService clientService,
			IUserService userService)
		{
			this.mouseService = mouseService;
			this.clientService = clientService;
			this.userService = userService;
		}

		/// <summary>
		/// HttpGet action to retrieve all active mice according to specified criteria
		/// </summary>
		/// <param name="query">The entity that holds the specified criteria</param>
		/// <returns>Collection of all active mice according to specified criteria</returns>
		[HttpGet]
		public async Task<IActionResult> Index([FromQuery] AllMiceQueryModel query)
		{
			var result = await this.mouseService.GetAllMiceAsync(
				query.Type,
				query.Sensitivity,
				query.Wireless,
				query.Keyword,
				query.Sorting,
				query.CurrentPage);

			query.TotalMiceCount = result.TotalMiceCount;

			query.Types = await this.mouseService.GetAllMiceTypesAsync();
			query.Sensitivities = await this.mouseService.GetAllMiceSensitivitiesAsync();

			query.Mice = result.Mice;

			return View(query);
		}

		/// <summary>
		/// HttpGet action to retrieve detailed information about a specific mouse
		/// </summary>
		/// <param name="id">Mouse unique identifier</param>
		/// <param name="information">Mouse additional information</param>
		/// <returns>Detailed information about the mouse</returns>
		[HttpGet]
		public async Task<IActionResult> Details(int id, string information)
		{
			try
			{
				var mouse = await this.mouseService.GetMouseByIdAsMouseDetailsExportViewModelAsync(id);

				if (information.ToLower() != mouse.GetInformation().ToLower())
				{
					return NotFound();
				}

				return View(mouse);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Action to mark a specific mouse as deleted
		/// </summary>
		/// <param name="id">Mouse unique identifier</param>
		/// <returns>Redirection to /Mouse/Index</returns>
		[HttpGet]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var mouse = await this.mouseService.GetMouseByIdAsMouseDetailsExportViewModelAsync(id);

				if (this.User.IsInRole(SuperUser)
					&& (mouse.Seller is null || this.User.Id() != mouse.Seller.UserId))
				{
					return Unauthorized();
				}

				await this.mouseService.DeleteMouseAsync(id);

				TempData[TempDataMessage] = ProductSuccessfullyDeleted;

				return RedirectToAction(nameof(Index));
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// HttpGet action to return the form for adding a mouse
		/// </summary>
		/// <returns>The form for adding a mouse</returns>
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
						ViewData["Title"] = "Add a mouse";

						return View(AddNotAllowedViewName);
					}
				}
				catch (PCShopException)
				{
					return View(ErrorCommonViewName);
				}
			}

			var model = new MouseImportViewModel
			{
				Sensitivities = await this.mouseService.GetAllMiceSensitivitiesAsync()
			};

			return View(model);
		}

		/// <summary>
		/// HttpPost action to add a mouse
		/// </summary>
		/// <param name="model">Mouse import model</param>
		/// <param name="rbIsWireless">The value of selected radio button for connectivity</param>
		/// <param name="rbSensitivity">The value of selected radio button for sensitivity range</param>
		/// <returns>Redirection to /Mouse/Details</returns>
		[HttpPost]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Add(MouseImportViewModel model, bool? rbIsWireless, string? rbSensitivity)
		{
			if (rbIsWireless is null && rbSensitivity is null)
			{
				this.ModelState.AddModelError("IsWireless", ErrorMessageForUnselectedOption);

				this.ModelState.AddModelError("Sensitivity", ErrorMessageForUnselectedOption);
			}
			else if (rbIsWireless is null)
			{
				this.ModelState.AddModelError("IsWireless", ErrorMessageForUnselectedOption);

				model.Sensitivity = rbSensitivity;
			}
			else if (rbSensitivity is null)
			{
				this.ModelState.AddModelError("Sensitivity", ErrorMessageForUnselectedOption);

				model.IsWireless = rbIsWireless;
			}
			else
			{
				model.IsWireless = rbIsWireless;

				model.Sensitivity = rbSensitivity;
			}

			if (!this.ModelState.IsValid)
			{
				model.Sensitivities = await this.mouseService.GetAllMiceSensitivitiesAsync();

				return View(model);
			}

			string? userId = null;

			if (this.User.IsInRole(SuperUser))
			{
				userId = this.User.Id();
			}

			try
			{
				int id = await this.mouseService.AddMouseAsync(model, userId);

				TempData[TempDataMessage] = ProductSuccessfullyAdded;

				return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
			}
			catch (PCShopException)
			{
				return View(ErrorCommonViewName);
			}
			catch (ArgumentException)
			{
				return View(ErrorCommonViewName);
			}
		}

        /// <summary>
        /// HttpGet action to return the form for editing a mouse
        /// </summary>
        /// <param name="id">Mouse unique identifier</param>
        /// <returns>The form for editing a mouse</returns>
        [HttpGet]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				var mouse = await this.mouseService.GetMouseByIdAsMouseEditViewModelAsync(id);

				if (this.User.IsInRole(SuperUser)
					&& (mouse.Seller is null || this.User.Id() != mouse.Seller.UserId))
				{
					return Unauthorized();
				}

				mouse.Sensitivities = await this.mouseService.GetAllMiceSensitivitiesAsync();

				return View(mouse);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

        /// <summary>
        /// HttpPost action to edit a mouse
        /// </summary>
        /// <param name="model">Mouse import model</param>
        /// <returns>Redirection to /Mouse/Details</returns>
        [HttpPost]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Edit(MouseEditViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				var mouse = await this.mouseService.GetMouseByIdAsMouseEditViewModelAsync(model.Id);

				if (this.User.IsInRole(SuperUser)
					&& (mouse.Seller is null || this.User.Id() != mouse.Seller.UserId))
				{
					return Unauthorized();
				}

				int id = await this.mouseService.EditMouseAsync(model);

                TempData[TempDataMessage] = ProductSuccessfullyEdited;

                return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
            }
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// HttpGet action to retrieve all active mouse sales of the currently logged in user
		/// </summary>
		/// <returns>Collection of all active mouse sales of the currently logged in user</returns>
		[HttpGet]
		[Authorize(Roles = SuperUser)]
		public async Task<IActionResult> Mine()
		{
			var userId = this.User.Id();

			try
			{
				var userMice = await this.mouseService.GetUserMiceAsync(userId);

				return View(userMice);
			}
			catch (PCShopException)
			{
				return View(ErrorCommonViewName);
			}
		}

		/// <summary>
		/// HttpGet action to buy a mouse
		/// </summary>
		/// <param name="id">Mouse unique identifier</param>
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
					var mouseSeller = (await this.mouseService.GetMouseByIdAsMouseEditViewModelAsync(id)).Seller;

					if (mouseSeller is not null && mouseSeller.UserId == userId)
					{
						return Unauthorized();
					}
				}

				ViewData["Title"] = "Buy a mouse";

				await this.mouseService.MarkMouseAsBoughtAsync(id);

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
