using Microsoft.EntityFrameworkCore;
using PCShop.Core.Models.Laptop;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models;

namespace PCShop.Core.Services.Implementations
{
    /// <summary>
    /// Implementation of ILaptopService interface
    /// </summary>
    public class LaptopService : ILaptopService
    {
        private readonly IRepository repository;

        /// <summary>
        /// Constructor of LaptopService class
        /// </summary>
        /// <param name="repository">The repository that will be used</param>
        public LaptopService(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Method for retrieving all active laptops
        /// </summary>
        /// <returns>Collection of LaptopExportViewModels</returns>
        public async Task<IEnumerable<LaptopExportViewModel>> GetAllLaptopsAsync()
        {
            return await this.repository.AllAsReadOnly<Laptop>(l => !l.IsDeleted && l.Quantity >= 1)
                .Select(l => new LaptopExportViewModel()
                {
                    Id = l.Id,
                    Brand = l.Brand.Name,
                    CPU = l.CPU.Name,
                    RAM = l.RAM.Value,
                    SSDCapacity = l.SSDCapacity.Value,
                    VideoCard = l.VideoCard.Name,
                    Price = l.Price,
                    DisplaySize = l.DisplaySize.Value,
                    Warranty = l.Warranty,
                })
                .ToListAsync();
        }
    }
}
