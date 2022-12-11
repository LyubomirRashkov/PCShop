using PCShop.Core.Constants;
using PCShop.Core.Models.Keyboard;

namespace PCShop.Core.Services.Interfaces
{
	/// <summary>
	/// Abstraction of KeyboardService
	/// </summary>
	public interface IKeyboardService
	{
		/// <summary>
		/// Method to retrieve all active keyboards according to specified criteria
		/// </summary>
		/// <param name="format">The criterion for the keyboard format</param>
		/// <param name="type">The criterion for the keyboard type</param>
		/// <param name="wireless">The criterion for the keyboard connectivity</param>
		/// <param name="keyword">The criterion for keyword</param>
		/// <param name="sorting">The criterion for sorting</param>
		/// <param name="currentPage">Current page number</param>
		/// <returns>KeyboardsQueryModel object</returns>
		Task<KeyboardsQueryModel> GetAllKeyboardsAsync(
			string? format = null,
			string? type = null,
			Wireless wireless = Wireless.Regardless,
			string? keyword = null,
			Sorting sorting = Sorting.Newest,
			int currentPage = 1);

		/// <summary>
		/// Method to retrieve all keyboard formats
		/// </summary>
		/// <returns>Ordered collection of format names</returns>
		Task<IEnumerable<string>> GetAllKeyboardsFormatsAsync();

		/// <summary>
		/// Method to retrieve all keyboard types
		/// </summary>
		/// <returns>Ordered collection of type names</returns>
		Task<IEnumerable<string>> GetAllKeyboardsTypesAsync();

		/// <summary>
		/// Method to retrieve a specific keyboard
		/// </summary>
		/// <param name="id">Keyboard unique identifier</param>
		/// <returns>The keyboard as KeyboardDetailsExportViewModel</returns>
		Task<KeyboardDetailsExportViewModel> GetKeyboardByIdAsKeyboardDetailsExportViewModelAsync(int id);

		/// <summary>
		/// Method to mark a specific keyboard as deleted
		/// </summary>
		/// <param name="id">Keyboard unique identifier</param>
		Task DeleteKeyboardAsync(int id);

		/// <summary>
		/// Method to add a keyboard
		/// </summary>
		/// <param name="model">Keyboard input model</param>
		/// <param name="userId">Keyboard's owner unique identifier</param>
		/// <returns>The unique identifier of the added keyboard</returns>
		Task<int> AddKeyboardAsync(KeyboardImportViewModel model, string? userId);

        /// <summary>
        /// Method to retrieve a specific keyboard
        /// </summary>
        /// <param name="id">Keyboard unique identifier</param>
        /// <returns>The keyboard as KeyboardEditViewModel</returns>
        Task<KeyboardEditViewModel> GetKeyboardByIdAsKeyboardEditViewModelAsync(int id);

        /// <summary>
        /// Method to edit a keyboard
        /// </summary>
        /// <param name="model">Keyboard input model</param>
        /// <returns>The unique identifier of the edited keyboard</returns>
        Task<int> EditKeyboardAsync(KeyboardEditViewModel model);

		/// <summary>
		/// Method to retrieve all active keyboards sales of the currently logged in user
		/// </summary>
		/// <param name="userId">User unique identifier</param>
		/// <returns>Collection of KeyboardDetailsExportViewModels</returns>
		Task<IEnumerable<KeyboardDetailsExportViewModel>> GetUserKeyboardsAsync(string userId);

		/// <summary>
		/// Method to mark the keyboard with the given unique identifier as bought
		/// </summary>
		/// <param name="id">Keyboard unique identifier</param>
		Task MarkKeyboardAsBoughtAsync(int id);
	}
}
