using Microsoft.AspNetCore.Identity;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.Account;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Infrastructure.Constants.DataConstant.RoleConstants;

namespace PCShop.Core.Services.Implementations
{
	/// <summary>
	/// Implementation of IUserService interface
	/// </summary>
	public class UserService : IUserService
	{
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;

		/// <summary>
		/// Constructor of UserService class
		/// </summary>
		/// <param name="userManager">The UserManager<c>User</c></param>
		/// <param name="signInManager">The SignInManager<c>User</c></param>
		public UserService(
			UserManager<User> userManager,
			SignInManager<User> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
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
