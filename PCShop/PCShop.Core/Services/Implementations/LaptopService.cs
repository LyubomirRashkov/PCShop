using Microsoft.EntityFrameworkCore;
using PCShop.Core.Models.Laptop;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models;
using System.Globalization;

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
        /// Method to retrieve all active laptops
        /// </summary>
        /// <returns>Collection of LaptopExportViewModels</returns>
        public async Task<IEnumerable<LaptopExportViewModel>> GetAllLaptopsAsync()
        {
            return await this.repository
                .AllAsReadOnly<Laptop>(l => !l.IsDeleted && l.Quantity >= 1)
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

        /// <summary>
        /// Method to retrieve a specific laptop
        /// </summary>
        /// <param name="id">Laptop unique identifier</param>
        /// <returns>The laptop as LaptopDetailsExportViewModel</returns>
        /// <exception cref="ArgumentException">Thrown when there is no laptop with the given unique identifier in the database</exception>
        public async Task<LaptopDetailsExportViewModel> GetLaptopByIdAsync(int id)
        {
            var laptopExport = await this.repository
                .AllAsReadOnly<Laptop>(l => !l.IsDeleted)
                .Where(l => l.Id == id)
                .Select(l => new LaptopDetailsExportViewModel()
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
                    Type = l.Type.Name,
                    DisplayCoverage = l.DisplayCoverage != null ? l.DisplayCoverage.Name : "unknown",
                    DisplayTechnology = l.DisplayTechnology != null ? l.DisplayTechnology.Name : "unknown",
                    Resolution = l.Resolution != null ? l.Resolution.Value : "unknown",
                    Color = l.Color != null ? l.Color.Name : "unknown",
                    ImageUrl = l.ImageUrl,
                    AddedOn = l.AddedOn.ToString("MMMM, yyyy", CultureInfo.InvariantCulture),
                    Quantity = l.Quantity,
                })
                .FirstOrDefaultAsync();

            if (laptopExport is null)
            {
                throw new ArgumentException("Invalid laptop id!");
            }

            return laptopExport;
        }
    }
}
