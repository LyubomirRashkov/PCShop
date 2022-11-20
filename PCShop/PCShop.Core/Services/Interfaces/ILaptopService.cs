using PCShop.Core.Models.Laptop;

namespace PCShop.Core.Services.Interfaces
{
    /// <summary>
    /// Abstraction of LaptopService
    /// </summary>
    public interface ILaptopService
    {
        /// <summary>
        /// Method to retrieve all active laptops
        /// </summary>
        /// <returns>Collection of LaptopExportViewModels</returns>
        Task<IEnumerable<LaptopExportViewModel>> GetAllLaptopsAsync();

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
    }
}