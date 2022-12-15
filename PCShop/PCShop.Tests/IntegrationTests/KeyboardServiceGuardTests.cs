using PCShop.Core.Exceptions;
using PCShop.Core.Models.Keyboard;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Tests.UnitTests;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;

namespace PCShop.Tests.IntegrationTests
{
	[TestFixture]
	public class KeyboardServiceGuardTests : UnitTestsBase
	{
		private IRepository repository;
		private IGuard guard;
		private IKeyboardService keyboardService;

		[OneTimeSetUp]
		public void SetUp()
		{
			this.repository = new Repository(this.data);
			this.guard = new Guard();

			this.keyboardService = new KeyboardService(this.repository, this.guard);
		}

		[Test]
		public void AddKeyboardAsync_ShouldThrowPCShopExceptionWithTheCorrectMessageWhenInvalidUserIdIsGiven()
		{
			var keyboard = new KeyboardImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				IsWireless = true,
				Brand = "NewBrand",
				Type = "NewType",
				Format = null,
				Color = null,
			};

			var userId = "invalid";

			var ex = Assert.ThrowsAsync<PCShopException>(async () => await this.keyboardService.AddKeyboardAsync(keyboard, userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidUserId));
		}

		[Test]
		public void DeleteKeyboardAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenInvalidKeyboardIdIsGiven()
		{
			var keyboardId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.keyboardService.DeleteKeyboardAsync(keyboardId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public async Task DeleteKeyboardAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenKeyboardIdIsOfAKeyboardThatIsAlreadyDeleted()
		{
			var keyboard = new KeyboardImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				IsWireless = true,
				Brand = "NewBrand",
				Type = "NewType",
				Format = null,
				Color = null,
			};

			var userId = this.data.Users.FirstOrDefault()?.Id;

			var keyboardId = await this.keyboardService.AddKeyboardAsync(keyboard, userId);

			var addedKeyboard = this.data.Keyboards.First(k => k.Id == keyboardId);

			await this.keyboardService.DeleteKeyboardAsync(keyboardId);

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.keyboardService.DeleteKeyboardAsync(keyboardId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForDeletedProduct));

			addedKeyboard.IsDeleted = false;
		}

		[Test]
		public void EditKeyboardAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenInvalidKeyboardIdIsGiven()
		{
			var keyboardOrigin = this.data.Keyboards.First();

			var keyboard = new KeyboardEditViewModel()
			{
				Id = int.MinValue,
				ImageUrl = keyboardOrigin.ImageUrl,
				Warranty = keyboardOrigin.Warranty,
				Price = keyboardOrigin.Price,
				Quantity = keyboardOrigin.Quantity,
				IsWireless = keyboardOrigin.IsWireless,
				Brand = keyboardOrigin.Brand.Name,
				Type = keyboardOrigin.Type.Name,
				Format = keyboardOrigin.Type.Name,
				Color = keyboardOrigin.Color?.Name,
				Seller = keyboardOrigin.Seller,
			};

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.keyboardService.EditKeyboardAsync(keyboard));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetKeyboardByIdAsKeyboardDetailsExportViewModelAsync_ShouldThrowAnArgumentExceptionWithTheCorrectMessageWhenThereIsNoKeyboardWithTheGivenId()
		{
			var keyboardId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.keyboardService.GetKeyboardByIdAsKeyboardDetailsExportViewModelAsync(keyboardId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetKeyboardByIdAsKeyboardEditViewModelAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenKeyboardIdIsNotValid()
		{
			var keyboardId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.keyboardService.GetKeyboardByIdAsKeyboardEditViewModelAsync(keyboardId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetUserKeyboardsAsync_ShouldThrowAPCShopExceptionWithTheCorrectMessageWhenThereIsNoClientWithTheGivenUserId()
		{
			var userId = "invalid";

			var ex = Assert.ThrowsAsync<PCShopException>(async () => await this.keyboardService.GetUserKeyboardsAsync(userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidUserId));
		}

		[Test]
		public void MarkKeyboardAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenKeyboardIdIsNotValid()
		{
			var keyboardId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.keyboardService.MarkKeyboardAsBoughtAsync(keyboardId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public async Task MarkKeyboardAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenKeyboardWithTheGivenKeyboardIdIsAlreadyDeleted()
		{
			var keyboard = this.data.Keyboards.First();

			await this.keyboardService.DeleteKeyboardAsync(keyboard.Id);

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.keyboardService.MarkKeyboardAsBoughtAsync(keyboard.Id));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForDeletedProduct));

			keyboard.IsDeleted = false;
		}

		[Test]
		public void MarkKeyboardAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenKeyboardWithTheGivenKeyboardIdIsOutOfStock()
		{
			var keyboard = this.data.Keyboards.First();

			int realQuantity = keyboard.Quantity;

			keyboard.Quantity = 0;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.keyboardService.MarkKeyboardAsBoughtAsync(keyboard.Id));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForProductThatIsOutOfStock));

			keyboard.Quantity = realQuantity;
		}
	}
}
