using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PCShop.Core.Models.User;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models.Account;
using System.Data;

namespace PCShop.Core.Services.Implementations
{
	/// <summary>
	/// Implementation of IUserService interface
	/// </summary>
	public class UserService : IUserService
	{
		private readonly IRepository repository;

		/// <summary>
		/// Constructor of UserService class
		/// </summary>
		/// <param name="repository">The repository that will be used</param>
		public UserService(IRepository repository)
		{
			this.repository = repository;
		}

		/// <summary>
		/// Method to retrieve all users that are not in the specified role
		/// </summary>
		/// <param name="roleId">Role unique identifier</param>
		/// <returns>Ordered collection of UserExportViewModels</returns>
		public async Task<IEnumerable<UserExportViewModel>> GetAllUsersThatAreNotInTheSpecifiedRole(string? roleId)
		{
			var users = await this.repository.AllAsReadOnly<User>()
				.Select(u => new UserExportViewModel()
				{
					Id = u.Id,
					Username = u.UserName != null ? u.UserName : "unknown",
					Email = u.Email != null ? u.Email : "unknown",
					FirstName = u.FirstName != null ? u.FirstName : "unknown",
					LastName = u.LastName != null ? u.LastName : "unknown",
					Roles = this.repository.AllAsReadOnly<IdentityUserRole<string>>()
							.Where(x => x.UserId == u.Id)
							.Select(x => x.RoleId)
							.ToList(),
				})
				.OrderBy(x => x.Username)
				.ToListAsync();

			if (roleId is not null)
			{
				users = users
				.Where(u => !u.Roles.Any(r => r == roleId))
				.ToList();
			}

			return users;
		}
	}
}
