using PCShop.Core.Exceptions;
using PCShop.Core.Models.Laptop;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Tests.UnitTests;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;

namespace PCShop.Tests.IntegrationTests
{
	[TestFixture]
	public class LaptopServiceGuardTests : UnitTestsBase
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

		[Test]
		public void AddLaptopAsync_ShouldThrowPCShopExceptionWithTheCorrectMessageWhenInvalidUserIdIsGiven()
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

			var userId = "invalid";

			var ex = Assert.ThrowsAsync<PCShopException>(async () => await this.laptopService.AddLaptopAsync(laptop, userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidUserId));
		}

		[Test]
		public void DeleteLaptopAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenInvalidLaptopIdIsGiven()
		{
			var laptopId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.laptopService.DeleteLaptopAsync(laptopId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public async Task DeleteLaptopAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenLaptopIdIsOfALaptopThatIsAlreadyDeleted()
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

			await this.laptopService.DeleteLaptopAsync(laptopId);

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.laptopService.DeleteLaptopAsync(laptopId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForDeletedProduct));

			addedLaptop.IsDeleted = false;
		}

		[Test]
		public void EditLaptopAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenInvalidLaptopIdIsGiven()
		{
			var laptopOrigin = this.data.Laptops.First();

			var laptop = new LaptopEditViewModel()
			{
				Id = int.MinValue,
				ImageUrl = laptopOrigin.ImageUrl,
				Warranty = laptopOrigin.Warranty,
				Price = laptopOrigin.Price,
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

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.laptopService.EditLaptopAsync(laptop));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetLaptopByIdAsLaptopDetailsExportViewModelAsync_ShouldThrowAnArgumentExceptionWithTheCorrectMessageWhenThereIsNoLaptopWithTheGivenId()
		{
			var laptopId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.laptopService.GetLaptopByIdAsLaptopDetailsExportViewModelAsync(laptopId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetLaptopByIdAsLaptopEditViewModelAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenLaptopIdIsNotValid()
		{
			var laptopId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.laptopService.GetLaptopByIdAsLaptopEditViewModelAsync(laptopId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetUserLaptopsAsync_ShouldThrowAPCShopExceptionWithTheCorrectMessageWhenThereIsNoClientWithTheGivenUserId()
		{
			var userId = "invalid";

			var ex = Assert.ThrowsAsync<PCShopException>(async () => await this.laptopService.GetUserLaptopsAsync(userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidUserId));
		}

		[Test]
		public void MarkLaptopAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenLaptopIdIsNotValid()
		{
			var laptopId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.laptopService.MarkLaptopAsBoughtAsync(laptopId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public async Task MarkLaptopAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenLaptopWithTheGivenLaptopIdIsAlreadyDeleted()
		{
			var laptop = this.data.Laptops.First();

			await this.laptopService.DeleteLaptopAsync(laptop.Id);

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.laptopService.MarkLaptopAsBoughtAsync(laptop.Id));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForDeletedProduct));

			laptop.IsDeleted = false;
		}

		[Test]
		public void MarkLaptopAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenLaptopWithTheGivenLaptopIdIsOutOfStock()
		{
			var laptop = this.data.Laptops.First();

			int realQuantity = laptop.Quantity;

			laptop.Quantity = 0;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.laptopService.MarkLaptopAsBoughtAsync(laptop.Id));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForProductThatIsOutOfStock));

			laptop.Quantity = realQuantity;
		}
	}
}
