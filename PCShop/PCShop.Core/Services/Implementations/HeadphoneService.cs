using Microsoft.EntityFrameworkCore;
using PCShop.Core.Constants;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Headphone;
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
	/// Implementation of IHeadphoneService interface
	/// </summary>
	public class HeadphoneService : IHeadphoneService
	{
		private readonly IRepository repository;
		private readonly IGuard guard;

		/// <summary>
		/// Constructor of HeadphoneService class
		/// </summary>
		/// <param name="repository">The repository that will be used</param>
		/// <param name="guard">The guard that will be used</param>
		public HeadphoneService(
			IRepository repository,
			IGuard guard)
		{
			this.repository = repository;
			this.guard = guard;
		}

		/// <summary>
		/// Method to mark a specific headphone as deleted
		/// </summary>
		/// <param name="id">Headphone unique identifier</param>
		public async Task DeleteHeadphoneAsync(int id)
		{
			var headphone = await this.repository.GetByIdAsync<Headphone>(id);

			this.guard.AgainstProductThatIsNull<Headphone>(headphone, ErrorMessageForInvalidProductId);

			this.guard.AgainstProductThatIsDeleted(headphone.IsDeleted, ErrorMessageForDeletedProduct);

			headphone.IsDeleted = true;

			await this.repository.SaveChangesAsync();
		}

		/// <summary>
		/// Method to retrieve all active headphones according to specified criteria
		/// </summary>
		/// <param name="type">The criterion for the headphone type</param>
		/// <param name="wireless">The criterion for the headphone connectivity</param>
		/// <param name="keyword">The criterion for keyword</param>
		/// <param name="sorting">The criterion for sorting</param>
		/// <param name="currentPage">Current page number</param>
		/// <returns>HeadphoneQueryModel object</returns>
		public async Task<HeadphonesQueryModel> GetAllHeadphonesAsync(
			string? type = null, 
			Wireless wireless = Wireless.Regardless, 
			string? keyword = null, 
			Sorting sorting = Sorting.Newest,
			int currentPage = 1)
		{
			var result = new HeadphonesQueryModel();

			var query = this.repository.AllAsReadOnly<Headphone>(h => !h.IsDeleted);

			if (!String.IsNullOrEmpty(type))
			{
				query = query.Where(h => h.Type.Name == type);
			}

			query = wireless switch
			{
				Wireless.No => query.Where(h => !h.IsWireless),

				Wireless.Yes => query.Where(h => h.IsWireless),

				_ => query
			};

			if (!String.IsNullOrEmpty(keyword))
			{
				var searchTerm = $"%{keyword.ToLower()}%";

				query = query.Where(h => EF.Functions.Like(h.Brand.Name.ToLower(), searchTerm)
										 || EF.Functions.Like(h.Type.Name.ToLower(), searchTerm));
			}

			query = sorting switch
			{
				Sorting.Brand => query.OrderBy(h => h.Brand.Name),

				Sorting.PriceMinToMax => query.OrderBy(h => h.Price),

				Sorting.PriceMaxToMin => query.OrderByDescending(h => h.Price),

				_ => query.OrderByDescending(h => h.Id)
			};

			result.Headphones = await query
				.Skip((currentPage - 1) * ProductsPerPage)
				.Take(ProductsPerPage)
				.Select(h => new HeadphoneExportViewModel()
				{
					Id = h.Id,
					Brand = h.Brand.Name,
					Type = h.Type.Name,
					IsWireless = h.IsWireless,
					HasMicrophone = h.HasMicrophone,
					Price = h.Price,
					Warranty = h.Warranty,
				})
				.ToListAsync();

			result.TotalHeadphonesCount = await query.CountAsync();

			return result;
		}

		/// <summary>
		/// Method to retrieve all headphone types
		/// </summary>
		/// <returns>Ordered collection of type names</returns>
		public async Task<IEnumerable<string>> GetAllHeadphonesTypesAsync()
		{
			return await this.repository.AllAsReadOnly<Headphone>(h => !h.IsDeleted)
				.Select(h => h.Type.Name)
				.Distinct()
				.OrderBy(n => n)
				.ToListAsync();
		}

		/// <summary>
		/// Method to retrieve a specific headphone
		/// </summary>
		/// <param name="id">Headphone unique identifier</param>
		/// <returns>The headphone as HeadphoneDetailsExportViewModel</returns>
		public async Task<HeadphoneDetailsExportViewModel> GetHeadphoneByIdAsHeadphoneDetailsExportViewModelAsync(int id)
		{
			var headphoneExports = await this.GetHeadphonesAsHeadphonesDetailsExportViewModelsAsync<Headphone>(h => h.Id == id);

			this.guard.AgainstNullOrEmptyCollection<HeadphoneDetailsExportViewModel>(headphoneExports, ErrorMessageForInvalidProductId);

			return headphoneExports.First();
		}

		private async Task<IList<HeadphoneDetailsExportViewModel>> GetHeadphonesAsHeadphonesDetailsExportViewModelsAsync<T>(Expression<Func<Headphone, bool>> condition)
		{
			var headphonesAsHeadphoneDetailsExportViewModels = await this.repository
				.AllAsReadOnly<Headphone>(h => !h.IsDeleted)
				.Where(condition)
				.Select(h => new HeadphoneDetailsExportViewModel()
				{
					Id = h.Id,
					Brand = h.Brand.Name,
					Price = h.Price,
					IsWireless = h.IsWireless,
					HasMicrophone = h.HasMicrophone,
					Type = h.Type.Name,
					Color = h.Color != null ? h.Color.Name : UnknownCharacteristic,
					ImageUrl = h.ImageUrl,
					Warranty = h.Warranty,
					Quantity = h.Quantity,
					AddedOn = h.AddedOn.ToString("MMMM, yyyy", CultureInfo.InvariantCulture),
					Seller = h.Seller,
					SellerFirstName = h.Seller != null ? h.Seller.User.FirstName : null,
					SellerLastName = h.Seller != null ? h.Seller.User.LastName : null,
				})
				.ToListAsync();

			return headphonesAsHeadphoneDetailsExportViewModels;
		}
	}
}
