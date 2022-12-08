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
			Wireless wireless = Wireless.No,
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
	}
}
