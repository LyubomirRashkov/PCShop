using Microsoft.EntityFrameworkCore;
using PCShop.Core.Constants;
using PCShop.Core.Models.Microphone;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models;
using static PCShop.Core.Constants.Constant.ProductConstants;

namespace PCShop.Core.Services.Implementations
{
	/// <summary>
	/// Implementation of IMicrophoneService interface
	/// </summary>
	public class MicrophoneService : IMicrophoneService
	{
		private readonly IRepository repository;

		/// <summary>
		/// Constructor of MicrophoneService class
		/// </summary>
		/// <param name="repository">The repository that will be used</param>
		public MicrophoneService(IRepository repository)
		{
			this.repository = repository;
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
	}
}
