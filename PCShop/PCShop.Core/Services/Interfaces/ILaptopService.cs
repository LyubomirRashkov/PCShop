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
        Task<LaptopDetailsExportViewModel> GetLaptopByIdAsDtoAsync(int id);

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
    }
}