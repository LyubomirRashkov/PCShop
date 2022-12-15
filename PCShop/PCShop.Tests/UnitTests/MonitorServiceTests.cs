using PCShop.Core.Constants;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Laptop;
using PCShop.Core.Models.Monitor;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using System.Globalization;

namespace PCShop.Tests.UnitTests
{
	[TestFixture]
	public class MonitorServiceTests : UnitTestsBase
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

		[TestCase(null, null, null)]
		[TestCase("NewDC", "NewDT", "NewColor")]
		public async Task AddMonitorAsync_ShouldAddMonitor(
			string? displayCoverage,
			string? displayTechnology,
			string? color)
		{
			var countOfMonitorsInDbBeforeAddition = this.data.Monitors.Count();

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
				DisplayCoverage = displayCoverage,
				DisplayTechnology = displayTechnology,
				Color = color,
			};

			var userId = this.data.Users.FirstOrDefault()?.Id;

			var monitorId = await this.monitorService.AddMonitorAsync(monitor, userId);

			var countOfMonitorsInDbAfterAddition = this.data.Monitors.Count();

			Assert.That(countOfMonitorsInDbAfterAddition, Is.EqualTo(countOfMonitorsInDbBeforeAddition + 1));

			var monitorInDb = this.data.Monitors.First(m => m.Id == monitorId);

