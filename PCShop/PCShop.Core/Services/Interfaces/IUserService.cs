using PCShop.Core.Models.User;

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
	}
}
