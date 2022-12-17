using Microsoft.AspNetCore.Identity;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Data.Models.Account;
using PCShop.Tests.Mocks;
using static PCShop.Core.Constants.Constant.ClientConstants;

namespace PCShop.Tests.UnitTests
{
	[TestFixture]
	public class UserServiceTests : UnitTestsBase
	{
		private UserManager<User> userManager;
		private SignInManager<User> signInManager;
		private IUserService userService;

		[OneTimeSetUp]
		public void SetUp()
		{
			this.userManager = UserManagerMock.MockUserManager(this.data.Users.ToList());
			this.signInManager = SignInManagerMock.MockSignInManager();

			this.userService = new UserService(this.userManager, this.signInManager);
		}

		[Test]
		public async Task ShouldBePromotedToSuperUser_ShouldReturnTrueWhenCountOfPurchasesOfTheClientIsEqualToRequiredNumberOfPurchasesToBeSuperUser()
		{
			var client = this.data.Clients.First();

			var clientCountOfPurchases = client.CountOfPurchases;

			client.CountOfPurchases = RequiredNumberOfPurchasesToBeSuperUser;

			var result = await this.userService.ShouldBePromotedToSuperUser(client);

			Assert.That(result, Is.True);

			client.CountOfPurchases = clientCountOfPurchases;
		}

		[Test]
		public async Task ShouldBePromotedToSuperUser_ShouldReturnFalseWhenCountOfPurchasesOfTheClientIsNotEqualToRequiredNumberOfPurchasesToBeSuperUser()
		{
			var client = this.data.Clients.First();

			var result = await this.userService.ShouldBePromotedToSuperUser(client);

			Assert.That(result, Is.False);
		}
	}
}
