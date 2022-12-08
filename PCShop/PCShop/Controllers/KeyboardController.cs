using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Models.Keyboard;
using PCShop.Core.Services.Interfaces;

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
	}
}
