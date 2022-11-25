﻿using PCShop.Core.Constants;
using PCShop.Core.Models.Monitor;

namespace PCShop.Core.Services.Interfaces
{
	/// <summary>
	/// Abstraction of MonitorService
	/// </summary>
	public interface IMonitorService
	{
		/// <summary>
		/// Method to retrieve all active monitors according to specified criteria
		/// </summary>
		/// <param name="brand">The criterion for the monitor brand</param>
		/// <param name="displaySize">The criterion for the monitor display size</param>
		/// <param name="resolution">The criterion for the monitor resolution</param>
		/// <param name="refreshRate">The criterion for the monitor refresh rate</param>
		/// <param name="keyword">The criterion for keyword</param>
		/// <param name="sorting">The criterion for sorting</param>
		/// <param name="currentPage">Current page number</param>
		/// <returns>MonitorsQueryModel object</returns>
		Task<MonitorsQueryModel> GetAllMonitorsAsync(
			string? brand = null,
			double? displaySize = null,
			string? resolution = null,
			int? refreshRate = null,
			string? keyword = null,
			Sorting sorting = Sorting.PriceMinToMax,
			int currentPage = 1);

		/// <summary>
		/// Method to retrieve all monitor brands names
		/// </summary>
		/// <returns>Ordered collection of brand names</returns>
		Task<IEnumerable<string>> GetAllBrandsNames();

		/// <summary>
		/// Method to retrieve all monitor display sizes
		/// </summary>
		/// <returns>Ordered collection of display sizes</returns>
		Task<IEnumerable<double>> GetAllDisplaysSizesValues();

		/// <summary>
		/// Method to retrieve all monitor resolutions
		/// </summary>
		/// <returns>Ordered collection of resolutions</returns>
		Task<IEnumerable<string>> GetAllResolutionsValues();

		/// <summary>
		/// Method to retrieve all monitor refresh rates
		/// </summary>
		/// <returns>Ordered collection of refresh rates</returns>
		Task<IEnumerable<int>> GetAllRefreshRatesValues();

		/// <summary>
		/// Method to retrieve a specific monitor
		/// </summary>
		/// <param name="id">Monitor unique identifier</param>
		/// <returns>The monitor as MonitorDetailsExportViewModel</returns>
		Task<MonitorDetailsExportViewModel> GetMonitorByIdAsMonitorDetailsExportViewModelAsync(int id);

		/// <summary>
		/// Method to mark a specific monitor as deleted
		/// </summary>
		/// <param name="id">Monitor unique identifier</param>
		Task DeleteMonitorAsync(int id);
	}
}