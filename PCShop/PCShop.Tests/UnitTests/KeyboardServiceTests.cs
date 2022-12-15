using PCShop.Core.Constants;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Keyboard;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using System.Globalization;

namespace PCShop.Tests.UnitTests
{
	[TestFixture]
	public class KeyboardServiceTests : UnitTestsBase
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

		[TestCase(null, null)]
		[TestCase("NewFormat", "NewColor")]
		public async Task AddKeyboardAsync_ShouldAddKeyboard(string? format, string? color)
		{
			var countOfKeyboardsInDbBeforeAddition = this.data.Keyboards.Count();

			var keyboard = new KeyboardImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				IsWireless = true,
				Brand = "NewBrand",
				Type = "NewType",
				Format = format,
				Color = color,
			};

			var userId = this.data.Users.FirstOrDefault()?.Id;

			var keyboardId = await this.keyboardService.AddKeyboardAsync(keyboard, userId);

			var countOfKeyboardsInDbAfterAddition = this.data.Keyboards.Count();

			Assert.That(countOfKeyboardsInDbAfterAddition, Is.EqualTo(countOfKeyboardsInDbBeforeAddition + 1));

			var keyboardInDb = this.data.Keyboards.First(k => k.Id == keyboardId);

			Assert.Multiple(() =>
			{
				Assert.That(keyboardInDb, Is.Not.Null);

				Assert.That(keyboardInDb.ImageUrl, Is.Null);
				Assert.That(keyboardInDb.Warranty, Is.EqualTo(keyboard.Warranty));
				Assert.That(keyboardInDb.Price, Is.EqualTo(keyboard.Price));
				Assert.That(keyboardInDb.Quantity, Is.EqualTo(keyboard.Quantity));
				Assert.That(keyboardInDb.IsWireless, Is.EqualTo(keyboard.IsWireless));
				Assert.That(keyboardInDb.Brand.Name, Is.EqualTo(keyboard.Brand));
				Assert.That(keyboardInDb.Type.Name, Is.EqualTo(keyboard.Type));
				Assert.That(keyboardInDb.Format?.Name, Is.EqualTo(format));
				Assert.That(keyboardInDb.Color?.Name, Is.EqualTo(color));
			});
		}

		[Test]
		public async Task DeleteKeyboardAsync_ShouldMarkTheSpecifiedKeyboardAsDeleted()
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

			Assert.That(addedKeyboard.IsDeleted, Is.False);

			await this.keyboardService.DeleteKeyboardAsync(keyboardId);

			Assert.That(addedKeyboard.IsDeleted, Is.True);

			addedKeyboard.IsDeleted = false;
		}

		[Test]
		public async Task EditKeyboardAsync_ShouldEditKeyboardCorrectly()
		{
			var keyboardOrigin = this.data.Keyboards.First();

			var newPrice = keyboardOrigin.Price + 1000;

			var keyboard = new KeyboardEditViewModel()
			{
				Id = keyboardOrigin.Id,
				ImageUrl = keyboardOrigin.ImageUrl,
				Warranty = keyboardOrigin.Warranty,
				Price = newPrice,
				Quantity = keyboardOrigin.Quantity,
				IsWireless = keyboardOrigin.IsWireless,
				Brand = keyboardOrigin.Brand.Name,
				Type = keyboardOrigin.Type.Name,
				Format = keyboardOrigin.Format?.Name,
				Color = keyboardOrigin.Color?.Name,
				Seller = keyboardOrigin.Seller,
			};

			var editedKeyboardId = await this.keyboardService.EditKeyboardAsync(keyboard);

			var editedKeyboardInDb = this.data.Keyboards.First(k => k.Id == editedKeyboardId);

			Assert.Multiple(() =>
			{
				Assert.That(editedKeyboardInDb, Is.Not.Null);

				Assert.That(editedKeyboardInDb.Price, Is.EqualTo(newPrice));

				Assert.That(editedKeyboardInDb.ImageUrl, Is.EqualTo(keyboardOrigin.ImageUrl));
				Assert.That(editedKeyboardInDb.Warranty, Is.EqualTo(keyboardOrigin.Warranty));
				Assert.That(editedKeyboardInDb.Quantity, Is.EqualTo(keyboardOrigin.Quantity));
				Assert.That(editedKeyboardInDb.IsWireless, Is.EqualTo(keyboardOrigin.IsWireless));
				Assert.That(editedKeyboardInDb.Brand.Name, Is.EqualTo(keyboardOrigin.Brand.Name));
				Assert.That(editedKeyboardInDb.Type.Name, Is.EqualTo(keyboardOrigin.Type.Name));
				Assert.That(editedKeyboardInDb.Format?.Name, Is.EqualTo(keyboardOrigin.Format?.Name));
				Assert.That(editedKeyboardInDb.Color?.Name, Is.EqualTo(keyboardOrigin.Color?.Name));
				Assert.That(editedKeyboardInDb.Seller, Is.EqualTo(keyboardOrigin.Seller));
			});
		}

		[Test]
		public async Task GetAllKeyboardsAsync_ShouldReturnAllKeyboardsWhenThereAreNoSearchingParameters()
		{
			var result = await this.keyboardService.GetAllKeyboardsAsync();

			var expectedCount = this.data.Keyboards.Count();
			Assert.That(result.TotalKeyboardsCount, Is.EqualTo(expectedCount));
		}

		[Test]
		public async Task GetAllKeyboardsAsync_ShouldReturnCorrectKeyboardsAccordingToTheSearchingParameters()
		{
			var typeName = this.data.Types.First().Name;
			var wireless = Wireless.Regardless;
			var keyword = "1";
			var sorting = Sorting.PriceMaxToMin;

			var result = await this.keyboardService.GetAllKeyboardsAsync(
				null, 
				typeName, 
				wireless, 
				keyword, 
				sorting);

			var expected = this.data.Keyboards
				.Where(k => k.Type.Name == typeName)
				.Where(k => k.Brand.Name.Contains(keyword)
							|| k.Type.Name.Contains(keyword)
							|| (k.Format != null && k.Format.Name.Contains(keyword)))
				.OrderByDescending(m => m.Price)
				.ToList();

			Assert.That(result.TotalKeyboardsCount, Is.EqualTo(expected.Count));
		}

		[Test]
		public async Task GetAllKeyboardsAsync_ShouldReturnEmptyCollectionWhenThereIsNoKeyboardAccordingToTheSpecifiedCriteria()
		{
			var brandName = "invalid";

			var result = await this.keyboardService.GetAllKeyboardsAsync(brandName);

			Assert.That(result.TotalKeyboardsCount, Is.Zero);
		}

		[Test]
		public async Task GetAllKeyboardsFormatsAsync_ShouldReturnCorrectFormatsNames()
		{
			var result = await this.keyboardService.GetAllKeyboardsFormatsAsync();

			var expectedCount = this.data.Formats.Count();
			Assert.That(result.Count(), Is.EqualTo(expectedCount));

			var expected = this.data.Formats.Select(x => x.Name).OrderBy(x => x).ToList();
			Assert.That(expected.SequenceEqual<string>(result));
		}

		[Test]
		public async Task GetAllKeyboardsTypesAsync_ShouldReturnCorrectTypesNames()
		{
			var result = await this.keyboardService.GetAllKeyboardsTypesAsync();

			var expectedCount = this.data.Types.Count();
			Assert.That(result.Count(), Is.EqualTo(expectedCount));

			var expected = this.data.Types.Select(x => x.Name).OrderBy(x => x).ToList();
			Assert.That(expected.SequenceEqual<string>(result));
		}

		[Test]
		public async Task GetKeyboardByIdAsKeyboardDetailsExportViewModelAsync_ShouldReturnTheCorrectKeyboard()
		{
			var keyboardId = this.data.Keyboards.First().Id;

			var result = await this.keyboardService.GetKeyboardByIdAsKeyboardDetailsExportViewModelAsync(keyboardId);

			var expected = this.data.Keyboards.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(result.Id, Is.EqualTo(expected.Id));
				Assert.That(result.Brand, Is.EqualTo(expected.Brand.Name));
				Assert.That(result.Price, Is.EqualTo(expected.Price));
				Assert.That(result.IsWireless, Is.EqualTo(expected.IsWireless));
				Assert.That(result.Type, Is.EqualTo(expected.Type.Name));
				Assert.That(result.ImageUrl, Is.EqualTo(expected.ImageUrl));
				Assert.That(result.Warranty, Is.EqualTo(expected.Warranty));
				Assert.That(result.Quantity, Is.EqualTo(expected.Quantity));
				Assert.That(result.AddedOn, Is.EqualTo(expected.AddedOn.ToString("MMMM, yyyy", CultureInfo.InvariantCulture)));
				Assert.That(result.Seller, Is.EqualTo(expected.Seller));
			});
		}

		[Test]
		public async Task GetKeyboardByIdAsKeyboardEditViewModelAsync_ShouldReturnCorrectKeyboard()
		{
			var keyboardId = this.data.Keyboards.First().Id;

			var result = await this.keyboardService.GetKeyboardByIdAsKeyboardEditViewModelAsync(keyboardId);

			var expected = this.data.Keyboards.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(result.Id, Is.EqualTo(expected.Id));
				Assert.That(result.Brand, Is.EqualTo(expected.Brand.Name));
				Assert.That(result.IsWireless, Is.EqualTo(expected.IsWireless));
				Assert.That(result.Type, Is.EqualTo(expected.Type.Name));
				Assert.That(result.Quantity, Is.EqualTo(expected.Quantity));
				Assert.That(result.Price, Is.EqualTo(expected.Price));
				Assert.That(result.Warranty, Is.EqualTo(expected.Warranty));
				Assert.That(result.ImageUrl, Is.EqualTo(expected.ImageUrl));
				Assert.That(result.Seller, Is.EqualTo(expected.Seller));
			});
		}

		[Test]
		public async Task GetUserKeyboardsAsync_ShouldReturnOnlyKeyboardsThatHaveSellerIdEqualToTheClientIdOfTheClientWithTheGivenUserId()
		{
			var userId = this.data.Users.First().Id;

			var result = await this.keyboardService.GetUserKeyboardsAsync(userId);

			var resultFirst = result.First();

			var clientId = this.data.Clients.FirstOrDefault(c => c.UserId == userId)?.Id;

			var expected = this.data.Keyboards.Where(k => k.SellerId == clientId);

			var expectedFirst = expected.First();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(resultFirst, Is.Not.Null);

				Assert.That(resultFirst.Id, Is.EqualTo(expectedFirst.Id));
				Assert.That(resultFirst.Brand, Is.EqualTo(expectedFirst.Brand.Name));
				Assert.That(resultFirst.Price, Is.EqualTo(expectedFirst.Price));
				Assert.That(resultFirst.IsWireless, Is.EqualTo(expectedFirst.IsWireless));
				Assert.That(resultFirst.Type, Is.EqualTo(expectedFirst.Type.Name));
				Assert.That(resultFirst.ImageUrl, Is.EqualTo(expectedFirst.ImageUrl));
				Assert.That(resultFirst.Warranty, Is.EqualTo(expectedFirst.Warranty));
				Assert.That(resultFirst.Quantity, Is.EqualTo(expectedFirst.Quantity));
				Assert.That(resultFirst.AddedOn, Is.EqualTo(expectedFirst.AddedOn.ToString("MMMM, yyyy", CultureInfo.InvariantCulture)));
			});
		}

		[Test]
		public async Task MarkKeyboardAsBoughtAsync_ShouldDecreaseKeyboardQuantityWhenGivenKeyboardIdIsValid()
		{
			var keyboard = this.data.Keyboards.First();

			var keyboardQuantityBeforeBuying = keyboard.Quantity;

			await this.keyboardService.MarkKeyboardAsBoughtAsync(keyboard.Id);

			var keyboardQuantityAfterBuying = keyboard.Quantity;

			Assert.That(keyboardQuantityAfterBuying, Is.EqualTo(keyboardQuantityBeforeBuying - 1));
		}
	}
}
