using PCShop.Core.Constants;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Laptop;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using System.Globalization;

namespace PCShop.Tests.UnitTests
{
	[TestFixture]
	public class LaptopServiceTests : UnitTestsBase
	{
		private IRepository repository;
		private IGuard guard;
		private ILaptopService laptopService;

		[OneTimeSetUp]
		public void SetUp()
		{
			this.repository = new Repository(this.data);
			this.guard = new Guard();

			this.laptopService = new LaptopService(this.repository, this.guard);
		}

		[TestCase(null, null, null, null)]
		[TestCase("NewDC", "NewDT", "1000x1000", "NewColor")]
		public async Task AddLaptopAsync_ShouldAddLaptop(
			string? displayCoverage,
			string? displayTechnology,
			string? resolution,
			string? color)
		{
			var countOfLaptopsInDbBeforeAddition = this.data.Laptops.Count();

			var laptop = new LaptopImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				Brand = "NewBrand",
				CPU = "NewCPU",
				RAM = 4,
				SSDCapacity = 4,
				VideoCard = "NewVideoCard",
				Type = "NewType",
				DisplaySize = 4,
				DisplayCoverage = displayCoverage,
				DisplayTechnology = displayTechnology,
				Resolution = resolution,
				Color = color,
			};

			var userId = this.data.Users.FirstOrDefault()?.Id;

			var laptopId = await this.laptopService.AddLaptopAsync(laptop, userId);

			var countOfLaptopsInDbAfterAddition = this.data.Laptops.Count();

			Assert.That(countOfLaptopsInDbAfterAddition, Is.EqualTo(countOfLaptopsInDbBeforeAddition + 1));

			var laptopInDb = this.data.Laptops.First(l => l.Id == laptopId);

			Assert.Multiple(() =>
			{
				Assert.That(laptopInDb, Is.Not.Null);

				Assert.That(laptopInDb.ImageUrl, Is.Null);
				Assert.That(laptopInDb.Warranty, Is.EqualTo(laptop.Warranty));
				Assert.That(laptopInDb.Price, Is.EqualTo(laptop.Price));
				Assert.That(laptopInDb.Quantity, Is.EqualTo(laptop.Quantity));
				Assert.That(laptopInDb.Brand.Name, Is.EqualTo(laptop.Brand));
				Assert.That(laptopInDb.CPU.Name, Is.EqualTo(laptop.CPU));
				Assert.That(laptopInDb.RAM.Value, Is.EqualTo(laptop.RAM));
				Assert.That(laptopInDb.SSDCapacity.Value, Is.EqualTo(laptop.SSDCapacity));
				Assert.That(laptopInDb.VideoCard.Name, Is.EqualTo(laptop.VideoCard));
				Assert.That(laptopInDb.Type.Name, Is.EqualTo(laptop.Type));
				Assert.That(laptopInDb.DisplaySize.Value, Is.EqualTo(laptop.DisplaySize));
				Assert.That(laptopInDb.DisplayCoverage?.Name, Is.EqualTo(displayCoverage));
				Assert.That(laptopInDb.DisplayTechnology?.Name, Is.EqualTo(displayTechnology));
				Assert.That(laptopInDb.Resolution?.Value, Is.EqualTo(resolution));
				Assert.That(laptopInDb.Color?.Name, Is.EqualTo(color));
			});
		}

		[Test]
		public async Task DeleteLaptopAsync_ShouldMarkTheSpecifiedLaptopAsDeleted()
		{
			var laptop = new LaptopImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				Brand = "NewBrand",
				CPU = "NewCPU",
				RAM = 4,
				SSDCapacity = 4,
				VideoCard = "NewVideoCard",
				Type = "NewType",
				DisplaySize = 4,
				DisplayCoverage = null,
				DisplayTechnology = null,
				Resolution = null,
				Color = null,
			};

			var userId = this.data.Users.FirstOrDefault()?.Id;

			var laptopId = await this.laptopService.AddLaptopAsync(laptop, userId);

			var addedLaptop = this.data.Laptops.First(l => l.Id == laptopId);

			Assert.That(addedLaptop.IsDeleted, Is.False);

			await this.laptopService.DeleteLaptopAsync(laptopId);

			Assert.That(addedLaptop.IsDeleted, Is.True);

