﻿using Microsoft.EntityFrameworkCore;
using PCShop.Core.Models.Laptop;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using System.Globalization;
using System.Linq.Expressions;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Core.Constants.Constant.LaptopConstants;
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
        /// <exception cref="ArgumentException">Thrown when there is no client with the given FK (userId) in the database</exception>
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
            };

            Client? dbClient = null;

            if (userId is not null)
            {
                dbClient = await this.repository.GetByPropertyAsync<Client>(c => c.UserId == userId);

                if (dbClient is null)
                {
                    throw new ArgumentException(ErrorMessageForInvalidUserId);
                }
            }

            laptop.Seller = dbClient;

            laptop = await this.SetNavigationPropertiesAsync(laptop, model.Brand, model.CPU, model.RAM, model.SSDCapacity, model.VideoCard, model.Type, model.DisplaySize, model.DisplayCoverage, model.DisplayTechnology, model.Resolution, model.Color);

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
                throw new ArgumentException(ErrorMessageForInvalidLaptopId);
            }

            laptop.IsDeleted = true;

            await this.repository.SaveChangesAsync();
        }

        /// <summary>
        /// Method to edit a laptop
        /// </summary>
        /// <param name="model">Laptop input model</param>
        /// <returns>The unique identifier of the edited laptop</returns>
        /// <exception cref="ArgumentException">Thrown when there is no laptop with the given unique identifier in the database</exception>
        public async Task<int> EditLaptopAsync(LaptopEditViewModel model)
        {
            var laptop = await this.repository
                .All<Laptop>(l => !l.IsDeleted)
                .Where(l => l.Id == model.Id)
                .Include(l => l.Brand)
                .Include(l => l.CPU)
                .Include(l => l.RAM)
                .Include(l => l.SSDCapacity)
                .Include(l => l.VideoCard)
                .Include(l => l.Type)
                .Include(l => l.DisplaySize)
                .Include(l => l.DisplayCoverage)
                .Include(l => l.DisplayTechnology)
                .Include(l => l.Resolution)
                .Include(l => l.Color)
                .FirstOrDefaultAsync();

            if (laptop is null)
            {
                throw new ArgumentException(ErrorMessageForInvalidLaptopId);
            }

            laptop.ImageUrl = model.ImageUrl;
            laptop.Warranty = model.Warranty;
            laptop.Price = model.Price;
            laptop.Quantity = model.Quantity;
            laptop.AddedOn = DateTime.UtcNow.Date;

            laptop = await this.SetNavigationPropertiesAsync(laptop, model.Brand, model.CPU, model.RAM, model.SSDCapacity, model.VideoCard, model.Type, model.DisplaySize, model.DisplayCoverage, model.DisplayTechnology, model.Resolution, model.Color);

            await this.repository.SaveChangesAsync();

            return laptop.Id;
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
        public async Task<LaptopDetailsExportViewModel> GetLaptopByIdAsLaptopDetailsExportViewModelAsync(int id)
        {
            var laptopExport = await this.GetLaptopsAsLaptopDetailsExportViewModelsAsync<Laptop>(l => l.Id == id);

            if (laptopExport is null)
            {
                throw new ArgumentException(ErrorMessageForInvalidLaptopId);
            }

            return laptopExport[0];
        }

        /// <summary>
        /// Method to retrieve a specific laptop
        /// </summary>
        /// <param name="id">Laptop unique identifier</param>
        /// <returns>The laptop as LaptopEditViewModel</returns>
        /// <exception cref="ArgumentException">Thrown when there is no laptop with the given unique identifier in the database</exception>
        public async Task<LaptopEditViewModel> GetLaptopByIdAsLaptopEditViewModelAsync(int id)
        {
            var laptopExport = await this.repository
                .All<Laptop>(l => !l.IsDeleted)
                .Where(l => l.Id == id)
                .Select(l => new LaptopEditViewModel()
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
                    DisplayCoverage = l.DisplayCoverage == null ? null : l.DisplayCoverage.Name,
                    DisplayTechnology = l.DisplayTechnology == null ? null : l.DisplayTechnology.Name,
                    Resolution = l.Resolution == null ? null : l.Resolution.Value,
                    Color = l.Color == null ? null : l.Color.Name,
                    ImageUrl = l.ImageUrl,
                    Quantity = l.Quantity,
                    Seller = l.Seller,
                })
                .FirstOrDefaultAsync();

            if (laptopExport is null)
            {
                throw new ArgumentException(ErrorMessageForInvalidLaptopId);
            }

            return laptopExport;
        }

        /// <summary>
        /// Method to retrieve all active laptop sales of the currently logged in user
        /// </summary>
        /// <param name="userId">User unique identifier</param>
        /// <returns>Collection of LaptopDetailsExportViewModels</returns>
        /// <exception cref="ArgumentException">Thrown when there is no client with the given FK (userId) in the database</exception>
		public async Task<IEnumerable<LaptopDetailsExportViewModel>> GetUserLaptopsAsync(string userId)
		{
            var client = await this.repository.GetByPropertyAsync<Client>(c => c.UserId == userId);

			if (client is null)
			{
				throw new ArgumentException(ErrorMessageForInvalidUserId);
			}

            var userLaptops = await this.GetLaptopsAsLaptopDetailsExportViewModelsAsync<Laptop>(l => l.SellerId == client.Id);

			return userLaptops;
		}

		private async Task<Laptop> SetNavigationPropertiesAsync(Laptop laptop, string brand, string cpu, int ram, int ssdCapacity, string videoCard, string type, double displaySize, string? displayCoverage, string? displayTechnology, string? resolution, string? color)
        {
            var brandNormalized = brand.ToLower();
            var dbBrand = await this.repository.GetByPropertyAsync<Brand>(b => EF.Functions.Like(b.Name.ToLower(), brandNormalized));
            dbBrand ??= new Brand { Name = brand };
            laptop.Brand = dbBrand;

            var cpuNormalized = cpu.ToLower();
            var dbCpu = await this.repository.GetByPropertyAsync<CPU>(c => EF.Functions.Like(c.Name.ToLower(), cpuNormalized));
            dbCpu ??= new CPU { Name = cpu };
            laptop.CPU = dbCpu;

            var dbRam = await this.repository.GetByPropertyAsync<RAM>(r => r.Value == ram);
            dbRam ??= new RAM { Value = ram };
            laptop.RAM = dbRam;

            var dbSsdCapacity = await this.repository.GetByPropertyAsync<SSDCapacity>(s => s.Value == ssdCapacity);
            dbSsdCapacity ??= new SSDCapacity { Value = ssdCapacity };
            laptop.SSDCapacity = dbSsdCapacity;

            var videoCardNormalized = videoCard.ToLower();
            var dbVideoCard = await this.repository.GetByPropertyAsync<VideoCard>(vc => EF.Functions.Like(vc.Name.ToLower(), videoCardNormalized));
            dbVideoCard ??= new VideoCard { Name = videoCard };
            laptop.VideoCard = dbVideoCard;

            var typeNormalized = type.ToLower();
            var dbType = await this.repository.GetByPropertyAsync<Type>(t => EF.Functions.Like(t.Name.ToLower(), typeNormalized));
            dbType ??= new Type { Name = type };
            laptop.Type = dbType;

            var dbDisplaySize = await this.repository.GetByPropertyAsync<DisplaySize>(ds => ds.Value == displaySize);
            dbDisplaySize ??= new DisplaySize { Value = displaySize };
            laptop.DisplaySize = dbDisplaySize;

            if (String.IsNullOrWhiteSpace(displayCoverage))
            {
                laptop.DisplayCoverage = null;
            }
            else
            {
                var displayCoverageNormalized = displayCoverage.ToLower();
                var dbDisplayCoverage = await this.repository.GetByPropertyAsync<DisplayCoverage>(dc => EF.Functions.Like(dc.Name.ToLower(), displayCoverageNormalized));
                dbDisplayCoverage ??= new DisplayCoverage { Name = displayCoverage };
                laptop.DisplayCoverage = dbDisplayCoverage;
            }

            if (String.IsNullOrWhiteSpace(displayTechnology))
            {
                laptop.DisplayTechnology = null;
            }
            else
            {
                var displayTechnologyNormalized = displayTechnology.ToLower();
                var dbDisplayTechnology = await this.repository.GetByPropertyAsync<DisplayTechnology>(dt => EF.Functions.Like(dt.Name.ToLower(), displayTechnologyNormalized));
                dbDisplayTechnology ??= new DisplayTechnology { Name = displayTechnology };
                laptop.DisplayTechnology = dbDisplayTechnology;
            }

            if (String.IsNullOrWhiteSpace(resolution))
            {
                laptop.Resolution = null;
            }
            else
            {
                var resolutionNormalized = resolution.ToLower();
                var dbResolution = await this.repository.GetByPropertyAsync<Resolution>(r => EF.Functions.Like(r.Value.ToLower(), resolutionNormalized));
                dbResolution ??= new Resolution { Value = resolution };
                laptop.Resolution = dbResolution;
            }

            if (String.IsNullOrWhiteSpace(color))
            {
                laptop.Color = null;
            }
            else
            {
                var colorNormalized = color.ToLower();
                var dbColor = await this.repository.GetByPropertyAsync<Color>(c => EF.Functions.Like(c.Name.ToLower(), colorNormalized));
                dbColor ??= new Color { Name = color };
                laptop.Color = dbColor;
            }

            return laptop;
        }

		private async Task<IList<LaptopDetailsExportViewModel>> GetLaptopsAsLaptopDetailsExportViewModelsAsync<T>(Expression<Func<Laptop, bool>> condition)
		{
			var laptopsAsLaptopDetailsExportViewModels = await this.repository
				.AllAsReadOnly<Laptop>(l => !l.IsDeleted)
				.Where(condition)
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
					Seller = l.Seller,
				})
				.ToListAsync();

			return laptopsAsLaptopDetailsExportViewModels;
		}
	}
}
