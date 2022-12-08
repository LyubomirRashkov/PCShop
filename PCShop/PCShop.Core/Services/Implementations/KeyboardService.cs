using Microsoft.EntityFrameworkCore;
using PCShop.Core.Constants;
using PCShop.Core.Models.Keyboard;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models;
using static PCShop.Core.Constants.Constant.GlobalConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;

namespace PCShop.Core.Services.Implementations
{
	/// <summary>
	/// Implementation of IKeyboardService interface
	/// </summary>
	public class KeyboardService : IKeyboardService
	{
		private readonly IRepository repository;

		/// <summary>
		/// Cnstructor of KeyboardService class
		/// </summary>
		/// <param name="repository">The repository that will be used</param>
		public KeyboardService(IRepository repository)
		{
			this.repository = repository;
		}

		/// <summary>
		/// Method to retrieve all active keyboards according to specified criteria
		/// </summary>
		/// <param name="format">The criterion for the keyboard format</param>
		/// <param name="type">The criterion for the keyboard type</param>
		/// <param name="wireless">The criterion for the keyboard connectivity</param>
		/// <param name="keyword">The criterion for keyword</param>
		/// <param name="sorting">The criterion for sorting</param>
		/// <param name="currentPage">Current page number</param>
		/// <returns>KeyboardsQueryModel object</returns>
		public async Task<KeyboardsQueryModel> GetAllKeyboardsAsync(
			string? format = null,
			string? type = null,
			Wireless wireless = Wireless.No,
			string? keyword = null,
			Sorting sorting = Sorting.Newest,
			int currentPage = 1)
		{
			var result = new KeyboardsQueryModel();

			var query = this.repository.AllAsReadOnly<Keyboard>(k => !k.IsDeleted);

			if (!String.IsNullOrEmpty(format))
			{
				query = query.Where(k => k.Format != null && k.Format.Name == format);
			}

			if (!String.IsNullOrEmpty(type))
			{
				query = query.Where(k => k.Type.Name == type);
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

				query = query.Where(k => EF.Functions.Like(k.Brand.Name.ToLower(), searchTerm)
										 || EF.Functions.Like(k.Type.Name.ToLower(), searchTerm)
										 || (k.Format != null && EF.Functions.Like(k.Format.Name.ToLower(), searchTerm)));
			}

			query = sorting switch
			{
				Sorting.Brand => query.OrderBy(k => k.Brand.Name),

				Sorting.PriceMinToMax => query.OrderBy(k => k.Price),

				Sorting.PriceMaxToMin => query.OrderByDescending(k => k.Price),

				_ => query.OrderByDescending(k => k.Id)
			};

			result.Keyboards = await query
				.Skip((currentPage - 1) * ProductsPerPage)
				.Take(ProductsPerPage)
				.Select(k => new KeyboardExportViewModel()
				{
					Id = k.Id,
					Brand = k.Brand.Name,
					Type = k.Type.Name,
					Format = k.Format != null ? k.Format.Name : UnknownCharacteristic,
					Wireless = k.IsWireless,
					Price = k.Price,
					Warranty = k.Warranty,
				})
				.ToListAsync();

			result.TotalKeyboardsCount = await query.CountAsync();

			return result;
		}

		/// <summary>
		/// Method to retrieve all keyboard formats
		/// </summary>
		/// <returns>Ordered collection of format names</returns>
		public async Task<IEnumerable<string>> GetAllKeyboardsFormatsAsync()
		{
			return await this.repository.AllAsReadOnly<Keyboard>(k => !k.IsDeleted)
				.Where(k => k.Format != null)
				.Select(k => k.Format.Name)
				.Distinct()
				.OrderBy(n => n)
				.ToListAsync();
		}

		/// <summary>
		/// Method to retrieve all keyboard types
		/// </summary>
		/// <returns>Ordered collection of type names</returns>
		public async Task<IEnumerable<string>> GetAllKeyboardsTypesAsync()
		{
			return await this.repository.AllAsReadOnly<Keyboard>(k => !k.IsDeleted)
				.Select(k => k.Type.Name)
				.Distinct()
				.OrderBy(n => n)
				.ToListAsync();
		}
	}
}