			Assert.Multiple(() =>
			{
				Assert.That(monitorInDb, Is.Not.Null);

				Assert.That(monitorInDb.ImageUrl, Is.Null);
				Assert.That(monitorInDb.Warranty, Is.EqualTo(monitor.Warranty));
				Assert.That(monitorInDb.Price, Is.EqualTo(monitor.Price));
				Assert.That(monitorInDb.Quantity, Is.EqualTo(monitor.Quantity));
				Assert.That(monitorInDb.Brand.Name, Is.EqualTo(monitor.Brand));
				Assert.That(monitorInDb.DisplaySize.Value, Is.EqualTo(monitor.DisplaySize));
				Assert.That(monitorInDb.Resolution.Value, Is.EqualTo(monitor.Resolution));
				Assert.That(monitorInDb.RefreshRate.Value, Is.EqualTo(monitor.RefreshRate));
				Assert.That(monitorInDb.Type.Name, Is.EqualTo(monitor.Type));
				Assert.That(monitorInDb.DisplayCoverage?.Name, Is.EqualTo(displayCoverage));
				Assert.That(monitorInDb.DisplayTechnology?.Name, Is.EqualTo(displayTechnology));
				Assert.That(monitorInDb.Color?.Name, Is.EqualTo(color));
			});
		}

		[Test]
		public async Task DeleteMonitorAsync_ShouldMarkTheSpecifiedMonitorAsDeleted()
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

			Assert.That(addedMonitor.IsDeleted, Is.False);

			await this.monitorService.DeleteMonitorAsync(monitorId);

			Assert.That(addedMonitor.IsDeleted, Is.True);

			addedMonitor.IsDeleted = false;
		}

		[Test]
		public async Task EditMonitorAsync_ShouldEditMonitorCorrectly()
		{
			var monitorOrigin = this.data.Monitors.First();

			var newPrice = monitorOrigin.Price + 1000;

			var monitor = new MonitorEditViewModel()
			{
				Id = monitorOrigin.Id,
				ImageUrl = monitorOrigin.ImageUrl,
				Warranty = monitorOrigin.Warranty,
				Price = newPrice,
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

			var editedMonitorId = await this.monitorService.EditMonitorAsync(monitor);

			var editedMonitorInDb = this.data.Monitors.First(m => m.Id == editedMonitorId);

			Assert.Multiple(() =>
			{
				Assert.That(editedMonitorInDb, Is.Not.Null);

				Assert.That(editedMonitorInDb.Price, Is.EqualTo(newPrice));

				Assert.That(editedMonitorInDb.ImageUrl, Is.EqualTo(monitorOrigin.ImageUrl));
				Assert.That(editedMonitorInDb.Warranty, Is.EqualTo(monitorOrigin.Warranty));
				Assert.That(editedMonitorInDb.Quantity, Is.EqualTo(monitorOrigin.Quantity));
				Assert.That(editedMonitorInDb.Brand.Name, Is.EqualTo(monitorOrigin.Brand.Name));
				Assert.That(editedMonitorInDb.DisplaySize.Value, Is.EqualTo(monitorOrigin.DisplaySize.Value));
				Assert.That(editedMonitorInDb.Resolution.Value, Is.EqualTo(monitorOrigin.Resolution.Value));
				Assert.That(editedMonitorInDb.RefreshRate.Value, Is.EqualTo(monitorOrigin.RefreshRate.Value));
				Assert.That(editedMonitorInDb.Type.Name, Is.EqualTo(monitorOrigin.Type.Name));
				Assert.That(editedMonitorInDb.DisplayCoverage?.Name, Is.EqualTo(monitorOrigin.DisplayCoverage?.Name));
				Assert.That(editedMonitorInDb.DisplayTechnology?.Name, Is.EqualTo(monitorOrigin.DisplayTechnology?.Name));
				Assert.That(editedMonitorInDb.Color?.Name, Is.EqualTo(monitorOrigin.Color?.Name));
				Assert.That(editedMonitorInDb.Seller, Is.EqualTo(monitorOrigin.Seller));
			});
		}

		[Test]
		public async Task GetAllBrandsNamesAsync_ShouldReturnCorrectBrandsNames()
		{
			var result = await this.monitorService.GetAllBrandsNamesAsync();

			var expectedCount = this.data.Brands.Count();
			Assert.That(result.Count(), Is.EqualTo(expectedCount));

			var expected = this.data.Brands.Select(x => x.Name).OrderBy(x => x).ToList();
			Assert.That(expected.SequenceEqual<string>(result));
		}

		[Test]
		public async Task GetAllDisplaysSizesValuesAsync_ShouldReturnCorrectDisplaySizesValues()
		{
			var result = await this.monitorService.GetAllDisplaysSizesValuesAsync();

			var expectedCount = this.data.DisplaySizes.Count();
			Assert.That(result.Count(), Is.EqualTo(expectedCount));

			var expected = this.data.DisplaySizes.Select(x => x.Value).OrderBy(x => x).ToList();
			Assert.That(expected.SequenceEqual<double>(result));
		}

		[Test]
		public async Task GetAllMonitorsAsync_ShouldReturnAllMonitorsWhenThereAreNoSearchingParameters()
		{
			var result = await this.monitorService.GetAllMonitorsAsync();

			var expectedCount = this.data.Monitors.Count();
			Assert.That(result.TotalMonitorsCount, Is.EqualTo(expectedCount));
		}

		[Test]
		public async Task GetAllMonitorsAsync_ShouldReturnCorrectMonitorsAccordingToTheSearchingParameters()
		{
			var brandName = this.data.Brands.First().Name;
			var displaySizeValue = this.data.DisplaySizes.First().Value;
			var resolutionValue = this.data.Resolutions.First().Value;
			var refreshRateValue = this.data.RefreshRates.First().Value;
			var keyword = "1";
			var sorting = Sorting.PriceMaxToMin;

			var result = await this.monitorService.GetAllMonitorsAsync(
				brandName,
				displaySizeValue,
				resolutionValue,
				refreshRateValue,
				keyword,
				sorting);

			var expected = this.data.Monitors
				.Where(m => m.Brand.Name == brandName
							&& m.DisplaySize.Value == displaySizeValue
							&& m.Resolution.Value == resolutionValue
							&& m.RefreshRate.Value == refreshRateValue)
				.Where(m => m.Brand.Name.Contains(keyword)
							|| m.Type.Name.Contains(keyword)
							|| (m.DisplayCoverage != null && m.DisplayCoverage.Name.Contains(keyword))
							|| (m.DisplayTechnology != null && m.DisplayTechnology.Name.Contains(keyword)))
				.OrderByDescending(m => m.Price)
				.ToList();

			Assert.That(result.TotalMonitorsCount, Is.EqualTo(expected.Count));
		}

		[Test]
		public async Task GetAllMonitorsAsync_ShouldReturnEmptyCollectionWhenThereIsNoMonitorAccordingToTheSpecifiedCriteria()
		{
			var brandName = "invalid";

			var result = await this.monitorService.GetAllMonitorsAsync(brandName);

			Assert.That(result.TotalMonitorsCount, Is.Zero);
		}

		[Test]
		public async Task GetAllRefreshRatesValuesAsync_ShouldReturnCorrectRefreshRatesValues()
		{
			var result = await this.monitorService.GetAllRefreshRatesValuesAsync();

			var expectedCount = this.data.RefreshRates.Count();
			Assert.That(result.Count(), Is.EqualTo(expectedCount));

			var expected = this.data.RefreshRates.Select(x => x.Value).OrderBy(x => x).ToList();
			Assert.That(expected.SequenceEqual<int>(result));
		}

		[Test]
		public async Task GetAllResolutionsValuesAsync_ShouldReturnCorrectResolutionsValues()
		{
			var result = await this.monitorService.GetAllResolutionsValuesAsync();

			var expectedCount = this.data.Resolutions.Count();
			Assert.That(result.Count(), Is.EqualTo(expectedCount));

			var expected = this.data.Resolutions.Select(x => x.Value).OrderBy(x => x).ToList();
			Assert.That(expected.SequenceEqual<string>(result));
		}

		[Test]
		public async Task GetMonitorByIdAsMonitorDetailsExportViewModelAsync_ShouldReturnTheCorrectMonitor()
		{
			var monitorId = this.data.Monitors.First().Id;

			var result = await this.monitorService.GetMonitorByIdAsMonitorDetailsExportViewModelAsync(monitorId);

			var expected = this.data.Monitors.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(result.Id, Is.EqualTo(expected.Id));
				Assert.That(result.Brand, Is.EqualTo(expected.Brand.Name));
				Assert.That(result.Price, Is.EqualTo(expected.Price));
				Assert.That(result.Warranty, Is.EqualTo(expected.Warranty));
				Assert.That(result.DisplaySize, Is.EqualTo(expected.DisplaySize.Value));
				Assert.That(result.Resolution, Is.EqualTo(expected.Resolution.Value));
				Assert.That(result.RefreshRate, Is.EqualTo(expected.RefreshRate.Value));
				Assert.That(result.Type, Is.EqualTo(expected.Type.Name));
				Assert.That(result.ImageUrl, Is.EqualTo(expected.ImageUrl));
				Assert.That(result.AddedOn, Is.EqualTo(expected.AddedOn.ToString("MMMM, yyyy", CultureInfo.InvariantCulture)));
				Assert.That(result.Quantity, Is.EqualTo(expected.Quantity));
				Assert.That(result.Seller, Is.EqualTo(expected.Seller));
			});
		}

		[Test]
		public async Task GetMonitorByIdAsMonitorEditViewModelAsync_ShouldReturnCorrectMonitor()
		{
			var monitorId = this.data.Monitors.First().Id;

			var result = await this.monitorService.GetMonitorByIdAsMonitorEditViewModelAsync(monitorId);

			var expected = this.data.Monitors.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(result.Id, Is.EqualTo(expected.Id));
				Assert.That(result.Brand, Is.EqualTo(expected.Brand.Name));
				Assert.That(result.DisplaySize, Is.EqualTo(expected.DisplaySize.Value));
				Assert.That(result.Resolution, Is.EqualTo(expected.Resolution.Value));
				Assert.That(result.RefreshRate, Is.EqualTo(expected.RefreshRate.Value));
				Assert.That(result.Type, Is.EqualTo(expected.Type.Name));
				Assert.That(result.Quantity, Is.EqualTo(expected.Quantity));
				Assert.That(result.Price, Is.EqualTo(expected.Price));
				Assert.That(result.Warranty, Is.EqualTo(expected.Warranty));
				Assert.That(result.ImageUrl, Is.EqualTo(expected.ImageUrl));
				Assert.That(result.Seller, Is.EqualTo(expected.Seller));
			});
		}

		[Test]
		public async Task GetUserMonitorsAsync_ShouldReturnOnlyMonitorsThatHaveSellerIdEqualToTheClientIdOfTheClientWithTheGivenUserId()
		{
			var userId = this.data.Users.First().Id;

			var result = await this.monitorService.GetUserMonitorsAsync(userId);

			var resultFirst = result.First();

			var clientId = this.data.Clients.FirstOrDefault(c => c.UserId == userId)?.Id;

			var expected = this.data.Monitors.Where(m => m.SellerId == clientId);

			var expectedFirst = expected.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(resultFirst, Is.Not.Null);

				Assert.That(resultFirst.Id, Is.EqualTo(expectedFirst.Id));
				Assert.That(resultFirst.Brand, Is.EqualTo(expectedFirst.Brand.Name));
				Assert.That(resultFirst.Price, Is.EqualTo(expectedFirst.Price));
				Assert.That(resultFirst.Warranty, Is.EqualTo(expectedFirst.Warranty));
				Assert.That(resultFirst.DisplaySize, Is.EqualTo(expectedFirst.DisplaySize.Value));
				Assert.That(resultFirst.Resolution, Is.EqualTo(expectedFirst.Resolution.Value));
				Assert.That(resultFirst.RefreshRate, Is.EqualTo(expectedFirst.RefreshRate.Value));
				Assert.That(resultFirst.Type, Is.EqualTo(expectedFirst.Type.Name));
				Assert.That(resultFirst.ImageUrl, Is.EqualTo(expectedFirst.ImageUrl));
				Assert.That(resultFirst.AddedOn, Is.EqualTo(expectedFirst.AddedOn.ToString("MMMM, yyyy", CultureInfo.InvariantCulture)));
				Assert.That(resultFirst.Quantity, Is.EqualTo(expectedFirst.Quantity));
			});
		}

		[Test]
		public async Task MarkMonitorAsBoughtAsync_ShouldDecreaseMonitorQuantityWhenGivenMonitorIdIsValid()
		{
			var monitor = this.data.Monitors.First();

			var monitorQuantityBeforeBuying = monitor.Quantity;

			await this.monitorService.MarkMonitorAsBoughtAsync(monitor.Id);

			var monitorQuantityAfterBuying = monitor.Quantity;

			Assert.That(monitorQuantityAfterBuying, Is.EqualTo(monitorQuantityBeforeBuying - 1));
		}
	}
}
