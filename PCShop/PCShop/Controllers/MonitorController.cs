using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Models.Monitor;
using PCShop.Core.Services.Interfaces;

namespace PCShop.Controllers
{
	/// <summary>
	/// Monitor controller class
	/// </summary>
	[Authorize]
	public class MonitorController : Controller
	{
		private readonly IMonitorService monitorService;

		/// <summary>
		/// Constructor of MonitorController class
		/// </summary>
		/// <param name="monitorService">The IMonitorService needed for functionality</param>
		public MonitorController(IMonitorService monitorService)
		{
			this.monitorService = monitorService;
		}

		/// <summary>
		/// HttpGet action to retrieve all active monitors according to specified criteria
		/// </summary>
		/// <param name="query">The entity that holds the specified criteria</param>
		/// <returns>Collection of all active monitors according to specified criteria</returns>
		[HttpGet]
		public async Task<IActionResult> Index([FromQuery] AllMonitorsQueryModel query)
		{
			var result = await this.monitorService.GetAllMonitorsAsync(
				query.Brand,
				query.DisplaySize,
				query.Resolution,
				query.RefreshRate,
				query.Keyword,
				query.Sorting,
				query.CurrentPage);

			query.TotalMonitorsCount = result.TotalMonitorsCount;

			query.Brands = await this.monitorService.GetAllBrandsNames();
			query.DisplaySizes = await this.monitorService.GetAllDisplaysSizesValues();
			query.Resolutions = await this.monitorService.GetAllResolutionsValues();
			query.RefreshRates = await this.monitorService.GetAllRefreshRatesValues();

			query.Monitors = result.Monitors;

			return View(query);
		}
	}
}
