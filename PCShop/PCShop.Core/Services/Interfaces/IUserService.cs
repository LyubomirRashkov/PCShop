using PCShop.Core.Models.User;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.Account;

namespace PCShop.Core.Services.Interfaces
{
	/// <summary>
	/// Abstraction of UserService
	/// </summary>
	public interface IUserService
	{
		/// <summary>
		/// Method to retrieve all users that are not in the specified role
		/// </summary>
		/// <param name="roleId">Role unique identifier</param>
		/// <returns>Ordered collection of UserExportViewModels</returns>
		Task<IEnumerable<UserExportViewModel>> GetAllUsersThatAreNotInTheSpecifiedRole(string? roleId);

		/// <summary>
		/// Method to add the user to SuperUser role
		/// </summary>
		/// <param name="client">The client who made the purchase</param>
		/// <returns>True when the count of client purchases is equal to required number of purchases to be SuperUser, else returns false</returns>
		Task<bool> ShouldBePromotedToSuperUser(Client client);

		/// <summary>
		/// Method to add the user with the specified unique identifier to Administrator role
		/// </summary>
		/// <param name="id">User unique identifier</param>
		/// <returns>The promoted to admin user</returns>
		Task<User> PromoteToAdminAsync(string id);
	}
}
