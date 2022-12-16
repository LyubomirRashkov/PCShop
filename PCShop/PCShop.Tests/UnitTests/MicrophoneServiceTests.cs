using PCShop.Core.Constants;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Microphone;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using System.Globalization;

namespace PCShop.Tests.UnitTests
{
	[TestFixture]
	public class MicrophoneServiceTests : UnitTestsBase
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

		[TestCase(null)]
		[TestCase("NewColor")]
		public async Task AddMicrophoneAsync_ShouldAddMicrrophone(string? color)
		{
			var countOfMicrophonesInDbBeforeAddition = this.data.Microphones.Count();

			var microphone = new MicrophoneImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				Brand = "NewBrand",
				Color = color,
			};

			var userId = this.data.Users.FirstOrDefault()?.Id;

			var microphoneId = await this.microphoneService.AddMicrophoneAsync(microphone, userId);

			var countOfMicrophonesInDbAfterAddition = this.data.Microphones.Count();

			Assert.That(countOfMicrophonesInDbAfterAddition, Is.EqualTo(countOfMicrophonesInDbBeforeAddition + 1));

			var microphoneInDb = this.data.Microphones.First(m => m.Id == microphoneId);

			Assert.Multiple(() =>
			{
				Assert.That(microphoneInDb, Is.Not.Null);

				Assert.That(microphoneInDb.ImageUrl, Is.Null);
				Assert.That(microphoneInDb.Warranty, Is.EqualTo(microphone.Warranty));
				Assert.That(microphoneInDb.Price, Is.EqualTo(microphone.Price));
				Assert.That(microphoneInDb.Quantity, Is.EqualTo(microphone.Quantity));
				Assert.That(microphoneInDb.Brand.Name, Is.EqualTo(microphone.Brand));
				Assert.That(microphoneInDb.Color?.Name, Is.EqualTo(color));
			});
		}

		[Test]
		public async Task DeleteMicrophoneAsync_ShouldMarkTheSpecifiedMicrophoneAsDeleted()
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

			Assert.That(addedMicrophone.IsDeleted, Is.False);

			await this.microphoneService.DeleteMicrophoneAsync(microphoneId);

			Assert.That(addedMicrophone.IsDeleted, Is.True);

			addedMicrophone.IsDeleted = false;
		}

		[Test]
		public async Task EditMicrophoneAsync_ShouldEditMicrophoneCorrectly()
		{
			var microphoneOrigin = this.data.Microphones.First();

			var newPrice = microphoneOrigin.Price + 1000;

			var microphone = new MicrophoneEditViewModel()
			{
				Id = microphoneOrigin.Id,
				ImageUrl = microphoneOrigin.ImageUrl,
				Warranty = microphoneOrigin.Warranty,
				Price = newPrice,
				Quantity = microphoneOrigin.Quantity,
				Brand = microphoneOrigin.Brand.Name,
				Color = microphoneOrigin.Color?.Name,
				Seller = microphoneOrigin.Seller,
			};

			var editedMicrophoneId = await this.microphoneService.EditMicrophoneAsync(microphone);

			var editedMicrophoneInDb = this.data.Microphones.First(m => m.Id == editedMicrophoneId);

			Assert.Multiple(() =>
			{
				Assert.That(editedMicrophoneInDb, Is.Not.Null);

				Assert.That(editedMicrophoneInDb.Price, Is.EqualTo(newPrice));

				Assert.That(editedMicrophoneInDb.ImageUrl, Is.EqualTo(microphoneOrigin.ImageUrl));
				Assert.That(editedMicrophoneInDb.Warranty, Is.EqualTo(microphoneOrigin.Warranty));
				Assert.That(editedMicrophoneInDb.Quantity, Is.EqualTo(microphoneOrigin.Quantity));
				Assert.That(editedMicrophoneInDb.Brand.Name, Is.EqualTo(microphoneOrigin.Brand.Name));
				Assert.That(editedMicrophoneInDb.Color?.Name, Is.EqualTo(microphoneOrigin.Color?.Name));
				Assert.That(editedMicrophoneInDb.Seller, Is.EqualTo(microphoneOrigin.Seller));
			});
		}

		[Test]
		public async Task GetAllMicrophonesAsync_ShouldReturnAllMicrophonesWhenThereAreNoSearchingParameters()
		{
			var result = await this.microphoneService.GetAllMicrophonesAsync();

			var expectedCount = this.data.Microphones.Count();
			Assert.That(result.TotalMicrophonesCount, Is.EqualTo(expectedCount));
		}

		[Test]
		public async Task GetAllMicrophonesAsync_ShouldReturnCorrectMicrophonesAccordingToTheSearchingParameters()
		{
			var keyword = "1";
			var sorting = Sorting.PriceMaxToMin;

			var result = await this.microphoneService.GetAllMicrophonesAsync(keyword, sorting);

			var expected = this.data.Microphones
				.Where(m => m.Brand.Name.Contains(keyword))
				.OrderByDescending(m => m.Price)
				.ToList();

			Assert.That(result.TotalMicrophonesCount, Is.EqualTo(expected.Count));
		}

		[Test]
		public async Task GetAllMicrophonesAsync_ShouldReturnEmptyCollectionWhenThereIsNoMicrophoneAccordingToTheSpecifiedCriteria()
		{
			var brandName = "invalid";

			var result = await this.microphoneService.GetAllMicrophonesAsync(brandName);

			Assert.That(result.TotalMicrophonesCount, Is.Zero);
		}

		[Test]
		public async Task GetMicrophoneByIdAsMicrophoneDetailsExportViewModelAsync_ShouldReturnTheCorrectMicrophone()
		{
			var microphoneId = this.data.Microphones.First().Id;

			var result = await this.microphoneService.GetMicrophoneByIdAsMicrohoneDetailsExportViewModelAsync(microphoneId);

			var expected = this.data.Microphones.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(result.Id, Is.EqualTo(expected.Id));
				Assert.That(result.Brand, Is.EqualTo(expected.Brand.Name));
				Assert.That(result.Price, Is.EqualTo(expected.Price));
				Assert.That(result.ImageUrl, Is.EqualTo(expected.ImageUrl));
				Assert.That(result.Warranty, Is.EqualTo(expected.Warranty));
				Assert.That(result.Quantity, Is.EqualTo(expected.Quantity));
				Assert.That(result.AddedOn, Is.EqualTo(expected.AddedOn.ToString("MMMM, yyyy", CultureInfo.InvariantCulture)));
				Assert.That(result.Seller, Is.EqualTo(expected.Seller));
			});
		}

		[Test]
		public async Task GetMicrophoneByIdAsMicrophoneEditViewModelAsync_ShouldReturnCorrectMicrophone()
		{
			var microphoneId = this.data.Microphones.First().Id;

			var result = await this.microphoneService.GetMicrophoneByIdAsMicrophoneEditViewModelAsync(microphoneId);

			var expected = this.data.Microphones.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(result.Id, Is.EqualTo(expected.Id));
				Assert.That(result.Brand, Is.EqualTo(expected.Brand.Name));
				Assert.That(result.Quantity, Is.EqualTo(expected.Quantity));
				Assert.That(result.Price, Is.EqualTo(expected.Price));
				Assert.That(result.Warranty, Is.EqualTo(expected.Warranty));
				Assert.That(result.ImageUrl, Is.EqualTo(expected.ImageUrl));
				Assert.That(result.Seller, Is.EqualTo(expected.Seller));
			});
		}

		[Test]
		public async Task GetUserMicrophonesAsync_ShouldReturnOnlyMicrophonesThatHaveSellerIdEqualToTheClientIdOfTheClientWithTheGivenUserId()
		{
			var userId = this.data.Users.First().Id;

			var result = await this.microphoneService.GetUserMicrophonesAsync(userId);

			var resultFirst = result.First();

			var clientId = this.data.Clients.FirstOrDefault(c => c.UserId == userId)?.Id;

			var expected = this.data.Microphones.Where(m => m.SellerId == clientId);

			var expectedFirst = expected.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(resultFirst, Is.Not.Null);

				Assert.That(resultFirst.Id, Is.EqualTo(expectedFirst.Id));
				Assert.That(resultFirst.Brand, Is.EqualTo(expectedFirst.Brand.Name));
				Assert.That(resultFirst.Price, Is.EqualTo(expectedFirst.Price));
				Assert.That(resultFirst.ImageUrl, Is.EqualTo(expectedFirst.ImageUrl));
				Assert.That(resultFirst.Warranty, Is.EqualTo(expectedFirst.Warranty));
				Assert.That(resultFirst.Quantity, Is.EqualTo(expectedFirst.Quantity));
				Assert.That(resultFirst.AddedOn, Is.EqualTo(expectedFirst.AddedOn.ToString("MMMM, yyyy", CultureInfo.InvariantCulture)));
			});
		}

		[Test]
		public async Task MarkMicrophoneAsBoughtAsync_ShouldDecreaseMicrophoneQuantityWhenGivenMicrophoneIdIsValid()
		{
			var microphone = this.data.Microphones.First();

			var microphoneQuantityBeforeBuying = microphone.Quantity;

			await this.microphoneService.MarkMicrophoneAsBoughtAsync(microphone.Id);

			var microphoneQuantityAfterBuying = microphone.Quantity;

			Assert.That(microphoneQuantityAfterBuying, Is.EqualTo(microphoneQuantityBeforeBuying - 1));
		}
	}
}
