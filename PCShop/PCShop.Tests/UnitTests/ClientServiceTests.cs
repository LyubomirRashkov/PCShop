using PCShop.Core.Exceptions;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;

namespace PCShop.Tests.UnitTests
{
	[TestFixture]
	public class ClientServiceTests : UnitTestsBase
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
		public async Task BuyProduct_ShouldIncreaseCountOfPurchasesWhenClientExistsInDb()
		{
			var client = this.data.Clients.First();

			var countOfPurchasesBeforeBuying = client.CountOfPurchases;

			await this.clientService.BuyProduct(client.UserId);

			var countOfPurchasesAfterBuying = client.CountOfPurchases;

			Assert.That(countOfPurchasesAfterBuying, Is.EqualTo(countOfPurchasesBeforeBuying + 1));
		}

		[Test]
		public async Task BuyProduct_ShouldCreateClientAndThenIncreaseItsCountOfPurchasesWhenClientDoesNotExistInDb()
		{
			var clientsCountBefore = this.data.Clients.Count();

			var userId = this.data.Users.Last().Id;

			await this.clientService.BuyProduct(userId);

			var clientsCountAfter = this.data.Clients.Count();

			Assert.That(clientsCountAfter, Is.EqualTo(clientsCountBefore + 1));
		}

		[Test]
		public async Task GetNumberOfActiveSales_ShouldReturnCorrectNumberOfClientSalesWhenClientExistsInDb()
		{
			var userId = this.data.Users.First().Id;

			var result = await this.clientService.GetNumberOfActiveSales(userId);

			var dbClient = this.data.Clients.First(c => c.UserId == userId);

			var expected = dbClient.Laptops.Count 
						   + dbClient.Monitors.Count
						   + dbClient.Keyboards.Count 
						   + dbClient.Mice.Count 
						   + dbClient.Headphones.Count 
						   + dbClient.Microphones.Count;

			Assert.That(result, Is.EqualTo(expected));
		}
	}
}
