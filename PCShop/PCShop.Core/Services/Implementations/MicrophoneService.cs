using Microsoft.EntityFrameworkCore;
using PCShop.Core.Constants;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Microphone;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using System.Globalization;
using System.Linq.Expressions;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Core.Constants.Constant.GlobalConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;

namespace PCShop.Core.Services.Implementations
{
	/// <summary>
	/// Implementation of IMicrophoneService interface
	/// </summary>
	public class MicrophoneService : IMicrophoneService
	{
		private readonly IRepository repository;
		private readonly IGuard guard;

		/// <summary>
		/// Constructor of MicrophoneService class
		/// </summary>
		/// <param name="repository">The repository that will be used</param>
		/// <param name="guard">The guard that will be used</param>
		public MicrophoneService(
			IRepository repository,
			IGuard guard)
		{
			this.repository = repository;
			this.guard = guard;
		}

		/// <summary>
		/// Method to add a microphone
		/// </summary>
		/// <param name="model">Microphone input model</param>
		/// <param name="userId">Microphone's owner unique identifier</param>
		/// <returns>The unique identifier of the added microphone</returns>
		public async Task<int> AddMicrophoneAsync(MicrophoneImportViewModel model, string? userId)
		{
			var microphone = new Microphone()
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

			microphone.Seller = dbClient;

			microphone = await this.SetNavigationPropertiesAsync(microphone, model.Brand, model.Color);

			await this.repository.AddAsync<Microphone>(microphone);

			await this.repository.SaveChangesAsync();

			return microphone.Id;
		}

		/// <summary>
		/// Method to mark a specific microphone as deleted
		/// </summary>
		/// <param name="id">Microphone unique identifier</param>
		public async Task DeleteMicrophoneAsync(int id)
		{
			var microphone = await this.repository.GetByIdAsync<Microphone>(id);

			this.guard.AgainstProductThatIsNull<Microphone>(microphone, ErrorMessageForInvalidProductId);

			this.guard.AgainstProductThatIsDeleted(microphone.IsDeleted, ErrorMessageForDeletedProduct);

			microphone.IsDeleted = true;

			await this.repository.SaveChangesAsync();
		}

        /// <summary>
        /// Method to edit a microphone
        /// </summary>
        /// <param name="model">Microphone input model</param>
        /// <returns>The unique identifier of the edited microphone</returns>
        public async Task<int> EditMicrophoneAsync(MicrophoneEditViewModel model)
        {
			var microphone = await this.repository
				.All<Microphone>(m => !m.IsDeleted)
				.Where(m => m.Id == model.Id)
				.Include(m => m.Brand)
				.Include(m => m.Color)
				.FirstOrDefaultAsync();

			this.guard.AgainstProductThatIsNull<Microphone>(microphone, ErrorMessageForInvalidProductId);

            microphone.ImageUrl = model.ImageUrl;
            microphone.Warranty = model.Warranty;
            microphone.Price = model.Price != null ? model.Price.Value : default;
            microphone.Quantity = model.Quantity != null ? model.Quantity.Value : default;
            microphone.AddedOn = DateTime.UtcNow.Date;

            microphone = await this.SetNavigationPropertiesAsync(microphone, model.Brand, model.Color);

            await this.repository.SaveChangesAsync();

            return microphone.Id;
        }

