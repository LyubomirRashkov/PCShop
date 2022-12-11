using Microsoft.EntityFrameworkCore;
using PCShop.Core.Constants;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Headphone;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using System.Globalization;
using System.Linq.Expressions;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Core.Constants.Constant.GlobalConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;

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
		/// Method to add a headphone
		/// </summary>
		/// <param name="model">Headphone input model</param>
		/// <param name="userId">Headphone's owner unique identifier</param>
		/// <returns>The unique identifier of the added headphone</returns>
		public async Task<int> AddHeadphoneAsync(HeadphoneImportViewModel model, string? userId)
		{
			var headphone = new Headphone()
			{
				ImageUrl = model.ImageUrl,
				Warranty = model.Warranty,
				Price = model.Price != null ? model.Price.Value : default,
				Quantity = model.Quantity != null ? model.Quantity.Value : default,
				IsWireless = model.IsWireless != null ? model.IsWireless.Value : default,
				HasMicrophone = model.HasMicrophone != null ? model.HasMicrophone.Value : default,

				IsDeleted = false,
				AddedOn = DateTime.UtcNow.Date,
			};

			Client? dbClient = null;

			if (userId is not null)
			{
				dbClient = await this.repository.GetByPropertyAsync<Client>(c => c.UserId == userId);

				this.guard.AgainstInvalidUserId<Client>(dbClient, ErrorMessageForInvalidUserId);
			}

			headphone.Seller = dbClient;

			headphone = await this.SetNavigationPropertiesAsync(headphone, model.Brand, model.Type, model.Color);

			await this.repository.AddAsync<Headphone>(headphone);

			await this.repository.SaveChangesAsync();

			return headphone.Id;
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
        /// Method to edit a headphone
        /// </summary>
        /// <param name="model">Headphone input model</param>
        /// <returns>The unique identifier of the edited headphone</returns>
        public async Task<int> EditHeadphoneAsync(HeadphoneEditViewModel model)
        {
			var headphone = await this.repository
				.All<Headphone>(h => !h.IsDeleted)
				.Where(h => h.Id == model.Id)
				.Include(h => h.Brand)
				.Include(h => h.Type)
				.Include(h => h.Color)
				.FirstOrDefaultAsync();

			this.guard.AgainstProductThatIsNull<Headphone>(headphone, ErrorMessageForInvalidProductId);

            headphone.ImageUrl = model.ImageUrl;
            headphone.Warranty = model.Warranty;
            headphone.Price = model.Price != null ? model.Price.Value : default;
            headphone.Quantity = model.Quantity != null ? model.Quantity.Value : default;
            headphone.IsWireless = model.IsWireless != null ? model.IsWireless.Value : default;
			headphone.HasMicrophone = model.HasMicrophone != null ? model.HasMicrophone.Value : default;
            headphone.AddedOn = DateTime.UtcNow.Date;

			headphone = await this.SetNavigationPropertiesAsync(headphone, model.Brand, model.Type, model.Color);

			await this.repository.SaveChangesAsync();

			return headphone.Id;
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

        /// <summary>
        /// Method to retrieve a specific headphone
        /// </summary>
        /// <param name="id">Headphone unique identifier</param>
        /// <returns>The headphone as HeadphoneEditViewModel</returns>
        public async Task<HeadphoneEditViewModel> GetHeadphoneByIdAsHeadphoneEditViewModelAsync(int id)
		{
			var headphoneExport = await this.repository
				.AllAsReadOnly<Headphone>(h => !h.IsDeleted)
				.Where(h => h.Id == id)
				.Select(h => new HeadphoneEditViewModel()
				{
					Id = h.Id,
					Brand = h.Brand.Name,
					Type = h.Type.Name,
					IsWireless = h.IsWireless,
					HasMicrophone = h.HasMicrophone,
					Quantity = h.Quantity,
					Price = h.Price,
					Warranty = h.Warranty,
					Color = h.Color == null ? null : h.Color.Name,
					ImageUrl = h.ImageUrl,
					Seller = h.Seller,
				})
				.FirstOrDefaultAsync();

			this.guard.AgainstProductThatIsNull<HeadphoneEditViewModel>(headphoneExport, ErrorMessageForInvalidProductId);

			return headphoneExport;
		}

		/// <summary>
		/// Method to retrieve all active headphones sales of the currently logged in user
		/// </summary>
		/// <param name="userId">User unique identifier</param>
		/// <returns>Collection of HeadphoneDetailsExportViewModels</returns>
		public async Task<IEnumerable<HeadphoneDetailsExportViewModel>> GetUserHeadphonesAsync(string userId)
        {
			var client = await this.repository.GetByPropertyAsync<Client>(c => c.UserId == userId);

			this.guard.AgainstInvalidUserId<Client>(client, ErrorMessageForInvalidUserId);

			var userHeadphones = await this.GetHeadphonesAsHeadphonesDetailsExportViewModelsAsync<Headphone>(h => h.SellerId == client.Id);

			return userHeadphones;
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

		private async Task<Headphone> SetNavigationPropertiesAsync(Headphone headphone, string brand, string type, string? color)
		{
			var brandNormalized = brand.ToLower();
			var dbBrand = await this.repository.GetByPropertyAsync<Brand>(b => EF.Functions.Like(b.Name.ToLower(), brandNormalized));
			dbBrand ??= new Brand { Name = brand };
			headphone.Brand = dbBrand;

			var typeNormalized = type.ToLower();
			var dbType = await this.repository.GetByPropertyAsync<Type>(t => EF.Functions.Like(t.Name.ToLower(), typeNormalized));
			dbType ??= new Type { Name = type };
			headphone.Type = dbType;

			if (String.IsNullOrWhiteSpace(color))
			{
				headphone.Color = null;
			}
			else
			{
				var colorNormalized = color.ToLower();
				var dbColor = await this.repository.GetByPropertyAsync<Color>(c => EF.Functions.Like(c.Name.ToLower(), colorNormalized));
				dbColor ??= new Color { Name = color };
				headphone.Color = dbColor;
			}

			return headphone;
		}
	}
}
