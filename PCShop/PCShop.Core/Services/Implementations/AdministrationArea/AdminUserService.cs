﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.User;
using PCShop.Core.Services.Interfaces.AdministrationArea;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models.Account;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Core.Constants.Constant.GlobalConstants;
using static PCShop.Infrastructure.Constants.DataConstant.RoleConstants;

namespace PCShop.Core.Services.Implementations.AdministrationArea
{
	/// <summary>
	/// Implementation of IAdminUserService interface
	/// </summary>
	public class AdminUserService : IAdminUserService
	{
		private readonly IRepository repository;
		private readonly UserManager<User> userManager;
		private readonly IGuard guard;

		/// <summary>
		/// Constructor of AdminUserService
		/// </summary>
		/// <param name="repository">The repository that will be used</param>
		/// <param name="userManager">The UserManager<c>User</c></param>
		/// <param name="guard">The guard that will be used</param>
		public AdminUserService(
			IRepository repository,
			UserManager<User> userManager,
			IGuard guard)
		{
			this.repository = repository;
			this.userManager = userManager;
			this.guard = guard;
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
					Username = u.UserName ?? UnknownCharacteristic,
					Email = u.Email ?? UnknownCharacteristic,
					FirstName = u.FirstName ?? UnknownCharacteristic,
					LastName = u.LastName ?? UnknownCharacteristic,
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
		/// Method to add the user with the specified unique identifier to Administrator role
		/// </summary>
		/// <param name="id">User unique identifier</param>
		/// <returns>The promoted to admin user</returns>
		public async Task<User> PromoteToAdminAsync(string id)
		{
			var user = await this.userManager.FindByIdAsync(id);

			this.guard.AgainstInvalidUserId<User>(user, ErrorMessageForInvalidUserId);

			await this.userManager.AddToRoleAsync(user, Administrator);

			return user;
		}
	}
}
