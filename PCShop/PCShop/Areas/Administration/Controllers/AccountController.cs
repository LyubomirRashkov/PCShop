using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Data.Models.Account;
using static PCShop.Infrastructure.Constants.DataConstant.RoleConstants;

namespace PCShop.Areas.Administration.Controllers
{
	/// <summary>
	/// Account controller class
	/// </summary>
	[Authorize(Roles = $"{Administrator}")]
	public class AccountController : Controller
	{
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly UserManager<User> userManager;
		private readonly IUserService userService;

		/// <summary>
		/// Constructor of AccountController class
		/// </summary>
		/// <param name="roleManager">The RoleManager<c>IdentityRole</c></param>
		/// <param name="userManager">The UserManager<c>User</c></param>
		/// <param name="userService">The IUserService needed for functionality</param>
		public AccountController(
			RoleManager<IdentityRole> roleManager,
			UserManager<User> userManager,
			IUserService userService)
		{
			this.roleManager = roleManager;
			this.userManager = userManager;
			this.userService = userService;
		}

		/// <summary>
		/// HttpGet action to retrieve all users that do not have the specified role
		/// </summary>
		/// <returns>Collection of users</returns>
		[HttpGet]
		public async Task<IActionResult> GetUsers()
		{
			var role = this.roleManager.Roles.FirstOrDefault(r => r.Name == Administrator);

			var users = await this.userService.GetAllUsersThatAreNotInTheSpecifiedRole(role?.Id ?? null);

			return View("~/Areas/Administration/Views/Account/GetUsers.cshtml", users);
		}

		/// <summary>
		/// HttpGet action to add the specified user to Administrator role
		/// </summary>
		/// <param name="id">User unique identifier</param>
		/// <returns>The corresponding view</returns>
		[HttpGet]
		public async Task<IActionResult> PromoteToAdmin(string id)
		{
			var user = await this.userManager.FindByIdAsync(id);

			if (user == null) 
			{
				return NotFound();
			}

			await this.userManager.AddToRoleAsync(user, Administrator);

			return View("~/Areas/Administration/Views/Account/PromoteToAdmin.cshtml", user);
		}
	}
}
