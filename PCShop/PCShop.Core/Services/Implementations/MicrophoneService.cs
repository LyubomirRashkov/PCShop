using Microsoft.EntityFrameworkCore;
using PCShop.Core.Constants;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Microphone;
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
	}
}
