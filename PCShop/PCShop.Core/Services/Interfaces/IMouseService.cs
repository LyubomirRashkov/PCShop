using PCShop.Core.Constants;
using PCShop.Core.Models.Mouse;

namespace PCShop.Core.Services.Interfaces
{
	/// <summary>
	/// Abstraction of MouseService
	/// </summary>
	public interface IMouseService
	{
		/// <summary>
		/// Method to retrieve all active mice according to specified criteria
		/// </summary>
		/// <param name="type">The criterion for the mouse type</param>
		/// <param name="sensitivity">The criterion for the mouse sensitivity</param>
		/// <param name="wireless">The criterion for the mouse connectivity</param>
		/// <param name="keyword">The criterion for keyword</param>
		/// <param name="sorting">The criterion for sorting</param>
		/// <param name="currentPage">Current page number</param>
		/// <returns>MiceQueryModel object</returns>
		Task<MiceQueryModel> GetAllMiceAsync(
			string? type = null,
			string? sensitivity = null,
			Wireless wireless = Wireless.Regardless,
			string? keyword = null,
			Sorting sorting = Sorting.Newest,
			int currentPage = 1);

		/// <summary>
		/// Method to retrieve all mouse types
		/// </summary>
		/// <returns>Ordered collection of type names</returns>
		Task<IEnumerable<string>> GetAllMiceTypesAsync();

		/// <summary>
		/// Method to retrieve all mouse sensitivities
		/// </summary>
		/// <returns>Ordered collection of sensitivity ranges</returns>
		Task<IEnumerable<string>> GetAllMiceSensitivitiesAsync();

		/// <summary>
		/// Method to retrieve a specific mouse
		/// </summary>
		/// <param name="id">Mouse unique identifier</param>
		/// <returns>The mouse as MouseDetailsExportViewModel</returns>
		Task<MouseDetailsExportViewModel> GetMouseByIdAsMouseDetailsExportViewModelAsync(int id);

		/// <summary>
		/// Method to mark a specific mouse as deleted
		/// </summary>
		/// <param name="id">Mouse unique identifier</param>
		Task DeleteMouseAsync(int id);

		/// <summary>
		/// Method to add a mouse
		/// </summary>
		/// <param name="model">Mouse input model</param>
		/// <param name="userId">Mouse's owner unique identifier</param>
		/// <returns>The unique identifier of the added mouse</returns>
		Task<int> AddMouseAsync(MouseImportViewModel model, string? userId);

        /// <summary>
        /// Method to retrieve a specific mouse
        /// </summary>
        /// <param name="id">Mouse unique identifier</param>
        /// <returns>The mouse as MouseEditViewModel</returns>
        Task<MouseEditViewModel> GetMouseByIdAsMouseEditViewModelAsync(int id);

        /// <summary>
        /// Method to edit a mouse
        /// </summary>
        /// <param name="model">Mouse input model</param>
        /// <returns>The unique identifier of the edited mouse</returns>
        Task<int> EditMouseAsync(MouseEditViewModel model);

		/// <summary>
		/// Method to retrieve all active mice sales of the currently logged in user
		/// </summary>
		/// <param name="userId">User unique identifier</param>
		/// <returns>Collection of MouseDetailsExportViewModels</returns>
		Task<IEnumerable<MouseDetailsExportViewModel>> GetUserMiceAsync(string userId);

		/// <summary>
		/// Method to mark the mouse with the given unique identifier as bought
		/// </summary>
		/// <param name="id">Mouse unique identifier</param>
		Task MarkMouseAsBoughtAsync(int id);
	}
}