			addedLaptop.IsDeleted = false;
		}

		[Test]
		public async Task EditLaptopAsync_ShouldEditLaptopCorrectly()
		{
			var laptopOrigin = this.data.Laptops.First();

			var newPrice = laptopOrigin.Price + 1000;

			var laptop = new LaptopEditViewModel()
			{
				Id = laptopOrigin.Id,
				ImageUrl = laptopOrigin.ImageUrl,
				Warranty = laptopOrigin.Warranty,
				Price = newPrice,
				Quantity = laptopOrigin.Quantity,
				Brand = laptopOrigin.Brand.Name,
				CPU = laptopOrigin.CPU.Name,
				RAM = laptopOrigin.RAM.Value,
				SSDCapacity = laptopOrigin.SSDCapacity.Value,
				VideoCard = laptopOrigin.VideoCard.Name,
				Type = laptopOrigin.Type.Name,
				DisplaySize = laptopOrigin.DisplaySize.Value,
				DisplayCoverage = laptopOrigin.DisplayCoverage?.Name,
				DisplayTechnology = laptopOrigin.DisplayTechnology?.Name,
				Resolution = laptopOrigin.Resolution?.Value,
				Color = laptopOrigin.Color?.Name,
				Seller = laptopOrigin.Seller,
			};

			var editedLaptopId = await this.laptopService.EditLaptopAsync(laptop);

			var editedLaptopInDb = this.data.Laptops.First(l => l.Id == editedLaptopId);

			Assert.Multiple(() =>
			{
				Assert.That(editedLaptopInDb, Is.Not.Null);

				Assert.That(editedLaptopInDb.Price, Is.EqualTo(newPrice));

				Assert.That(editedLaptopInDb.ImageUrl, Is.EqualTo(laptopOrigin.ImageUrl));
				Assert.That(editedLaptopInDb.Warranty, Is.EqualTo(laptopOrigin.Warranty));
				Assert.That(editedLaptopInDb.Quantity, Is.EqualTo(laptopOrigin.Quantity));
				Assert.That(editedLaptopInDb.Brand.Name, Is.EqualTo(laptopOrigin.Brand.Name));
				Assert.That(editedLaptopInDb.CPU.Name, Is.EqualTo(laptopOrigin.CPU.Name));
				Assert.That(editedLaptopInDb.RAM.Value, Is.EqualTo(laptopOrigin.RAM.Value));
				Assert.That(editedLaptopInDb.SSDCapacity.Value, Is.EqualTo(laptopOrigin.SSDCapacity.Value));
				Assert.That(editedLaptopInDb.VideoCard.Name, Is.EqualTo(laptopOrigin.VideoCard.Name));
				Assert.That(editedLaptopInDb.Type.Name, Is.EqualTo(laptopOrigin.Type.Name));
				Assert.That(editedLaptopInDb.DisplaySize.Value, Is.EqualTo(laptopOrigin.DisplaySize.Value));
				Assert.That(editedLaptopInDb.DisplayCoverage?.Name, Is.EqualTo(laptopOrigin.DisplayCoverage?.Name));
				Assert.That(editedLaptopInDb.DisplayTechnology?.Name, Is.EqualTo(laptopOrigin.DisplayTechnology?.Name));
				Assert.That(editedLaptopInDb.Resolution?.Value, Is.EqualTo(laptopOrigin.Resolution?.Value));
				Assert.That(editedLaptopInDb.Color?.Name, Is.EqualTo(laptopOrigin.Color?.Name));
				Assert.That(editedLaptopInDb.Seller, Is.EqualTo(laptopOrigin.Seller));
			});
		}

		[Test]
		public async Task GetAllLaptopsAsync_ShouldReturnAllLaptopsWhenThereAreNoSearchingParameters()
		{
			var result = await this.laptopService.GetAllLaptopsAsync();

			var expectedCount = this.data.Laptops.Count();
			Assert.That(result.TotalLaptopsCount, Is.EqualTo(expectedCount));
		}

		[Test]
		public async Task GetAllLaptopsAsync_ShouldReturnCorrectLaptopsAccordingToTheSearchingParameters()
		{
			var cpuName = "CPU1";
			var ramValue = 1;
			var ssdCapacityValue = 1;
			var videoCardName = "VideoCard1";
			var keyword = "1";
			var sorting = Sorting.PriceMaxToMin;

			var result = await this.laptopService.GetAllLaptopsAsync(
				cpuName,
				ramValue,
				ssdCapacityValue,
				videoCardName,
				keyword,
				sorting);

			var expected = this.data.Laptops
				.Where(l => l.CPU.Name == cpuName
							&& l.RAM.Value == ramValue
							&& l.SSDCapacity.Value == ssdCapacityValue
							&& l.VideoCard.Name == videoCardName)
				.Where(l => l.Brand.Name.Contains(keyword)
							|| l.CPU.Name.Contains(keyword)
							|| l.VideoCard.Name.Contains(keyword)
							|| l.Type.Name.Contains(keyword))
				.OrderByDescending(l => l.Price)
				.ToList();

			Assert.That(result.TotalLaptopsCount, Is.EqualTo(expected.Count));
		}

		[Test]
		public async Task GetAllLaptopsAsync_ShouldReturnEmptyCollectionWhenThereIsNoLaptopAccordingToTheSpecifiedCriteria()
		{
			var cpuName = "InvalidCPU";

			var result = await this.laptopService.GetAllLaptopsAsync(cpuName);

			Assert.That(result.TotalLaptopsCount, Is.Zero);
		}

		[Test]
		public async Task GetLaptopByIdAsLaptopDetailsExportViewModelAsync_ShouldReturnTheCorrectLaptop()
		{
			var laptopId = this.data.Laptops.First().Id;

			var result = await this.laptopService.GetLaptopByIdAsLaptopDetailsExportViewModelAsync(laptopId);

			var expected = this.data.Laptops.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(result.Id, Is.EqualTo(expected.Id));
				Assert.That(result.Brand, Is.EqualTo(expected.Brand.Name));
				Assert.That(result.CPU, Is.EqualTo(expected.CPU.Name));
				Assert.That(result.RAM, Is.EqualTo(expected.RAM.Value));
				Assert.That(result.SSDCapacity, Is.EqualTo(expected.SSDCapacity.Value));
				Assert.That(result.VideoCard, Is.EqualTo(expected.VideoCard.Name));
				Assert.That(result.Price, Is.EqualTo(expected.Price));
				Assert.That(result.Type, Is.EqualTo(expected.Type.Name));
				Assert.That(result.DisplaySize, Is.EqualTo(expected.DisplaySize.Value));
				Assert.That(result.Warranty, Is.EqualTo(expected.Warranty));
				Assert.That(result.Quantity, Is.EqualTo(expected.Quantity));
				Assert.That(result.AddedOn, Is.EqualTo(expected.AddedOn.ToString("MMMM, yyyy", CultureInfo.InvariantCulture)));
			});
		}

		[Test]
		public async Task GetLaptopByIdAsLaptopEditViewModelAsync_ShouldReturnCorrectLaptop()
		{
			var laptopId = this.data.Laptops.First().Id;

			var result = await this.laptopService.GetLaptopByIdAsLaptopEditViewModelAsync(laptopId);

			var expected = this.data.Laptops.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(result.Id, Is.EqualTo(expected.Id));
				Assert.That(result.Brand, Is.EqualTo(expected.Brand.Name));
				Assert.That(result.CPU, Is.EqualTo(expected.CPU.Name));
				Assert.That(result.RAM, Is.EqualTo(expected.RAM.Value));
				Assert.That(result.SSDCapacity, Is.EqualTo(expected.SSDCapacity.Value));
				Assert.That(result.VideoCard, Is.EqualTo(expected.VideoCard.Name));
				Assert.That(result.Price, Is.EqualTo(expected.Price));
				Assert.That(result.Type, Is.EqualTo(expected.Type.Name));
				Assert.That(result.DisplaySize, Is.EqualTo(expected.DisplaySize.Value));
				Assert.That(result.Warranty, Is.EqualTo(expected.Warranty));
				Assert.That(result.Quantity, Is.EqualTo(expected.Quantity));
			});
		}

		[Test]
		public async Task GetUserLaptopsAsync_ShouldReturnOnlyLaptopsThatHaveSellerIdEqualToTheClientIdOfTheClientWithTheGivenUserId()
		{
			var userId = this.data.Users.First().Id;

			var result = await this.laptopService.GetUserLaptopsAsync(userId);

			var resultFirst = result.First();

			var clientId = this.data.Clients.FirstOrDefault(c => c.UserId == userId)?.Id;

			var expected = this.data.Laptops.Where(l => l.SellerId == clientId);

			var expectedFirst = expected.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(resultFirst, Is.Not.Null);

				Assert.That(resultFirst.Id, Is.EqualTo(expectedFirst.Id));
				Assert.That(resultFirst.Brand, Is.EqualTo(expectedFirst.Brand.Name));
				Assert.That(resultFirst.CPU, Is.EqualTo(expectedFirst.CPU.Name));
				Assert.That(resultFirst.RAM, Is.EqualTo(expectedFirst.RAM.Value));
				Assert.That(resultFirst.SSDCapacity, Is.EqualTo(expectedFirst.SSDCapacity.Value));

				Assert.That(resultFirst.VideoCard, Is.EqualTo(expectedFirst.VideoCard.Name));
				Assert.That(resultFirst.Price, Is.EqualTo(expectedFirst.Price));
				Assert.That(resultFirst.Type, Is.EqualTo(expectedFirst.Type.Name));
				Assert.That(resultFirst.DisplaySize, Is.EqualTo(expectedFirst.DisplaySize.Value));
				Assert.That(resultFirst.Warranty, Is.EqualTo(expectedFirst.Warranty));
				Assert.That(resultFirst.Quantity, Is.EqualTo(expectedFirst.Quantity));
				Assert.That(resultFirst.AddedOn, Is.EqualTo(expectedFirst.AddedOn.ToString("MMMM, yyyy", CultureInfo.InvariantCulture)));
			});
		}

		[Test]
		public async Task MarkLaptopAsBoughtAsync_ShouldDecreaseLaptopQuantityWhenGivenLaptopIdIsValid()
		{
			var laptop = this.data.Laptops.First();

			var laptopQuantityBeforeBuying = laptop.Quantity;

			await this.laptopService.MarkLaptopAsBoughtAsync(laptop.Id);

			var laptopQuantityAfterBuying = laptop.Quantity;

			Assert.That(laptopQuantityAfterBuying, Is.EqualTo(laptopQuantityBeforeBuying - 1));
		}

		[Test]
		public async Task GetAllCpusNamesAsync_ShouldReturnCorrectCpuNames()
		{
			var result = await this.laptopService.GetAllCpusNamesAsync();

			var expectedCount = this.data.CPUs.Count();
			Assert.That(result.Count(), Is.EqualTo(expectedCount));

			var expected = this.data.CPUs.Select(x => x.Name).OrderBy(x => x).ToList();
			Assert.That(expected.SequenceEqual<string>(result));
		}

		[Test]
		public async Task GetAllRamsValuesAsync_ShouldReturnCorrectRamValues()
		{
			var result = await this.laptopService.GetAllRamsValuesAsync();

			var expectedCount = this.data.RAMs.Count();
			Assert.That(result.Count(), Is.EqualTo(expectedCount));

			var expected = this.data.RAMs.Select(x => x.Value).OrderBy(x => x).ToList();
			Assert.That(expected.SequenceEqual<int>(result));
		}

		[Test]
		public async Task GetAllSsdCapacitiesValuesAsync_ShouldReturnCorrectSsdCapacityValues()
		{
			var result = await this.laptopService.GetAllSsdCapacitiesValuesAsync();

			var expectedCount = this.data.SSDCapacities.Count();
			Assert.That(result.Count(), Is.EqualTo(expectedCount));

			var expected = this.data.SSDCapacities.Select(x => x.Value).OrderBy(x => x).ToList();
			Assert.That(expected.SequenceEqual<int>(result));
		}

		[Test]
		public async Task GetAllVideoCardsNamesAsync_ShouldReturnCorrectVideoCardNames()
		{
			var result = await this.laptopService.GetAllVideoCardsNamesAsync();

			var expectedCount = this.data.VideoCards.Count();
			Assert.That(result.Count(), Is.EqualTo(expectedCount));

			var expected = this.data.VideoCards.Select(x => x.Name).OrderBy(x => x).ToList();
			Assert.That(expected.SequenceEqual<string>(result));
		}
	}
}
