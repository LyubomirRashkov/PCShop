using PCShop.Core.Models.User;
using PCShop.Infrastructure.Data.Models.Account;

namespace PCShop.Core.Services.Interfaces.AdministrationArea
{
	/// <summary>
	/// Abstraction of AdminUserService
	/// </summary>
	public interface IAdminUserService
	{
		/// <summary>
		/// Method to retrieve all users that are not in the specified role
		/// </summary>
		/// <param name="roleId">Role unique identifier</param>
		/// <returns>Ordered collection of UserExportViewModels</returns>
		Task<IEnumerable<UserExportViewModel>> GetAllUsersThatAreNotInTheSpecifiedRole(string? roleId);

		/// <summary>
		/// Method to add the user with the specified unique identifier to Administrator role
		/// </summary>
		/// <param name="id">User unique identifier</param>
		/// <returns>The promoted to admin user</returns>
		Task<User> PromoteToAdminAsync(string id);
	}
}
