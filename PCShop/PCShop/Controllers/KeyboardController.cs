using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Models.Keyboard;
using PCShop.Core.Services.Interfaces;
using PCShop.Extensions;
using System.Security.Claims;
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

		/// <summary>
		/// Constructor of KeyboardController class
		/// </summary>
		/// <param name="keyboardService">The IKeyboardService needed for functionality</param>
		public KeyboardController(IKeyboardService keyboardService)
		{
			this.keyboardService = keyboardService;
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
	}
}
