using Microsoft.EntityFrameworkCore;
using PCShop.Core.Constants;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Mouse;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models;
using System.Globalization;
using System.Linq.Expressions;
using static PCShop.Core.Constants.Constant.GlobalConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;

namespace PCShop.Core.Services.Implementations
{
	/// <summary>
	/// Implementation of IMouseService interface
	/// </summary>
	public class MouseService : IMouseService
	{
		private readonly IRepository repository;
		private readonly IGuard guard;

		/// <summary>
		/// Constructor of MouseService class
		/// </summary>
		/// <param name="repository">The repository that will be used</param>
		/// <param name="guard">The guard that will be used</param>
		public MouseService(
			IRepository repository,
			IGuard guard)
		{
			this.repository = repository;
			this.guard = guard;
		}

		/// <summary>
		/// Method to retrieve all active mice according to specified criteria
		/// </summary>
		/// <param name="type">The criterion for the mouse type</param>
		/// <param name="sensitivity">The criterion for the mouse sensitivity</param>
		/// <param name="wireless">The criterion for the mouse connectivity</param>
		/// <param name="keyword">The criterion for keyword</param>
		/// <param name="sorting">The criterion for sorting</param>
		/// <param name="currentPage">Current page number</param>
		/// <returns>MiceQueryModel object</returns>
		public async Task<MiceQueryModel> GetAllMiceAsync(
			string? type = null,
			string? sensitivity = null,
			Wireless wireless = Wireless.Regardless, 
			string? keyword = null,
			Sorting sorting = Sorting.Newest, 
			int currentPage = 1)
		{
			var result = new MiceQueryModel();

			var query = this.repository.AllAsReadOnly<Mouse>(m => !m.IsDeleted);

			if (!String.IsNullOrEmpty(type))
			{
				query = query.Where(m => m.Type.Name == type);
			}

			if (!String.IsNullOrEmpty(sensitivity))
			{
				query = query.Where(m => m.Sensitivity.Range == sensitivity);
			}

			query = wireless switch
			{
				Wireless.No => query.Where(k => !k.IsWireless),

				Wireless.Yes => query.Where(k => k.IsWireless),

				_ => query
			};

			if (!String.IsNullOrEmpty(keyword))
			{
				var searchTerm = $"%{keyword.ToLower()}%";

				query = query.Where(m => EF.Functions.Like(m.Brand.Name.ToLower(), searchTerm)
										 || EF.Functions.Like(m.Type.Name.ToLower(), searchTerm)
										 || EF.Functions.Like(m.Sensitivity.Range.ToLower(), searchTerm));
			}

			query = sorting switch
			{
				Sorting.Brand => query.OrderBy(m => m.Brand.Name),

				Sorting.PriceMinToMax => query.OrderBy(m => m.Price),

				Sorting.PriceMaxToMin => query.OrderByDescending(m => m.Price),

				_ => query.OrderByDescending(m => m.Id)
			};

			result.Mice = await query
				.Skip((currentPage - 1) * ProductsPerPage)
				.Take(ProductsPerPage)
				.Select(m => new MouseExportViewModel()
				{
					Id = m.Id,
					Brand = m.Brand.Name,
					Type = m.Type.Name,
					Sensitivity = m.Sensitivity.Range,
					IsWireless = m.IsWireless,
					Price = m.Price,
					Warranty = m.Warranty,
				})
				.ToListAsync();

			result.TotalMiceCount = await query.CountAsync();

			return result;
		}

		/// <summary>
		/// Method to retrieve all mouse sensitivities
		/// </summary>
		/// <returns>Ordered collection of sensitivity ranges</returns>
		public async Task<IEnumerable<string>> GetAllMiceSensitivitiesAsync()
		{
			return await this.repository.AllAsReadOnly<Mouse>(m => !m.IsDeleted)
				.Select(m => m.Sensitivity.Range)
				.Distinct()
				.OrderBy(r => r)
				.ToListAsync();
		}

		/// <summary>
		/// Method to retrieve all mouse types
		/// </summary>
		/// <returns>Ordered collection of type names</returns>
		public async Task<IEnumerable<string>> GetAllMiceTypesAsync()
		{
			return await this.repository.AllAsReadOnly<Mouse>(m => !m.IsDeleted)
				.Select(m => m.Type.Name)
				.Distinct()
				.OrderBy(n => n)
				.ToListAsync();
		}

		/// <summary>
		/// Method to retrieve a specific mouse
		/// </summary>
		/// <param name="id">Mouse unique identifier</param>
		/// <returns>The mouse as MouseDetailsExportViewModel</returns>
		public async Task<MouseDetailsExportViewModel> GetMouseByIdAsMouseDetailsExportViewModelAsync(int id)
		{
			var mouseExports = await this.GetMiceAsMouseDetailsExportViewModelsAsync<Mouse>(m => m.Id == id);

			this.guard.AgainstNullOrEmptyCollection<MouseDetailsExportViewModel>(mouseExports, ErrorMessageForInvalidProductId);

			return mouseExports.First();
		}

		private async Task<IList<MouseDetailsExportViewModel>> GetMiceAsMouseDetailsExportViewModelsAsync<T>(Expression<Func<Mouse, bool>> condition)
		{
			var miceAsMouseDetailsExportViewModels = await this.repository
				.AllAsReadOnly<Mouse>(m => !m.IsDeleted)
				.Where(condition)
				.Select(m => new MouseDetailsExportViewModel()
				{
					Id = m.Id,
					Brand = m.Brand.Name,
					Price = m.Price,
					IsWireless = m.IsWireless,
					Type = m.Type.Name,
					Sensitivity = m.Sensitivity.Range,
					Color = m.Color != null ? m.Color.Name : UnknownCharacteristic,
					ImageUrl = m.ImageUrl,
					Warranty = m.Warranty,
					Quantity = m.Quantity,
					AddedOn = m.AddedOn.ToString("MMMM, yyyy", CultureInfo.InvariantCulture),
					Seller = m.Seller,
					SellerFirstName = m.Seller != null ? m.Seller.User.FirstName : null,
					SellerLastName = m.Seller != null ? m.Seller.User.LastName : null,
				})
				.ToListAsync();

			return miceAsMouseDetailsExportViewModels;
		}
	}
}
