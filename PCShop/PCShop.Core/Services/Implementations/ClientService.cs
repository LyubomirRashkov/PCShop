using Microsoft.EntityFrameworkCore;
using PCShop.Core.Exceptions;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models;
using static PCShop.Core.Constants.Constant.ClientConstants;

namespace PCShop.Core.Services.Implementations
{
	/// <summary>
	/// Implementation of IClientService interface
	/// </summary>
	public class ClientService : IClientService
	{
		private readonly IRepository repository;
		private readonly IGuard guard;

		/// <summary>
		/// Constructor of ClientService class
		/// </summary>
		/// <param name="repository">The repository that will be used</param>
		/// <param name="guard">The guard that will be used</param>
		public ClientService(
			IRepository repository,
			IGuard guard)
		{
			this.repository = repository;
			this.guard = guard;
		}

		/// <summary>
		/// Method to buy a product
		/// </summary>
		/// <param name="userId">User unique identifier</param>
		/// <returns>The client who purchased the product</returns>
		public async Task<Client> BuyProduct(string userId)
		{
			var dbClient = await this.repository.GetByPropertyAsync<Client>(c => c.UserId == userId);

			if (dbClient is null)
			{
				dbClient = new Client()
				{
					UserId = userId,
				};

				await this.repository.AddAsync<Client>(dbClient);
			}

			dbClient.CountOfPurchases++;

			await this.repository.SaveChangesAsync();

			return dbClient;
		}

		/// <summary>
		/// Method to retrieve the number of active sales for a given user
		/// </summary>
		/// <param name="userId">User unique identifier</param>
		/// <returns>The number of active sales of the user</returns>
		public async Task<int> GetNumberOfActiveSales(string userId)
		{
			var client = await this.repository
				.AllAsReadOnly<Client>(c => c.UserId == userId)
				.Include(c => c.Laptops)
				.Include(c => c.Monitors)
				.Include(c => c.Keyboards)
				.Include(c => c.Mice)
				.Include(c => c.Headphones)
				.Include(c => c.Microphones)
				.FirstOrDefaultAsync();

			this.guard.AgainstInvalidUserId<Client>(client, ErrorMessageForInvalidUserId);

			var numberOfClientSales = client.Laptops.Where(l => !l.IsDeleted).Count()
									  + client.Monitors.Where(m => !m.IsDeleted).Count()
									  + client.Keyboards.Where(k => !k.IsDeleted).Count()
									  + client.Mice.Where(m => !m.IsDeleted).Count()
									  + client.Headphones.Where(h => !h.IsDeleted).Count()
									  + client.Microphones.Where(m => !m.IsDeleted).Count();

			return numberOfClientSales;
		}
	}
}
