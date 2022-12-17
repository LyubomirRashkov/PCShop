using Microsoft.AspNetCore.Identity;
using PCShop.Core.Exceptions;
using PCShop.Core.Services.Implementations.AdministrationArea;
using PCShop.Core.Services.Interfaces.AdministrationArea;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models.Account;
using PCShop.Tests.Mocks;

namespace PCShop.Tests.UnitTests
{
	[TestFixture]
	public class AdminUserServiceTests : UnitTestsBase
	{
		private IRepository repository;
		private UserManager<User> userManager;
		private IGuard guard;

		private IAdminUserService adminUserService;

		[OneTimeSetUp]
		public void SetUp()
		{
			this.repository = new Repository(this.data);
			this.userManager = UserManagerMock.MockUserManager(this.data.Users.ToList());
			this.guard = new Guard();

			this.adminUserService = new AdminUserService(this.repository, this.userManager, this.guard);
		}

		[Test]
		public async Task GetAllUsersThatAreNotInTheSpecifiedRole_ShouldReturnAllUsersWhenNoRoleIdIsGiven()
		{
			var resultUsers = await this.adminUserService.GetAllUsersThatAreNotInTheSpecifiedRole(null);

			var expectedUsers = this.data.Users.OrderBy(u => u.UserName);

			Assert.That(resultUsers.Count(), Is.EqualTo(expectedUsers.Count()));

			var resultUsersFirst = resultUsers.First();

			var expectedUsersFirst = expectedUsers.First();

			Assert.That(resultUsersFirst.Id, Is.EqualTo(expectedUsersFirst.Id));
		}

		[Test]
		public async Task GetAllUsersThatAreNotInTheSpecifiedRole_ShouldReturnAllUsersThatAreNotInTheGivenRole()
		{
			var roleId = this.data.Roles.First().Id;

			var resultUsers = await this.adminUserService.GetAllUsersThatAreNotInTheSpecifiedRole(roleId);

			var expectedUsers = this.data.Users
				.Where(u => !this.data.UserRoles.Any(ur => ur.UserId == u.Id && ur.RoleId == roleId))
				.OrderBy(u => u.UserName);

			Assert.That(resultUsers.Count(), Is.EqualTo(expectedUsers.Count()));

			var resultUsersFirst = resultUsers.First();

			var expectedUsersFirst = expectedUsers.First();

			Assert.That(resultUsersFirst.Id, Is.EqualTo(expectedUsersFirst.Id));
		}

		[Test]
		public async Task PromoteToAdminAsync_ShouldWorkCorrectlyWhenTheGivenUserIdIsValid()
		{
			var user = this.data.Users.First();

			var promotedUser = await this.adminUserService.PromoteToAdminAsync(user.Id);

			Assert.That(user, Is.EqualTo(promotedUser));
		}
	}
}
