using Microsoft.EntityFrameworkCore;
using PCShop.Core.Models.Laptop;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using System.Globalization;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;

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
		/// Method to add a laptop
		/// </summary>
		/// <param name="model">Laptop input model</param>
		/// <param name="userId">Laptop's owner unique identifier</param>
		/// <returns>The unique identifier of the added laptop</returns>
		public async Task<int> AddLaptopAsync(LaptopImportViewModel model, string? userId)
        {
            var laptop = new Laptop()
            {
                ImageUrl = model.ImageUrl,
                Warranty = model.Warranty,
                Price = model.Price,
                Quantity = model.Quantity,

                IsDeleted = false,
                AddedOn = DateTime.UtcNow.Date,

                SellerId = userId,
            };

            var dbBrand = await this.repository.GetByPropertyAsync<Brand>(b => b.Name.ToLower() == model.Brand.ToLower());
            dbBrand ??= new Brand { Name = model.Brand };
            laptop.Brand = dbBrand;

            var dbCpu = await this.repository.GetByPropertyAsync<CPU>(c => c.Name.ToLower() == model.CPU.ToLower());
            dbCpu ??= new CPU { Name = model.CPU };
            laptop.CPU = dbCpu;

            var dbRam = await this.repository.GetByPropertyAsync<RAM>(r => r.Value == model.RAM);
            dbRam ??= new RAM { Value = model.RAM };
            laptop.RAM = dbRam;

            var dbSsdCapacity = await this.repository.GetByPropertyAsync<SSDCapacity>(s => s.Value == model.SSDCapacity);
            dbSsdCapacity ??= new SSDCapacity { Value = model.SSDCapacity };
            laptop.SSDCapacity = dbSsdCapacity;

            var dbVideoCard = await this.repository.GetByPropertyAsync<VideoCard>(vc => vc.Name.ToLower() == model.VideoCard.ToLower());
            dbVideoCard ??= new VideoCard { Name = model.VideoCard };
            laptop.VideoCard = dbVideoCard;

            var dbType = await this.repository.GetByPropertyAsync<Type>(t => t.Name.ToLower() == model.Type.ToLower());
            dbType ??= new Type { Name = model.Type };
            laptop.Type = dbType;

            var dbDisplaySize = await this.repository.GetByPropertyAsync<DisplaySize>(ds => ds.Value == model.DisplaySize);
            dbDisplaySize ??= new DisplaySize { Value = model.DisplaySize };
            laptop.DisplaySize = dbDisplaySize;

            if (model.DisplayCoverage is null)
            {
                laptop.DisplayCoverage = null;
            }
            else
            {
                var dbDisplayCoverage = await this.repository.GetByPropertyAsync<DisplayCoverage>(dc => dc.Name.ToLower() == model.DisplayCoverage.ToLower());
                dbDisplayCoverage ??= new DisplayCoverage { Name = model.DisplayCoverage };
                laptop.DisplayCoverage = dbDisplayCoverage;
            }

            if (model.DisplayTechnology is null)
            {
                laptop.DisplayTechnology = null;
            }
            else
            {
                var dbDisplayTechnology = await this.repository.GetByPropertyAsync<DisplayTechnology>(dt => dt.Name.ToLower() == model.DisplayTechnology.ToLower());
                dbDisplayTechnology ??= new DisplayTechnology { Name = model.DisplayTechnology };
                laptop.DisplayTechnology = dbDisplayTechnology;
            }

            if (model.Resolution is null)
            {
                laptop.Resolution = null;
            }
            else
            {
                var dbResolution = await this.repository.GetByPropertyAsync<Resolution>(r => r.Value.ToLower() == model.Resolution.ToLower());
                dbResolution ??= new Resolution { Value = model.Resolution };
                laptop.Resolution = dbResolution;
            }

            if (model.Color is null)
            {
                laptop.Color = null;
            }
            else
            {
                var dbColor = await this.repository.GetByPropertyAsync<Color>(c => c.Name.ToLower() == model.Color.ToLower());
                dbColor ??= new Color { Name = model.Color };
                laptop.Color = dbColor;
            }

            await this.repository.AddAsync<Laptop>(laptop);

            await this.repository.SaveChangesAsync();

            return laptop.Id;
        }

        /// <summary>
        /// Method to mark a specific laptop as deleted
        /// </summary>
        /// <param name="id">Laptop unique identifier</param>
        /// <exception cref="ArgumentException">Thrown when there is no laptop with the given unique identifier in the database</exception>
        public async Task DeleteLaptopAsync(int id)
        {
            var laptop = await this.repository
                .All<Laptop>(l => !l.IsDeleted)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (laptop is null)
            {
                throw new ArgumentException("Invalid laptop id!");
            }

            laptop.IsDeleted = true;

            await this.repository.SaveChangesAsync();
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
        public async Task<LaptopDetailsExportViewModel> GetLaptopByIdAsDtoAsync(int id)
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
                    SellerId = l.SellerId,
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
