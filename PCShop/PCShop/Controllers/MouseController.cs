using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Models.Mouse;
using PCShop.Core.Services.Interfaces;
using PCShop.Extensions;

namespace PCShop.Controllers
{
	/// <summary>
	/// Mouse controller class
	/// </summary>
	[Authorize]
	public class MouseController : Controller
	{
		private readonly IMouseService mouseService;

		/// <summary>
		/// Constructor of MouseController class
		/// </summary>
		/// <param name="mouseService">The IMouseService needed for functionality</param>
		public MouseController(IMouseService mouseService)
		{
			this.mouseService = mouseService;
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

				if (information != mouse.GetInformation())
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
	}
}
