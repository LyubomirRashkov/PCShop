﻿using Microsoft.EntityFrameworkCore;
using PCShop.Core.Constants;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Monitor;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using System.Globalization;
using System.Linq.Expressions;
using static PCShop.Core.Constants.Constant.ProductConstants;
using Monitor = PCShop.Infrastructure.Data.Models.Monitor;

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
		/// Method to retrieve all monitor brands names
		/// </summary>
		/// <returns>Ordered collection of brand names</returns>
		public async Task<IEnumerable<string>> GetAllBrandsNames()
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
		public async Task<IEnumerable<double>> GetAllDisplaysSizesValues()
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
										: UnknownProductCharacteristic,
					Resolution = m.Resolution.Value,
					DisplayCoverage = m.DisplayCoverage != null 
									  ? m.DisplayCoverage.Name
									  : UnknownProductCharacteristic,
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
		public async Task<IEnumerable<int>> GetAllRefreshRatesValues()
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
		public async Task<IEnumerable<string>> GetAllResolutionsValues()
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

			return monitorExports[0];
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
										: UnknownProductCharacteristic,
					Resolution = m.Resolution.Value,
					DisplayCoverage = m.DisplayCoverage != null 
								      ? m.DisplayCoverage.Name 
									  : UnknownProductCharacteristic,
					RefreshRate = m.RefreshRate.Value,
					Type = m.Type.Name,
					Color = m.Color != null ? m.Color.Name : UnknownProductCharacteristic,
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
	}
}