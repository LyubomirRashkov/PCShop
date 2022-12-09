using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Keyboard;
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
	/// Keyboard controller class
	/// </summary>
	[Authorize]
	public class KeyboardController : Controller
	{
		private readonly IKeyboardService keyboardService;
		private readonly IClientService clientService;

		/// <summary>
		/// Constructor of KeyboardController class
		/// </summary>
		/// <param name="keyboardService">The IKeyboardService needed for functionality</param>
		/// <param name="clientService">The IClientService needed for functionality</param>
		public KeyboardController(
			IKeyboardService keyboardService,
			IClientService clientService)
		{
			this.keyboardService = keyboardService;
			this.clientService = clientService;
		}

		/// <summary>
		/// HttpGet action to retrieve all active keyboards according to specified criteria
		/// </summary>
		/// <param name="query">The entity that holds the specified criteria</param>
		/// <returns>Collection of all active keyboards according to specified criteria</returns>
		[HttpGet]
		public async Task<IActionResult> Index([FromQuery] AllKeyboardsQueryModel query)
		{
			var result = await this.keyboardService.GetAllKeyboardsAsync(
				query.Format,
				query.Type,
				query.Wireless,
				query.Keyword,
				query.Sorting,
				query.CurrentPage);

			query.TotalKeyboardsCount = result.TotalKeyboardsCount;

			query.Formats = await this.keyboardService.GetAllKeyboardsFormatsAsync();
			query.Types = await this.keyboardService.GetAllKeyboardsTypesAsync();

			query.Keyboards = result.Keyboards;

			return View(query);
		}

		/// <summary>
		/// HttpGet action to retrieve detailed information about a specific keyboard
		/// </summary>
		/// <param name="id">Keyboard unique identifier</param>
		/// <param name="information">Keyboard additional information</param>
		/// <returns>Detailed information about the keyboard</returns>
		[HttpGet]
		public async Task<IActionResult> Details(int id, string information)
		{
			try
			{
				var keyboard = await this.keyboardService.GetKeyboardByIdAsKeyboardDetailsExportViewModelAsync(id);

				if (information != keyboard.GetInformation())
				{
					return NotFound();
				}

				return View(keyboard);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Action to mark a specific keyboard as deleted
		/// </summary>
		/// <param name="id">Keyboard unique identifier</param>
		/// <returns>Redirection to /Keyboard/Index</returns>
		[HttpGet]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var keyboard = await this.keyboardService.GetKeyboardByIdAsKeyboardDetailsExportViewModelAsync(id);

				if (this.User.IsInRole(SuperUser) 
					&& (keyboard.Seller is null || this.User.Id() != keyboard.Seller.UserId))
				{
					return Unauthorized();
				}

				await this.keyboardService.DeleteKeyboardAsync(id);

				TempData[TempDataMessage] = ProductSuccessfullyDeleted;

				return RedirectToAction(nameof(Index));
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// HttpGet action to return the form for adding a keyboard
		/// </summary>
		/// <returns>The form for adding a keyboard</returns>
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
						ViewData["Title"] = "Add a keyboard";

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
		/// HttpPost action to add a keyboard
		/// </summary>
		/// <param name="model">Keyboard import model</param>
		/// <param name="radioButton">The value of selected radio button</param>
		/// <returns>Redirection to /Keyboard/Details</returns>
		[HttpPost]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Add(KeyboardImportViewModel model, bool? radioButton)
		{
			if (radioButton is null)
			{
				this.ModelState.AddModelError("IsWireless", ErrorMessageForUnselectedOption);
			}
			else
			{
				model.IsWireless = (bool)radioButton;
			}

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
				int id = await this.keyboardService.AddKeyboardAsync(model, userId);

				TempData[TempDataMessage] = ProductSuccessfullyAdded;

				return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
			}
			catch (PCShopException)
			{
				return View(ErrorCommonViewName);
			}
		}

        /// <summary>
        /// HttpGet action to return the form for editing a keyboard
        /// </summary>
        /// <param name="id">Keyboard unique identifier</param>
        /// <returns>The form for editing a keyboard</returns>
        [HttpGet]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				var keyboard = await this.keyboardService.GetKeyboardByIdAsKeyboardEditViewModelAsync(id);

				if (this.User.IsInRole(SuperUser)
					&& (keyboard.Seller is null || this.User.Id() != keyboard.Seller.UserId))
				{
					return Unauthorized();
				}

				return View(keyboard);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

        /// <summary>
        /// HttpPost action to edit a keyboard
        /// </summary>
        /// <param name="model">Keyboard import model</param>
        /// <returns>Redirection to /Keyboard/Details</returns>
        [HttpPost]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Edit(KeyboardEditViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return View();
			}

			try
			{
				var keyboard = await this.keyboardService.GetKeyboardByIdAsKeyboardEditViewModelAsync(model.Id);

				if (this.User.IsInRole(SuperUser)
					&& (keyboard.Seller is null || this.User.Id() != keyboard.Seller.UserId))
				{
					return Unauthorized();
				}

				int id = await this.keyboardService.EditKeyboardAsync(model);

                TempData[TempDataMessage] = ProductSuccessfullyEdited;

                return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
            }
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

    }
}
