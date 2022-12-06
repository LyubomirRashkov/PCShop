using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PCShop.Core.Models.User;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.Account;
using System.Data;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Infrastructure.Constants.DataConstant.RoleConstants;

namespace PCShop.Core.Services.Implementations
{
	/// <summary>
	/// Implementation of IUserService interface
	/// </summary>
	public class UserService : IUserService
	{
		private readonly IRepository repository;
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;

		/// <summary>
		/// Constructor of UserService class
		/// </summary>
		/// <param name="repository">The repository that will be used</param>
		/// <param name="userManager">The UserManager<c>User</c></param>
		/// <param name="signInManager">The SignInManager<c>User</c></param>
		public UserService(
			IRepository repository,
			UserManager<User> userManager,
			SignInManager<User> signInManager)
		{
			this.repository = repository;
			this.userManager = userManager;
			this.signInManager = signInManager;
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

		/// <summary>
		/// Method to add the user to SuperUser role
		/// </summary>
		/// <param name="client">The client who made the purchase</param>
		/// <returns>True when the count of client purchases is equal to required number of purchases to be SuperUser, else returns false</returns>
		public async Task<bool> ShouldBePromotedToSuperUser(Client client)
		{
			if (client.CountOfPurchases == RequiredNumberOfPurchasesToBeSuperUser)
			{
				var user = await this.userManager.FindByIdAsync(client.UserId);

				await this.userManager.AddToRoleAsync(user, SuperUser);

				await this.signInManager.SignOutAsync();

				await this.signInManager.SignInAsync(user, false);

				return true;
			}

			return false;
		}
	}
}
