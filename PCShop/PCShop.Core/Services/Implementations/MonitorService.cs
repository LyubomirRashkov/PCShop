﻿using Microsoft.EntityFrameworkCore;
using PCShop.Core.Constants;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Monitor;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using System.Globalization;
using System.Linq.Expressions;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Core.Constants.Constant.GlobalConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;
using Monitor = PCShop.Infrastructure.Data.Models.Monitor;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;

namespace PCShop.Core.Services.Implementations
{
	/// <summary>
	/// Implementation of IMonitorService interface
	/// </summary>
	public class MonitorService : IMonitorService
	{
		private readonly IRepository repository;
		private readonly IGuard guard;

		/// <summary>
		/// Constructor of MonitorService class
		/// </summary>
		/// <param name="repository">The repository that will be used</param>
		/// <param name="guard">The guard that will be used</param>
		public MonitorService(
			IRepository repository,
			IGuard guard)
		{
			this.repository = repository;
			this.guard = guard;
		}

        /// <summary>
        /// Method to add a monitor
        /// </summary>
        /// <param name="model">Monitor input model</param>
        /// <param name="userId">Monitor's owner unique identifier</param>
        /// <returns>The unique identifier of the added monitor</returns>
        public async Task<int> AddMonitorAsync(MonitorImportViewModel model, string? userId)
        {
			var monitor = new Monitor()
			{
				ImageUrl = model.ImageUrl,
				Warranty = model.Warranty,
				Price = model.Price != null ? model.Price.Value : default,
				Quantity = model.Quantity != null ? model.Quantity.Value : default,

				IsDeleted = false,
				AddedOn = DateTime.UtcNow.Date,
			};

			Client? dbClient = null;

			if (userId is not null)
			{
				dbClient = await this.repository.GetByPropertyAsync<Client>(c => c.UserId == userId);

				this.guard.AgainstInvalidUserId<Client>(dbClient, ErrorMessageForInvalidUserId);
			}

			monitor.Seller = dbClient;

			monitor = await this.SetNavigationPropertiesAsync(
				monitor, 
				model.Brand, 
				model.DisplaySize,
				model.Resolution, 
				model.RefreshRate, 
				model.Type, 
				model.DisplayCoverage,
				model.DisplayTechnology,
				model.Color);

			await this.repository.AddAsync<Monitor>(monitor);

			await this.repository.SaveChangesAsync();

			return monitor.Id;
		}

        /// <summary>
        /// Method to mark a specific monitor as deleted
        /// </summary>
        /// <param name="id">Monitor unique identifier</param>
        public async Task DeleteMonitorAsync(int id)
		{
			var monitor = await this.repository.GetByIdAsync<Monitor>(id);

			this.guard.AgainstProductThatIsNull<Monitor>(monitor, ErrorMessageForInvalidProductId);

			this.guard.AgainstProductThatIsDeleted(monitor.IsDeleted, ErrorMessageForDeletedProduct);

			monitor.IsDeleted = true;

			await this.repository.SaveChangesAsync();
		}

        /// <summary>
        /// Method to edit a monitor
        /// </summary>
        /// <param name="model">Monitor input model</param>
        /// <returns>The unique identifier of the edited monitor</returns>
        public async Task<int> EditMonitorAsync(MonitorEditViewModel model)
        {
			var monitor = await this.repository
				.All<Monitor>(m => !m.IsDeleted)
				.Where(m => m.Id == model.Id)
				.Include(m => m.Brand)
				.Include(m => m.DisplaySize)
				.Include(m => m.Type)
				.Include(m => m.DisplayCoverage)
				.Include(m => m.DisplayTechnology)
				.Include(m => m.Resolution)
				.Include(m => m.RefreshRate)
				.Include(m => m.Color)
				.FirstOrDefaultAsync();

			this.guard.AgainstProductThatIsNull<Monitor>(monitor, ErrorMessageForInvalidProductId);

			monitor.ImageUrl = model.ImageUrl;
			monitor.Warranty = model.Warranty;
			monitor.Price = model.Price != null ? model.Price.Value : default;
			monitor.Quantity = model.Quantity != null ? model.Quantity.Value : default;
			monitor.AddedOn = DateTime.UtcNow.Date;

			monitor = await this.SetNavigationPropertiesAsync(
				monitor, 
				model.Brand,
				model.DisplaySize,
				model.Resolution, 
				model.RefreshRate, 
				model.Type,
				model.DisplayCoverage, 
				model.DisplayTechnology,
				model.Color);

			await this.repository.SaveChangesAsync();

			return monitor.Id;
        }