        /// <summary>
        /// Method to retrieve all active microphones according to specified criteria
        /// </summary>
        /// <param name="keyword">The criterion for keyword</param>
        /// <param name="sorting">The criterion for sorting</param>
        /// <param name="currentPage">Current page number</param>
        /// <returns>MicrophonesQueryModel object</returns>
        public async Task<MicrophonesQueryModel> GetAllMicrophonesAsync(
			string? keyword = null,
			Sorting sorting = Sorting.Newest,
			int currentPage = 1)
		{
			var result = new MicrophonesQueryModel();

			var query = this.repository.AllAsReadOnly<Microphone>(m => !m.IsDeleted);

			if (!String.IsNullOrEmpty(keyword))
			{
				var searchTerm = $"%{keyword.ToLower()}%";

				query = query.Where(m => EF.Functions.Like(m.Brand.Name.ToLower(), searchTerm));
			}

			query = sorting switch
			{
				Sorting.Brand => query.OrderBy(m => m.Brand.Name),

				Sorting.PriceMinToMax => query.OrderBy(m => m.Price),

				Sorting.PriceMaxToMin => query.OrderByDescending(m => m.Price),

				_ => query.OrderByDescending(m => m.Id)
			};

			result.Microphones = await query
				.Skip((currentPage - 1) * ProductsPerPage)
				.Take(ProductsPerPage)
				.Select(m => new MicrophoneExportViewModel()
				{
					Id = m.Id,
					Brand = m.Brand.Name,
					Price = m.Price,
					Warranty = m.Warranty,
				})
				.ToListAsync();

			result.TotalMicrophonesCount = await query.CountAsync();

			return result;
		}

		/// <summary>
		/// Method to retrieve a specific microphone
		/// </summary>
		/// <param name="id">Microphone unique identifier</param>
		/// <returns>The microphone as MicrophoneDetailsExportViewModel</returns>
		public async Task<MicrophoneDetailsExportViewModel> GetMicrophoneByIdAsMicrohoneDetailsExportViewModelAsync(int id)
		{
			var microphoneExports = await this.GetMicrophonesAsMicrophonesDetailsExportViewModelsAsync<Microphone>(m => m.Id == id);

			this.guard.AgainstNullOrEmptyCollection<MicrophoneDetailsExportViewModel>(microphoneExports, ErrorMessageForInvalidProductId);

			return microphoneExports.First();
		}

        /// <summary>
        /// Method to retrieve a specific microphone
        /// </summary>
        /// <param name="id">Microphone unique identifier</param>
        /// <returns>The microphone as MicrophoneEditViewModel</returns>
        public async Task<MicrophoneEditViewModel> GetMicrophoneByIdAsMicrophoneEditViewModelAsync(int id)
		{
			var microphoneExport = await this.repository
				.AllAsReadOnly<Microphone>(m => !m.IsDeleted)
				.Where(m => m.Id == id)
				.Select(m => new MicrophoneEditViewModel()
				{
					Id = m.Id,
					Brand = m.Brand.Name,
					Quantity = m.Quantity,
					Price = m.Price,
					Warranty = m.Warranty,
					Color = m.Color == null ? null : m.Color.Name,
					ImageUrl = m.ImageUrl,
					Seller = m.Seller,
				})
				.FirstOrDefaultAsync();

			this.guard.AgainstProductThatIsNull<MicrophoneEditViewModel>(microphoneExport, ErrorMessageForInvalidProductId);

			return microphoneExport;
		}

		private async Task<IList<MicrophoneDetailsExportViewModel>> GetMicrophonesAsMicrophonesDetailsExportViewModelsAsync<T>(Expression<Func<Microphone, bool>> condition)
		{
			var microphonesAsMicrophoneDetailsExportViewModels = await this.repository
				.AllAsReadOnly<Microphone>(m => !m.IsDeleted)
				.Where(condition)
				.Select(m => new MicrophoneDetailsExportViewModel()
				{
					Id = m.Id,
					Brand = m.Brand.Name,
					Price = m.Price,
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

			return microphonesAsMicrophoneDetailsExportViewModels;
		}

		private async Task<Microphone> SetNavigationPropertiesAsync(Microphone microphone, string brand, string? color)
		{
			var brandNormalized = brand.ToLower();
			var dbBrand = await this.repository.GetByPropertyAsync<Brand>(b => EF.Functions.Like(b.Name.ToLower(), brandNormalized));
			dbBrand ??= new Brand { Name = brand };
			microphone.Brand = dbBrand;

			if (String.IsNullOrWhiteSpace(color))
			{
				microphone.Color = null;
			}
			else
			{
				var colorNormalized = color.ToLower();
				var dbColor = await this.repository.GetByPropertyAsync<Color>(c => EF.Functions.Like(c.Name.ToLower(), colorNormalized));
				dbColor ??= new Color { Name = color };
				microphone.Color = dbColor;
			}

			return microphone;
		}
	}
}
