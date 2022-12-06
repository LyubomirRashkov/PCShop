using Microsoft.AspNetCore.Identity;
using PCShop.Infrastructure.Data.Models.Account;
using static PCShop.Infrastructure.Constants.DataConstant.RoleConstants;
using static PCShop.Infrastructure.Constants.DataConstant.UserConstants;

namespace Microsoft.AspNetCore.Builder
{
	/// <summary>
	/// ApplicationBuilderExtensions model
	/// </summary>
	public static class ApplicationBuilderExtensions
	{
		/// <summary>
		/// Extension method for adding admin user to the Administrator role
		/// </summary>
		/// <param name="app">The IApplicationBuilder that will be extended</param>
		/// <returns>Extended IApplicationBuilder</returns>
		public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app) 
		{
			using var scopedServices = app.ApplicationServices.CreateScope();

			var services = scopedServices.ServiceProvider;

			var userManager = services.GetRequiredService<UserManager<User>>();
			var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

			Task.Run(async () =>
			{
				if (!(await roleManager.RoleExistsAsync(Administrator)))
				{
					await roleManager.CreateAsync(new IdentityRole { Name = Administrator });
				}

				var admin = await userManager.FindByNameAsync(AdminUserName);

				await userManager.AddToRoleAsync(admin, Administrator);
			})
				.GetAwaiter()
				.GetResult();

			return app;
		}

		/// <summary>
		/// Extension method for adding superUser user to the SuperUser role
		/// </summary>
		/// <param name="app">The IApplicationBuilder that will be extended</param>
		/// <returns>Extended IApplicationBuilder</returns>
		public static IApplicationBuilder SeedSuperUser(this IApplicationBuilder app)
		{
			using var scopedServices = app.ApplicationServices.CreateScope();

			var services = scopedServices.ServiceProvider;

			var userManager = services.GetRequiredService<UserManager<User>>();
			var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

			Task.Run(async () =>
			{
				if (!(await roleManager.RoleExistsAsync(SuperUser)))
				{
					await roleManager.CreateAsync(new IdentityRole { Name = SuperUser });
				}

				var superUser = await userManager.FindByNameAsync(SuperUserUserName);

				await userManager.AddToRoleAsync(superUser, SuperUser);
			})
				.GetAwaiter()
				.GetResult();

			return app;
		}
	}
}
