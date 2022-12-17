using Microsoft.AspNetCore.Identity;
using PCShop.Core.Exceptions;
using PCShop.Core.Services.Implementations.AdministrationArea;
using PCShop.Core.Services.Interfaces.AdministrationArea;
using PCShop.Infrastructure.Common;
using PCShop.Infrastructure.Data.Models.Account;
using PCShop.Tests.Mocks;
using PCShop.Tests.UnitTests;
using static PCShop.Core.Constants.Constant.ClientConstants;

namespace PCShop.Tests.IntegrationTests
{
	[TestFixture]
	public class AdminUserServiceGuardTests : UnitTestsBase
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
		public void PromoteToAdminAsync_ShouldThrowPCShopExceptionWhenTheGivenUsedIdIsInvalid()
		{
			var userId = "invalid";

			var ex = Assert.ThrowsAsync<PCShopException>(async () => await this.adminUserService.PromoteToAdminAsync(userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidUserId));
		}
	}
}
