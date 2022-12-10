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
	}
}
