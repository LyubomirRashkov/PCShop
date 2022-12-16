using PCShop.Core.Constants;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Headphone;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using System.Globalization;

namespace PCShop.Tests.UnitTests
{
	[TestFixture]
	public class HeadphoneServiceTests : UnitTestsBase
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

		[TestCase(null)]
		[TestCase("NewColor")]
		public async Task AddHeadphoneAsync_ShouldAddHeadphone(string? color)
		{
			var countOfHeadphonesInDbBeforeAddition = this.data.Headphones.Count();

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
				Color = color,
			};

			var userId = this.data.Users.FirstOrDefault()?.Id;

			var headphoneId = await this.headphoneService.AddHeadphoneAsync(headphone, userId);

			var countOfHeadphonesInDbAfterAddition = this.data.Headphones.Count();

			Assert.That(countOfHeadphonesInDbAfterAddition, Is.EqualTo(countOfHeadphonesInDbBeforeAddition + 1));

			var headphoneInDb = this.data.Headphones.First(h => h.Id == headphoneId);

			Assert.Multiple(() =>
			{
				Assert.That(headphoneInDb, Is.Not.Null);

				Assert.That(headphoneInDb.ImageUrl, Is.Null);
				Assert.That(headphoneInDb.Warranty, Is.EqualTo(headphone.Warranty));
				Assert.That(headphoneInDb.Price, Is.EqualTo(headphone.Price));
				Assert.That(headphoneInDb.Quantity, Is.EqualTo(headphone.Quantity));
				Assert.That(headphoneInDb.IsWireless, Is.EqualTo(headphone.IsWireless));
				Assert.That(headphoneInDb.HasMicrophone, Is.EqualTo(headphone.HasMicrophone));
				Assert.That(headphoneInDb.Brand.Name, Is.EqualTo(headphone.Brand));
				Assert.That(headphoneInDb.Type.Name, Is.EqualTo(headphone.Type));
				Assert.That(headphoneInDb.Color?.Name, Is.EqualTo(color));
			});
		}

		[Test]
		public async Task DeleteHeadphoneAsync_ShouldMarkTheSpecifiedHeadphoneAsDeleted()
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

			Assert.That(addedHeadphone.IsDeleted, Is.False);

			await this.headphoneService.DeleteHeadphoneAsync(headphoneId);

			Assert.That(addedHeadphone.IsDeleted, Is.True);

			addedHeadphone.IsDeleted = false;
		}

		[Test]
		public async Task EditHeadphoneAsync_ShouldEditHeadphoneCorrectly()
		{
			var headphoneOrigin = this.data.Headphones.First();

			var newPrice = headphoneOrigin.Price + 1000;

			var headphone = new HeadphoneEditViewModel()
			{
				Id = headphoneOrigin.Id,
				ImageUrl = headphoneOrigin.ImageUrl,
				Warranty = headphoneOrigin.Warranty,
				Price = newPrice,
				Quantity = headphoneOrigin.Quantity,
				IsWireless = headphoneOrigin.IsWireless,
				HasMicrophone = headphoneOrigin.HasMicrophone,
				Brand = headphoneOrigin.Brand.Name,
				Type = headphoneOrigin.Type.Name,
				Color = headphoneOrigin.Color?.Name,
				Seller = headphoneOrigin.Seller,
			};

			var editedHeadphoneId = await this.headphoneService.EditHeadphoneAsync(headphone);

			var editedHeadphoneInDb = this.data.Headphones.First(h => h.Id == editedHeadphoneId);

			Assert.Multiple(() =>
			{
				Assert.That(editedHeadphoneInDb, Is.Not.Null);

				Assert.That(editedHeadphoneInDb.Price, Is.EqualTo(newPrice));

				Assert.That(editedHeadphoneInDb.ImageUrl, Is.EqualTo(headphoneOrigin.ImageUrl));
				Assert.That(editedHeadphoneInDb.Warranty, Is.EqualTo(headphoneOrigin.Warranty));
				Assert.That(editedHeadphoneInDb.Quantity, Is.EqualTo(headphoneOrigin.Quantity));
				Assert.That(editedHeadphoneInDb.IsWireless, Is.EqualTo(headphoneOrigin.IsWireless));
				Assert.That(editedHeadphoneInDb.HasMicrophone, Is.EqualTo(headphoneOrigin.HasMicrophone));
				Assert.That(editedHeadphoneInDb.Brand.Name, Is.EqualTo(headphoneOrigin.Brand.Name));
				Assert.That(editedHeadphoneInDb.Type.Name, Is.EqualTo(headphoneOrigin.Type.Name));
				Assert.That(editedHeadphoneInDb.Color?.Name, Is.EqualTo(headphoneOrigin.Color?.Name));
				Assert.That(editedHeadphoneInDb.Seller, Is.EqualTo(headphoneOrigin.Seller));
			});
		}

		[Test]
		public async Task GetAllHeadphonesAsync_ShouldReturnAllHeadphonesWhenThereAreNoSearchingParameters()
		{
			var result = await this.headphoneService.GetAllHeadphonesAsync();

			var expectedCount = this.data.Headphones.Count();
			Assert.That(result.TotalHeadphonesCount, Is.EqualTo(expectedCount));
		}

		[Test]
		public async Task GetAllHeadphonesAsync_ShouldReturnCorrectHeadphonesAccordingToTheSearchingParameters()
		{
			var typeName = this.data.Types.First().Name;
			var wireless = Wireless.Regardless;
			var keyword = "1";
			var sorting = Sorting.PriceMaxToMin;

			var result = await this.headphoneService.GetAllHeadphonesAsync(
				typeName,
				wireless,
				keyword,
				sorting);

			var expected = this.data.Headphones
				.Where(h => h.Type.Name == typeName)
				.Where(h => h.Brand.Name.Contains(keyword)
							|| h.Type.Name.Contains(keyword))
				.OrderByDescending(h => h.Price)
				.ToList();

			Assert.That(result.TotalHeadphonesCount, Is.EqualTo(expected.Count));
		}

		[Test]
		public async Task GetAllHeadphonesAsync_ShouldReturnEmptyCollectionWhenThereIsNoHeadphoneAccordingToTheSpecifiedCriteria()
		{
			var brandName = "invalid";

			var result = await this.headphoneService.GetAllHeadphonesAsync(brandName);

			Assert.That(result.TotalHeadphonesCount, Is.Zero);
		}

		[Test]
		public async Task GetAllHeadphonesTypesAsync_ShouldReturnCorrectTypesNames()
		{
			var result = await this.headphoneService.GetAllHeadphonesTypesAsync();

			var expectedCount = this.data.Types.Count();
			Assert.That(result.Count(), Is.EqualTo(expectedCount));

			var expected = this.data.Types.Select(x => x.Name).OrderBy(x => x).ToList();
			Assert.That(expected.SequenceEqual<string>(result));
		}

		[Test]
		public async Task GetHeadphonesByIdAsHeadphoneDetailsExportViewModelAsync_ShouldReturnTheCorrectHeadphone()
		{
			var headphoneId = this.data.Headphones.First().Id;

			var result = await this.headphoneService.GetHeadphoneByIdAsHeadphoneDetailsExportViewModelAsync(headphoneId);

			var expected = this.data.Headphones.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(result.Id, Is.EqualTo(expected.Id));
				Assert.That(result.Brand, Is.EqualTo(expected.Brand.Name));
				Assert.That(result.Price, Is.EqualTo(expected.Price));
				Assert.That(result.IsWireless, Is.EqualTo(expected.IsWireless));
				Assert.That(result.HasMicrophone, Is.EqualTo(expected.HasMicrophone));
				Assert.That(result.Type, Is.EqualTo(expected.Type.Name));
				Assert.That(result.ImageUrl, Is.EqualTo(expected.ImageUrl));
				Assert.That(result.Warranty, Is.EqualTo(expected.Warranty));
				Assert.That(result.Quantity, Is.EqualTo(expected.Quantity));
				Assert.That(result.AddedOn, Is.EqualTo(expected.AddedOn.ToString("MMMM, yyyy", CultureInfo.InvariantCulture)));
				Assert.That(result.Seller, Is.EqualTo(expected.Seller));
			});
		}

		[Test]
		public async Task GetHeadphoneByIdAsHeadphoneEditViewModelAsync_ShouldReturnCorrectHeadphone()
		{
			var headphoneId = this.data.Headphones.First().Id;

			var result = await this.headphoneService.GetHeadphoneByIdAsHeadphoneEditViewModelAsync(headphoneId);

			var expected = this.data.Headphones.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(result.Id, Is.EqualTo(expected.Id));
				Assert.That(result.Brand, Is.EqualTo(expected.Brand.Name));
				Assert.That(result.IsWireless, Is.EqualTo(expected.IsWireless));
				Assert.That(result.HasMicrophone, Is.EqualTo(expected.HasMicrophone));
				Assert.That(result.Type, Is.EqualTo(expected.Type.Name));
				Assert.That(result.Quantity, Is.EqualTo(expected.Quantity));
				Assert.That(result.Price, Is.EqualTo(expected.Price));
				Assert.That(result.Warranty, Is.EqualTo(expected.Warranty));
				Assert.That(result.ImageUrl, Is.EqualTo(expected.ImageUrl));
				Assert.That(result.Seller, Is.EqualTo(expected.Seller));
			});
		}

		[Test]
		public async Task GetUserHeadphonesAsync_ShouldReturnOnlyHeadphonesThatHaveSellerIdEqualToTheClientIdOfTheClientWithTheGivenUserId()
		{
			var userId = this.data.Users.First().Id;

			var result = await this.headphoneService.GetUserHeadphonesAsync(userId);

			var resultFirst = result.First();

			var clientId = this.data.Clients.FirstOrDefault(c => c.UserId == userId)?.Id;

			var expected = this.data.Headphones.Where(h => h.SellerId == clientId);

			var expectedFirst = expected.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(resultFirst, Is.Not.Null);

				Assert.That(resultFirst.Id, Is.EqualTo(expectedFirst.Id));
				Assert.That(resultFirst.Brand, Is.EqualTo(expectedFirst.Brand.Name));
				Assert.That(resultFirst.Price, Is.EqualTo(expectedFirst.Price));
				Assert.That(resultFirst.IsWireless, Is.EqualTo(expectedFirst.IsWireless));
				Assert.That(resultFirst.HasMicrophone, Is.EqualTo(expectedFirst.HasMicrophone));
				Assert.That(resultFirst.Type, Is.EqualTo(expectedFirst.Type.Name));
				Assert.That(resultFirst.ImageUrl, Is.EqualTo(expectedFirst.ImageUrl));
				Assert.That(resultFirst.Warranty, Is.EqualTo(expectedFirst.Warranty));
				Assert.That(resultFirst.Quantity, Is.EqualTo(expectedFirst.Quantity));
				Assert.That(resultFirst.AddedOn, Is.EqualTo(expectedFirst.AddedOn.ToString("MMMM, yyyy", CultureInfo.InvariantCulture)));
			});
		}

		[Test]
		public async Task MarkHeadphoneAsBoughtAsync_ShouldDecreaseHeadphoneQuantityWhenGivenHeadphoneIdIsValid()
		{
			var headphone = this.data.Headphones.First();

			var headphoneQuantityBeforeBuying = headphone.Quantity;

			await this.headphoneService.MarkHeadphoneAsBoughtAsync(headphone.Id);

			var headphoneQuantityAfterBuying = headphone.Quantity;

			Assert.That(headphoneQuantityAfterBuying, Is.EqualTo(headphoneQuantityBeforeBuying - 1));
		}
	}
}
