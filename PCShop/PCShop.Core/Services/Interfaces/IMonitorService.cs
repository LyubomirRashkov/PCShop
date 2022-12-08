using PCShop.Core.Constants;
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
		Task<IEnumerable<string>> GetAllBrandsNamesAsync();

		/// <summary>
		/// Method to retrieve all monitor display sizes
		/// </summary>
		/// <returns>Ordered collection of display sizes</returns>
		Task<IEnumerable<double>> GetAllDisplaysSizesValuesAsync();

		/// <summary>
		/// Method to retrieve all monitor resolutions
		/// </summary>
		/// <returns>Ordered collection of resolutions</returns>
		Task<IEnumerable<string>> GetAllResolutionsValuesAsync();

		/// <summary>
		/// Method to retrieve all monitor refresh rates
		/// </summary>
		/// <returns>Ordered collection of refresh rates</returns>
		Task<IEnumerable<int>> GetAllRefreshRatesValuesAsync();

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

		/// <summary>
		/// Method to add a monitor
		/// </summary>
		/// <param name="model">Monitor input model</param>
		/// <param name="userId">Monitor's owner unique identifier</param>
		/// <returns>The unique identifier of the added monitor</returns>
		Task<int> AddMonitorAsync(MonitorImportViewModel model, string? userId);

		/// <summary>
		/// Method to retrieve a specific monitor
		/// </summary>
		/// <param name="id">Monitor unique identifier</param>
		/// <returns>The monitor as MonitorEditViewModel</returns>
		Task<MonitorEditViewModel> GetMonitorByIdAsMonitorEditViewModelAsync(int id);

        /// <summary>
        /// Method to edit a monitor
        /// </summary>
        /// <param name="model">Monitor input model</param>
        /// <returns>The unique identifier of the edited monitor</returns>
        Task<int> EditMonitorAsync(MonitorEditViewModel model);

		/// <summary>
		/// Method to retrieve all active monitor sales of the currently logged in user
		/// </summary>
		/// <param name="userId">User unique identifier</param>
		/// <returns>Collection of MonitorDetailsExportViewModels</returns>
		Task<IEnumerable<MonitorDetailsExportViewModel>> GetUserMonitorsAsync(string userId);

		/// <summary>
		/// Method to mark the monitor with the given unique identifier as bought
		/// </summary>
		/// <param name="id">Monitor unique identifier</param>
		Task MarkMonitorAsBoughtAsync(int id);
	}
}
