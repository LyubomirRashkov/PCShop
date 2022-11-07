using PCShop.Core.Models.Laptop;

namespace PCShop.Core.Services.Interfaces
{
    /// <summary>
    /// Abstraction of LaptopService
    /// </summary>
    public interface ILaptopService
    {
        /// <summary>
        /// Method for retrieving all active laptops
        /// </summary>
        /// <returns>Collection of LaptopExportViewModels</returns>
        Task<IEnumerable<LaptopExportViewModel>> GetAllLaptopsAsync();
    }
}