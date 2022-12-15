using PCShop.Core.Exceptions;
using PCShop.Core.Models.Monitor;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Tests.UnitTests;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;

namespace PCShop.Tests.IntegrationTests
{
	[TestFixture]
	public class MonitorServiceGuardTests : UnitTestsBase
	{
		private IRepository repository;
		private IGuard guard;
		private IMonitorService monitorService;

		[OneTimeSetUp]
		public void SetUp()
		{
			this.repository = new Repository(this.data);
			this.guard = new Guard();

			this.monitorService = new MonitorService(this.repository, this.guard);
		}

		[Test]
		public void AddMonitorAsync_ShouldThrowPCShopExceptionWithTheCorrectMessageWhenInvalidUserIdIsGiven()
		{
			var monitor = new MonitorImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				Brand = "NewBrand",
				DisplaySize = 4,
				Resolution = "1111x1111",
				RefreshRate = 4,
				Type = "NewType",
				DisplayCoverage = null,
				DisplayTechnology = null,
				Color = null,
			};

			var userId = "invalid";

			var ex = Assert.ThrowsAsync<PCShopException>(async () => await this.monitorService.AddMonitorAsync(monitor, userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidUserId));
		}

		[Test]
		public void DeleteMonitorAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenInvalidMonitorIdIsGiven()
		{
			var monitorId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.monitorService.DeleteMonitorAsync(monitorId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public async Task DeleteMonitorAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenMonitorIdIsOfAMonitorThatIsAlreadyDeleted()
		{
			var monitor = new MonitorImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				Brand = "NewBrand",
				DisplaySize = 4,
				Resolution = "1111x1111",
				RefreshRate = 4,
				Type = "NewType",
				DisplayCoverage = null,
				DisplayTechnology = null,
				Color = null,
			};

			var userId = this.data.Users.FirstOrDefault()?.Id;

			var monitorId = await this.monitorService.AddMonitorAsync(monitor, userId);

			var addedMonitor = this.data.Monitors.First(m => m.Id == monitorId);

			await this.monitorService.DeleteMonitorAsync(monitorId);

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.monitorService.DeleteMonitorAsync(monitorId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForDeletedProduct));

			addedMonitor.IsDeleted = false;
		}

		[Test]
		public void EditMonitorAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenInvalidMonitorIdIsGiven()
		{
			var monitorOrigin = this.data.Monitors.First();

			var monitor = new MonitorEditViewModel()
			{
				Id = int.MinValue,
				ImageUrl = monitorOrigin.ImageUrl,
				Warranty = monitorOrigin.Warranty,
				Price = monitorOrigin.Price,
				Quantity = monitorOrigin.Quantity,
				Brand = monitorOrigin.Brand.Name,
				DisplaySize = monitorOrigin.DisplaySize.Value,
				Resolution = monitorOrigin.Resolution.Value,
				RefreshRate = monitorOrigin.RefreshRate.Value,
				Type = monitorOrigin.Type.Name,
				DisplayCoverage = monitorOrigin.DisplayCoverage?.Name,
				DisplayTechnology = monitorOrigin.DisplayTechnology?.Name,
				Color = monitorOrigin.Color?.Name,
				Seller = monitorOrigin.Seller,
			};

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.monitorService.EditMonitorAsync(monitor));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetMonitorByIdAsMonitorDetailsExportViewModelAsync_ShouldThrowAnArgumentExceptionWithTheCorrectMessageWhenThereIsNoMonitorWithTheGivenId()
		{
			var monitorId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.monitorService.GetMonitorByIdAsMonitorDetailsExportViewModelAsync(monitorId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetMonitorByIdAsMonitorEditViewModelAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenMonitorIdIsNotValid()
		{
			var monitorId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.monitorService.GetMonitorByIdAsMonitorEditViewModelAsync(monitorId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetUserMonitorsAsync_ShouldThrowAPCShopExceptionWithTheCorrectMessageWhenThereIsNoClientWithTheGivenUserId()
		{
			var userId = "invalid";

			var ex = Assert.ThrowsAsync<PCShopException>(async () => await this.monitorService.GetUserMonitorsAsync(userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidUserId));
		}

		[Test]
		public void MarkMonitorAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenMonitorIdIsNotValid()
		{
			var monitorId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.monitorService.MarkMonitorAsBoughtAsync(monitorId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public async Task MarkMonitorAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenMonitorWithTheGivenMonitorIdIsAlreadyDeleted()
		{
			var monitor = this.data.Monitors.First();

			await this.monitorService.DeleteMonitorAsync(monitor.Id);

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.monitorService.MarkMonitorAsBoughtAsync(monitor.Id));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForDeletedProduct));

			monitor.IsDeleted = false;
		}

		[Test]
		public void MarkMonitorAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenMonitorWithTheGivenMonitorIdIsOutOfStock()
		{
			var monitor = this.data.Monitors.First();

			int realQuantity = monitor.Quantity;

			monitor.Quantity = 0;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.monitorService.MarkMonitorAsBoughtAsync(monitor.Id));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForProductThatIsOutOfStock));

			monitor.Quantity = realQuantity;
		}
	}
}
