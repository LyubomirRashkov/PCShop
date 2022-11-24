using PCShop.Core.Constants;
using PCShop.Core.Models.Laptop;

namespace PCShop.Core.Services.Interfaces
{
    /// <summary>
    /// Abstraction of LaptopService
    /// </summary>
    public interface ILaptopService
    {
		/// <summary>
		/// Method to retrieve all active laptops according to specified criteria
		/// </summary>
		/// <param name="cpu">The criterion for the CPU model</param>
		/// <param name="ram">The criterion for the RAM capacity</param>
		/// <param name="ssdCapacity">The criterion for the SSD capacity</param>
		/// <param name="videoCard">The criterion for the video card</param>
		/// <param name="keyWord">The criterion for key word</param>
		/// <param name="sorting">The criterion for sorting</param>
		/// <param name="currentPage">Current page number</param>
		/// <returns>Collection of LaptopExportViewModels according to specified criteria</returns>
		Task<LaptopsQueryModel> GetAllLaptopsAsync(
            string? cpu = null,
            int? ram = null,
            int? ssdCapacity = null,
            string? videoCard = null,
            string? keyWord = null,
            Sorting sorting = Sorting.PriceMinToMax,
			int currentPage = 1);

        /// <summary>
        /// Method to retrieve a specific laptop
        /// </summary>
        /// <param name="id">Laptop unique identifier</param>
        /// <returns>The laptop as LaptopDetailsExportViewModel</returns>
        Task<LaptopDetailsExportViewModel> GetLaptopByIdAsLaptopDetailsExportViewModelAsync(int id);

		/// <summary>
		/// Method to mark a specific laptop as deleted
		/// </summary>
		/// <param name="id">Laptop unique identifier</param>
		Task DeleteLaptopAsync(int id);

		/// <summary>
		/// Method to add a laptop
		/// </summary>
		/// <param name="model">Laptop input model</param>
		/// <param name="userId">Laptop's owner unique identifier</param>
		/// <returns>The unique identifier of the added laptop</returns>
		Task<int> AddLaptopAsync(LaptopImportViewModel model, string? userId);

        /// <summary>
        /// Method to retrieve a specific laptop
        /// </summary>
        /// <param name="id">Laptop unique identifier</param>
        /// <returns>The laptop as LaptopEditViewModel</returns>
		Task<LaptopEditViewModel> GetLaptopByIdAsLaptopEditViewModelAsync(int id);

        /// <summary>
        /// Method to edit a laptop
        /// </summary>
        /// <param name="model">Laptop input model</param>
        /// <returns>The unique identifier of the edited laptop</returns>
        Task<int> EditLaptopAsync(LaptopEditViewModel model);

        /// <summary>
        /// Method to retrieve all active laptop sales of the currently logged in user
        /// </summary>
        /// <param name="userId">User unique identifier</param>
        /// <returns>Collection of LaptopDetailsExportViewModels</returns>
		Task<IEnumerable<LaptopDetailsExportViewModel>> GetUserLaptopsAsync(string userId);

		/// <summary>
		/// Method to mark the laptop with the given unique identifier as bought
		/// </summary>
		/// <param name="id">Laptop unique identifier</param>
		Task MarkLaptopAsBought(int id);

		/// <summary>
		/// Method to retrieve all CPU names
		/// </summary>
		/// <returns>Collection of CPU names</returns>
		Task<IEnumerable<string>> GetAllCpusNames();

		/// <summary>
		/// Method to retrieve all RAM values
		/// </summary>
		/// <returns>Collection of RAM values</returns>
		Task<IEnumerable<int>> GetAllRamsValues();

		/// <summary>
		/// Method to retrieve all SSD capacities
		/// </summary>
		/// <returns>Collection of SSD capacities</returns>
		Task<IEnumerable<int>> GetAllSsdCapacitiesValues();

		/// <summary>
		/// Method to retrieve all video card names
		/// </summary>
		/// <returns>Collection of video card names</returns>
		Task<IEnumerable<string>> GetAllVideoCardsNames();
	}
}