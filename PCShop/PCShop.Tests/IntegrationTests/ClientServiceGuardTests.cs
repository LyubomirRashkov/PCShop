using PCShop.Core.Exceptions;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Tests.UnitTests;
using static PCShop.Core.Constants.Constant.ClientConstants;

namespace PCShop.Tests.IntegrationTests
{
	[TestFixture]
	public class ClientServiceGuardTests : UnitTestsBase
	{
		private IRepository repository;
		private IGuard guard;
		private IClientService clientService;

		[OneTimeSetUp]
		public void SetUp()
		{
			this.repository = new Repository(this.data);
			this.guard = new Guard();

			this.clientService = new ClientService(this.repository, this.guard);
		}

		[Test]
		public void GetNumberOfActiveSales_ShouldThrowPCShopExceptionWhenThereIsNoClientWithTheGivenUserIdInTheDb()
		{
			var userId = "invalid";

			var ex = Assert.ThrowsAsync<PCShopException>(async () => await this.clientService.GetNumberOfActiveSales(userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidUserId));
		}
	}
}
