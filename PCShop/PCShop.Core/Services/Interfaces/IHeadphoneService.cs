using PCShop.Core.Constants;
using PCShop.Core.Models.Headphone;

namespace PCShop.Core.Services.Interfaces
{
	/// <summary>
	/// Abstraction of HeadphoneService
	/// </summary>
	public interface IHeadphoneService
	{
		/// <summary>
		/// Method to retrieve all active headphones according to specified criteria
		/// </summary>
		/// <param name="type">The criterion for the headphone type</param>
		/// <param name="wireless">The criterion for the headphone connectivity</param>
		/// <param name="keyword">The criterion for keyword</param>
		/// <param name="sorting">The criterion for sorting</param>
		/// <param name="currentPage">Current page number</param>
		/// <returns>HeadphoneQueryModel object</returns>
		Task<HeadphonesQueryModel> GetAllHeadphonesAsync(
			string? type = null,
			Wireless wireless = Wireless.Regardless,
			string? keyword = null,
			Sorting sorting = Sorting.Newest,
			int currentPage = 1);

		/// <summary>
		/// Method to retrieve all headphone types
		/// </summary>
		/// <returns>Ordered collection of type names</returns>
		Task<IEnumerable<string>> GetAllHeadphonesTypesAsync();

		/// <summary>
		/// Method to retrieve a specific headphone
		/// </summary>
		/// <param name="id">Headphone unique identifier</param>
		/// <returns>The headphone as HeadphoneDetailsExportViewModel</returns>
		Task<HeadphoneDetailsExportViewModel> GetHeadphoneByIdAsHeadphoneDetailsExportViewModelAsync(int id);

		/// <summary>
		/// Method to mark a specific headphone as deleted
		/// </summary>
		/// <param name="id">Headphone unique identifier</param>
		Task DeleteHeadphoneAsync(int id);
	}
}