        /// <summary>
        /// Method to retrieve all monitor brands names
        /// </summary>
        /// <returns>Ordered collection of brand names</returns>
        public async Task<IEnumerable<string>> GetAllBrandsNamesAsync()
		{
			return await this.repository.AllAsReadOnly<Monitor>(m => !m.IsDeleted)
				.Select(m => m.Brand.Name)
				.Distinct()
				.OrderBy(n => n)
				.ToListAsync();
		}

		/// <summary>
		/// Method to retrieve all monitor display sizes
		/// </summary>
		/// <returns>Ordered collection of display sizes</returns>
		public async Task<IEnumerable<double>> GetAllDisplaysSizesValuesAsync()
		{
			return await this.repository.AllAsReadOnly<Monitor>(m => !m.IsDeleted)
				.Select(m => m.DisplaySize.Value)
				.Distinct()
				.OrderBy(v => v)
				.ToListAsync();
		}

		/// <summary>
		/// Method to retrieve all active monitors according to specified criteria
		/// </summary>
		/// <param name="brand">The criterion for the monitor brand</param>
		/// <param name="displaySize">The criterion for the monitor display size</param>
		/// <param name="resolution">The criterion for the monitor resolution</param>
		/// <param name="refreshRate">The criterion for the monitor refresh rate</param>
		/// <param name="keyword">The criterion for keyword</param>
		/// <param name="sorting">The criterion for sorting</param>
		/// <param name="currentPage">Current page number</param>
		/// <returns>MonitorsQueryModel object</returns>
		public async Task<MonitorsQueryModel> GetAllMonitorsAsync(
			string? brand = null, 
			double? displaySize = null, 
			string? resolution = null, 
			int? refreshRate = null, 
			string? keyword = null, 
			Sorting sorting = Sorting.PriceMinToMax, 
			int currentPage = 1)
		{
			var result = new MonitorsQueryModel();

			var query = this.repository.AllAsReadOnly<Monitor>(m => !m.IsDeleted);

			if (!String.IsNullOrEmpty(brand))
			{
				query = query.Where(m => m.Brand.Name == brand);
			}

			if (displaySize is not null)
			{
				query = query.Where(m => m.DisplaySize.Value == displaySize);
			}

			if (!String.IsNullOrEmpty(resolution))
			{
				query = query.Where(m => m.Resolution.Value == resolution);
			}

			if (refreshRate is not null)
			{
				query = query.Where(m => m.RefreshRate.Value == refreshRate);
			}

			if (!String.IsNullOrEmpty(keyword)) 
			{
				var searchTerm = $"%{keyword.ToLower()}%";

				query = query.Where(m => EF.Functions.Like(m.Brand.Name.ToLower(), searchTerm)
									     || EF.Functions.Like(m.Type.Name.ToLower(), searchTerm)
										 || (m.DisplayCoverage != null && EF.Functions.Like(m.DisplayCoverage.Name.ToLower(), searchTerm))
										 || (m.DisplayTechnology != null && EF.Functions.Like(m.DisplayTechnology.Name.ToLower(), searchTerm)));
			}

			query = sorting switch
			{
				Sorting.Brand => query.OrderBy(m => m.Brand.Name),

				Sorting.PriceMinToMax => query.OrderBy(m => m.Price),

				Sorting.PriceMaxToMin => query.OrderByDescending(m => m.Price),

				_ => query.OrderByDescending(m => m.Id)
			};

			result.Monitors = await query
				.Skip((currentPage - 1) * ProductsPerPage)
				.Take(ProductsPerPage)
				.Select(m => new MonitorExportViewModel()
				{
					Id = m.Id,
					Brand = m.Brand.Name,
					DisplaySize = m.DisplaySize.Value,
					DisplayTechnology = m.DisplayTechnology != null 
									    ? m.DisplayTechnology.Name 
										: UnknownCharacteristic,
					Resolution = m.Resolution.Value,
					DisplayCoverage = m.DisplayCoverage != null 
									  ? m.DisplayCoverage.Name
									  : UnknownCharacteristic,
					RefreshRate = m.RefreshRate.Value,
					Price = m.Price,
					Warranty = m.Warranty,
				})
				.ToListAsync();

			result.TotalMonitorsCount = await query.CountAsync();

			return result;
		}

		/// <summary>
		/// Method to retrieve all monitor refresh rates
		/// </summary>
		/// <returns>Ordered collection of refresh rates</returns>
		public async Task<IEnumerable<int>> GetAllRefreshRatesValuesAsync()
		{
			return await this.repository.AllAsReadOnly<Monitor>(m => !m.IsDeleted)
				.Select(m => m.RefreshRate.Value)
				.Distinct()
				.OrderBy(v => v)
				.ToListAsync();
		}

