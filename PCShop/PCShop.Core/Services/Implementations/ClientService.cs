using Microsoft.EntityFrameworkCore;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models;
using static PCShop.Infrastructure.Constants.DataConstant.ClientConstants;

namespace PCShop.Core.Services.Implementations
{
	/// <summary>
	/// Implementation of IClientService interface
	/// </summary>
	public class ClientService : IClientService
    {
        private readonly IRepository repository;

		/// <summary>
		/// Constructor of ClientService class
		/// </summary>
		/// <param name="repository">The repository that will be used</param>
		public ClientService(IRepository repository)
        {
            this.repository = repository;
        }

		/// <summary>
		/// Method to retrieve the number of active sales for a given user
		/// </summary>
		/// <param name="userId">User unique identifier</param>
		/// <returns>The number of active sales of the user</returns>
		/// <exception cref="ArgumentException">Thrown when there is no client with the given user unique identifier in the database</exception>
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

            if (client is null)
            {
                throw new ArgumentException(ErrorMessageForInvalidUserId);
            }

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
