using PCShop.Core.Exceptions;
using PCShop.Core.Models.Headphone;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Tests.UnitTests;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;

namespace PCShop.Tests.IntegrationTests
{
	[TestFixture]
	public class HeadphoneServiceGuardTests : UnitTestsBase
	{
		private IRepository repository;
		private IGuard guard;
		private IHeadphoneService headphoneService;

		[OneTimeSetUp]
		public void SetUp()
		{
			this.repository = new Repository(this.data);
			this.guard = new Guard();

			this.headphoneService = new HeadphoneService(this.repository, this.guard);
		}

		[Test]
		public void AddHeadphoneAsync_ShouldThrowPCShopExceptionWithTheCorrectMessageWhenInvalidUserIdIsGiven()
		{
			var headphone = new HeadphoneImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				IsWireless = true,
				HasMicrophone = true,
				Brand = "NewBrand",
				Type = "NewType",
				Color = null,
			};

			var userId = "invalid";

			var ex = Assert.ThrowsAsync<PCShopException>(async () => await this.headphoneService.AddHeadphoneAsync(headphone, userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidUserId));
		}

		[Test]
		public void DeleteHeadphoneAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenInvalidHeadphoneIdIsGiven()
		{
			var headphoneId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.headphoneService.DeleteHeadphoneAsync(headphoneId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public async Task DeleteHeadphoneAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenHeadphoneIdIsOfAHeadphoneThatIsAlreadyDeleted()
		{
			var headphone = new HeadphoneImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				IsWireless = true,
				HasMicrophone = true,
				Brand = "NewBrand",
				Type = "NewType",
				Color = null,
			};

			var userId = this.data.Users.FirstOrDefault()?.Id;

			var headphoneId = await this.headphoneService.AddHeadphoneAsync(headphone, userId);

			var addedHeadphone = this.data.Headphones.First(h => h.Id == headphoneId);

			await this.headphoneService.DeleteHeadphoneAsync(headphoneId);

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.headphoneService.DeleteHeadphoneAsync(headphoneId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForDeletedProduct));

			addedHeadphone.IsDeleted = false;
		}

		[Test]
		public void EditHeadphoneAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenInvalidHeadphoneIdIsGiven()
		{
			var headphoneOrigin = this.data.Headphones.First();

			var headphone = new HeadphoneEditViewModel()
			{
				Id = int.MinValue,
				ImageUrl = headphoneOrigin.ImageUrl,
				Warranty = headphoneOrigin.Warranty,
				Price = headphoneOrigin.Price,
				Quantity = headphoneOrigin.Quantity,
				IsWireless = headphoneOrigin.IsWireless,
				HasMicrophone = headphoneOrigin.HasMicrophone,
				Brand = headphoneOrigin.Brand.Name,
				Type = headphoneOrigin.Type.Name,
				Color = headphoneOrigin.Color?.Name,
				Seller = headphoneOrigin.Seller,
			};

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.headphoneService.EditHeadphoneAsync(headphone));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetHeadphoneByIdAsHeadphoneDetailsExportViewModelAsync_ShouldThrowAnArgumentExceptionWithTheCorrectMessageWhenThereIsNoHeadphoneWithTheGivenId()
		{
			var headphoneId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.headphoneService.GetHeadphoneByIdAsHeadphoneDetailsExportViewModelAsync(headphoneId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetHeadphoneByIdAsHeadphoneEditViewModelAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenHeadphoneIdIsNotValid()
		{
			var headphoneId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.headphoneService.GetHeadphoneByIdAsHeadphoneEditViewModelAsync(headphoneId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetUserheadphonesAsync_ShouldThrowAPCShopExceptionWithTheCorrectMessageWhenThereIsNoClientWithTheGivenUserId()
		{
			var userId = "invalid";

			var ex = Assert.ThrowsAsync<PCShopException>(async () => await this.headphoneService.GetUserHeadphonesAsync(userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidUserId));
		}

		[Test]
		public void MarkHeadphoneAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenHeadphoneIdIsNotValid()
		{
			var headphoneId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.headphoneService.MarkHeadphoneAsBoughtAsync(headphoneId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public async Task MarkHeadphoneAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenHeadphoneWithTheGivenHeadphoneIdIsAlreadyDeleted()
		{
			var headphone = this.data.Headphones.First();

			await this.headphoneService.DeleteHeadphoneAsync(headphone.Id);

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.headphoneService.MarkHeadphoneAsBoughtAsync(headphone.Id));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForDeletedProduct));

			headphone.IsDeleted = false;
		}

		[Test]
		public void MarkHeadphoneAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenHeadphoneWithTheGivenHeadphoneIdIsOutOfStock()
		{
			var headphone = this.data.Headphones.First();

			int realQuantity = headphone.Quantity;

			headphone.Quantity = 0;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.headphoneService.MarkHeadphoneAsBoughtAsync(headphone.Id));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForProductThatIsOutOfStock));

			headphone.Quantity = realQuantity;
		}
	}
}