		/// <summary>
		/// Method to retrieve all monitor resolutions
		/// </summary>
		/// <returns>Ordered collection of resolutions</returns>
		public async Task<IEnumerable<string>> GetAllResolutionsValuesAsync()
		{
			return await this.repository.AllAsReadOnly<Monitor>(m => !m.IsDeleted)
				.Select(m => m.Resolution.Value)
				.Distinct()
				.OrderBy(v => v)
				.ToListAsync();
		}

		/// <summary>
		/// Method to retrieve a specific monitor
		/// </summary>
		/// <param name="id">Monitor unique identifier</param>
		/// <returns>The monitor as MonitorDetailsExportViewModel</returns>
		public async Task<MonitorDetailsExportViewModel> GetMonitorByIdAsMonitorDetailsExportViewModelAsync(int id)
		{
			var monitorExports = await this.GetMonitorsAsMonitorsDetailsExportViewModelsAsync<Monitor>(m => m.Id == id);

			this.guard.AgainstNullOrEmptyCollection<MonitorDetailsExportViewModel>(monitorExports, ErrorMessageForInvalidProductId);

			return monitorExports.First();
		}

        /// <summary>
        /// Method to retrieve a specific monitor
        /// </summary>
        /// <param name="id">Monitor unique identifier</param>
        /// <returns>The monitor as MonitorEditViewModel</returns>
        public async Task<MonitorEditViewModel> GetMonitorByIdAsMonitorEditViewModelAsync(int id)
        {
			var monitorExport = await this.repository
				.AllAsReadOnly<Monitor>(m => !m.IsDeleted)
				.Where(m => m.Id == id)
				.Select(m => new MonitorEditViewModel()
				{
					Id = m.Id,
					Brand = m.Brand.Name,
					DisplaySize = m.DisplaySize.Value,
					Resolution = m.Resolution.Value,
					RefreshRate = m.RefreshRate.Value,
					Type = m.Type.Name,
					Quantity = m.Quantity,
					Price = m.Price,
					Warranty = m.Warranty,
					DisplayCoverage = m.DisplayCoverage == null ? null : m.DisplayCoverage.Name,
					DisplayTechnology = m.DisplayTechnology == null ? null : m.DisplayTechnology.Name,
					Color = m.Color == null ? null : m.Color.Name,
					ImageUrl = m.ImageUrl,
					Seller = m.Seller,
				})
				.FirstOrDefaultAsync();

			this.guard.AgainstProductThatIsNull<MonitorEditViewModel>(monitorExport, ErrorMessageForInvalidProductId);

			return monitorExport;
        }

		/// <summary>
		/// Method to retrieve all active monitor sales of the currently logged in user
		/// </summary>
		/// <param name="userId">User unique identifier</param>
		/// <returns>Collection of MonitorDetailsExportViewModels</returns>
		public async Task<IEnumerable<MonitorDetailsExportViewModel>> GetUserMonitorsAsync(string userId)
        {
			var client = await this.repository.GetByPropertyAsync<Client>(c => c.UserId == userId);

			this.guard.AgainstInvalidUserId<Client>(client, ErrorMessageForInvalidUserId);

			var userMonitors = await this.GetMonitorsAsMonitorsDetailsExportViewModelsAsync<Monitor>(m => m.SellerId == client.Id);

			return userMonitors;
        }

		/// <summary>
		/// Method to mark the monitor with the given unique identifier as bought
		/// </summary>
		/// <param name="id">Monitor unique identifier</param>
		public async Task MarkMonitorAsBoughtAsync(int id)
		{
			var monitor = await this.repository.GetByIdAsync<Monitor>(id);

			this.guard.AgainstProductThatIsNull<Monitor>(monitor, ErrorMessageForInvalidProductId);

			this.guard.AgainstProductThatIsDeleted(monitor.IsDeleted, ErrorMessageForDeletedProduct);

			this.guard.AgainstProductThatIsOutOfStock(monitor.Quantity, ErrorMessageForProductThatIsOutOfStock);

			monitor.Quantity--;

			await this.repository.SaveChangesAsync();
		}

