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
        Task<LaptopDetailsExportViewModel> GetLaptopByIdAsync(int id);
    }
}