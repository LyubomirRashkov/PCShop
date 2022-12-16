using PCShop.Core.Exceptions;
using PCShop.Core.Models.Microphone;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Tests.UnitTests;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;

namespace PCShop.Tests.IntegrationTests
{
	[TestFixture]
	public class MicrophoneServiceGuardTests : UnitTestsBase
	{
		private IRepository repository;
		private IGuard guard;
		private IMicrophoneService microphoneService;

		[OneTimeSetUp]
		public void SetUp()
		{
			this.repository = new Repository(this.data);
			this.guard = new Guard();

			this.microphoneService = new MicrophoneService(this.repository, this.guard);
		}

		[Test]
		public void AddMicrophoneAsync_ShouldThrowPCShopExceptionWithTheCorrectMessageWhenInvalidUserIdIsGiven()
		{
			var microphone = new MicrophoneImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				Brand = "NewBrand",
				Color = null,
			};

			var userId = "invalid";

			var ex = Assert.ThrowsAsync<PCShopException>(async () => await this.microphoneService.AddMicrophoneAsync(microphone, userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidUserId));
		}

		[Test]
		public void DeleteMicrophoneAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenInvalidMicrophoneIdIsGiven()
		{
			var microphoneId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.microphoneService.DeleteMicrophoneAsync(microphoneId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public async Task DeleteMicrophoneAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenMicrophoneIdIsOfAMicrophoneThatIsAlreadyDeleted()
		{
			var microphone = new MicrophoneImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				Brand = "NewBrand",
				Color = null,
			};

			var userId = this.data.Users.FirstOrDefault()?.Id;

			var microphoneId = await this.microphoneService.AddMicrophoneAsync(microphone, userId);

			var addedMicrophone = this.data.Microphones.First(m => m.Id == microphoneId);

			await this.microphoneService.DeleteMicrophoneAsync(microphoneId);

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.microphoneService.DeleteMicrophoneAsync(microphoneId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForDeletedProduct));

			addedMicrophone.IsDeleted = false;
		}

		[Test]
		public void EditMicrophoneAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenInvalidMicrophoneIdIsGiven()
		{
			var microphoneOrigin = this.data.Microphones.First();

			var microphone = new MicrophoneEditViewModel()
			{
				Id = int.MinValue,
				ImageUrl = microphoneOrigin.ImageUrl,
				Warranty = microphoneOrigin.Warranty,
				Price = microphoneOrigin.Price,
				Quantity = microphoneOrigin.Quantity,
				Brand = microphoneOrigin.Brand.Name,
				Color = microphoneOrigin.Color?.Name,
				Seller = microphoneOrigin.Seller,
			};

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.microphoneService.EditMicrophoneAsync(microphone));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetMicrophoneByIdAsMicrophoneDetailsExportViewModelAsync_ShouldThrowAnArgumentExceptionWithTheCorrectMessageWhenThereIsNoMicrophoneWithTheGivenId()
		{
			var microphoneId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.microphoneService.GetMicrophoneByIdAsMicrohoneDetailsExportViewModelAsync(microphoneId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetMicrophoneByIdAsMicrophoneEditViewModelAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenMicrophoneIdIsNotValid()
		{
			var microphoneId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.microphoneService.GetMicrophoneByIdAsMicrophoneEditViewModelAsync(microphoneId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetUserMicrophonesAsync_ShouldThrowAPCShopExceptionWithTheCorrectMessageWhenThereIsNoClientWithTheGivenUserId()
		{
			var userId = "invalid";

			var ex = Assert.ThrowsAsync<PCShopException>(async () => await this.microphoneService.GetUserMicrophonesAsync(userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidUserId));
		}

		[Test]
		public void MarkMicrophoneAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenMicrophoneIdIsNotValid()
		{
			var microphoneId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.microphoneService.MarkMicrophoneAsBoughtAsync(microphoneId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public async Task MarkMicrophoneAsBought_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenMirophoneWithTheGivenMicrophoneIdIsAlreadyDeleted()
		{
			var microphone = this.data.Microphones.First();

			await this.microphoneService.DeleteMicrophoneAsync(microphone.Id);

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.microphoneService.MarkMicrophoneAsBoughtAsync(microphone.Id));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForDeletedProduct));

			microphone.IsDeleted = false;
		}

		[Test]
		public void MarkMicrophoneAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenMicrophoneWithTheGivenMicrophoneIdIsOutOfStock()
		{
			var microphone = this.data.Microphones.First();

			int realQuantity = microphone.Quantity;

			microphone.Quantity = 0;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.microphoneService.MarkMicrophoneAsBoughtAsync(microphone.Id));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForProductThatIsOutOfStock));

			microphone.Quantity = realQuantity;
		}
	}
}
