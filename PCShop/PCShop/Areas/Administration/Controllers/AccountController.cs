using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.User;
using PCShop.Core.Services.Interfaces;
using static PCShop.Areas.Administration.Constant;
using static PCShop.Infrastructure.Constants.DataConstant.RoleConstants;

namespace PCShop.Areas.Administration.Controllers
{
	/// <summary>
	/// Account controller class
	/// </summary>
	public class AccountController : BaseController
	{
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly IUserService userService;
		private readonly IMemoryCache memoryCache;

		/// <summary>
		/// Constructor of AccountController class
		/// </summary>
		/// <param name="roleManager">The RoleManager<c>IdentityRole</c> needed for functionality</param>
		/// <param name="userService">The IUserService needed for functionality</param>
		/// <param name="memoryCache">The IMemoryCache needed for functionality</param>
		public AccountController(
			RoleManager<IdentityRole> roleManager,
			IUserService userService,
			IMemoryCache memoryCache)
		{
			this.roleManager = roleManager;
			this.userService = userService;
			this.memoryCache = memoryCache;
		}

		/// <summary>
		/// HttpGet action to retrieve all users that do not have the specified role
		/// </summary>
		/// <returns>Collection of users</returns>
		[HttpGet]
		public async Task<IActionResult> GetUsers()
		{
			var users = this.memoryCache.Get<IEnumerable<UserExportViewModel>>(UsersCacheKey);

			if (users is null)
			{
				var role = this.roleManager.Roles.FirstOrDefault(r => r.Name == Administrator);

				users = await this.userService.GetAllUsersThatAreNotInTheSpecifiedRole(role?.Id ?? null);

				var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

				this.memoryCache.Set(UsersCacheKey, users, cacheOptions);
			}

			return View(users);
		}

		/// <summary>
		/// HttpGet action to add the specified user to Administrator role
		/// </summary>
		/// <param name="id">User unique identifier</param>
		/// <returns>The corresponding view</returns>
		[HttpGet]
		public async Task<IActionResult> PromoteToAdmin(string id)
		{
			try
			{
				var user = await this.userService.PromoteToAdminAsync(id);

				this.memoryCache.Remove(UsersCacheKey);

				return View(user);
			}
			catch (PCShopException)
			{
				return NotFound();
			}
		}
	}
}