		private async Task<IList<MonitorDetailsExportViewModel>> GetMonitorsAsMonitorsDetailsExportViewModelsAsync<T>(Expression<Func<Monitor, bool>> condition)
		{
			var monitorsAsMonitorsExportViewModels = await this.repository
				.AllAsReadOnly<Monitor>(m => !m.IsDeleted)
				.Where(condition)
				.Select(m => new MonitorDetailsExportViewModel()
				{
					Id = m.Id,
					Brand = m.Brand.Name,
					Price = m.Price,
					Warranty = m.Warranty,
					DisplaySize = m.DisplaySize.Value,
					DisplayTechnology = m.DisplayTechnology != null 
										? m.DisplayTechnology.Name 
										: UnknownCharacteristic,
					Resolution = m.Resolution.Value,
					DisplayCoverage = m.DisplayCoverage != null 
								      ? m.DisplayCoverage.Name 
									  : UnknownCharacteristic,
					RefreshRate = m.RefreshRate.Value,
					Type = m.Type.Name,
					Color = m.Color != null ? m.Color.Name : UnknownCharacteristic,
					ImageUrl = m.ImageUrl,
					AddedOn = m.AddedOn.ToString("MMMM, yyyy", CultureInfo.InvariantCulture),
					Quantity = m.Quantity,
					Seller = m.Seller,
					SellerFirstName = m.Seller != null ? m.Seller.User.FirstName : null,
					SellerLastName = m.Seller != null ? m.Seller.User.LastName : null,
				})
				.ToListAsync();

			return monitorsAsMonitorsExportViewModels;
		}

        private async Task<Monitor> SetNavigationPropertiesAsync(
			Monitor monitor, 
			string brand, 
			double displaySize, 
			string resolution, 
			int refreshRate,
			string type, 
			string? displayCoverage, 
			string? displayTechnology,
			string? color)
        {
            var brandNormalized = brand.ToLower();
            var dbBrand = await this.repository.GetByPropertyAsync<Brand>(b => EF.Functions.Like(b.Name.ToLower(), brandNormalized));
            dbBrand ??= new Brand { Name = brand };
            monitor.Brand = dbBrand;

            var dbDisplaySize = await this.repository.GetByPropertyAsync<DisplaySize>(ds => ds.Value == displaySize);
            dbDisplaySize ??= new DisplaySize { Value = displaySize };
            monitor.DisplaySize = dbDisplaySize;

			var resolutionNormalized = resolution.ToLower();
			var dbResolution = await this.repository.GetByPropertyAsync<Resolution>(r => EF.Functions.Like(r.Value.ToLower(), resolutionNormalized));
			dbResolution ??= new Resolution { Value = resolution };
			monitor.Resolution = dbResolution;

			var dbRefreshRate = await this.repository.GetByPropertyAsync<RefreshRate>(rr => rr.Value == refreshRate);
			dbRefreshRate ??= new RefreshRate { Value = refreshRate };
			monitor.RefreshRate = dbRefreshRate;

            var typeNormalized = type.ToLower();
            var dbType = await this.repository.GetByPropertyAsync<Type>(t => EF.Functions.Like(t.Name.ToLower(), typeNormalized));
            dbType ??= new Type { Name = type };
            monitor.Type = dbType;

            if (String.IsNullOrWhiteSpace(displayCoverage))
            {
                monitor.DisplayCoverage = null;
            }
            else
            {
                var displayCoverageNormalized = displayCoverage.ToLower();
                var dbDisplayCoverage = await this.repository.GetByPropertyAsync<DisplayCoverage>(dc => EF.Functions.Like(dc.Name.ToLower(), displayCoverageNormalized));
                dbDisplayCoverage ??= new DisplayCoverage { Name = displayCoverage };
                monitor.DisplayCoverage = dbDisplayCoverage;
            }

            if (String.IsNullOrWhiteSpace(displayTechnology))
            {
                monitor.DisplayTechnology = null;
            }
            else
            {
                var displayTechnologyNormalized = displayTechnology.ToLower();
                var dbDisplayTechnology = await this.repository.GetByPropertyAsync<DisplayTechnology>(dt => EF.Functions.Like(dt.Name.ToLower(), displayTechnologyNormalized));
                dbDisplayTechnology ??= new DisplayTechnology { Name = displayTechnology };
                monitor.DisplayTechnology = dbDisplayTechnology;
            }

            if (String.IsNullOrWhiteSpace(color))
            {
                monitor.Color = null;
            }
            else
            {
                var colorNormalized = color.ToLower();
                var dbColor = await this.repository.GetByPropertyAsync<Color>(c => EF.Functions.Like(c.Name.ToLower(), colorNormalized));
                dbColor ??= new Color { Name = color };
                monitor.Color = dbColor;
            }

            return monitor;
        }
	}
}
