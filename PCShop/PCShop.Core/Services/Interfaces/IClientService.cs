using PCShop.Infrastructure.Data.Models;

namespace PCShop.Core.Services.Interfaces
{
	/// <summary>
	/// Abstraction of ClientService
	/// </summary>
	public interface IClientService
    {
		/// <summary>
		/// Method to retrieve the number of active sales for a given user
		/// </summary>
		/// <param name="userId">User unique identifier</param>
		/// <returns>The number of active sales of the user</returns>
		Task<int> GetNumberOfActiveSales(string userId);

		/// <summary>
		/// Method to buy a product
		/// </summary>
		/// <param name="userId">User unique identifier</param>
		/// <returns>The client who purchased the product</returns>
		Task<Client> BuyProduct(string userId);
    }
}
