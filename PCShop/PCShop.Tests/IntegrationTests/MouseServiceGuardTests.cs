using PCShop.Core.Exceptions;
using PCShop.Core.Models.Mouse;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;
using PCShop.Tests.UnitTests;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;

namespace PCShop.Tests.IntegrationTests
{
	[TestFixture]
	public class MouseServiceGuardTests : UnitTestsBase
	{
		private IRepository repository;
		private IGuard guard;
		private IMouseService mouseService;

		[OneTimeSetUp]
		public void SetUp()
		{
			this.repository = new Repository(this.data);
			this.guard = new Guard();

			this.mouseService = new MouseService(this.repository, this.guard);
		}

		[Test]
		public void AddMouseAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenRangeForSensitivityDoesNotExistInThDb()
		{
			var mouse = new MouseImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				IsWireless = true,
				Brand = "NewBrand",
				Type = "NewType",
				Sensitivity = "1000 - 2000 DPI",
				Color = null,
			};

			var userId = this.data.Users.FirstOrDefault()?.Id;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.mouseService.AddMouseAsync(mouse, userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForNotExistingValue));
		}

		[Test]
		public void AddMouseAsync_ShouldThrowPCShopExceptionWithTheCorrectMessageWhenInvalidUserIdIsGiven()
		{
			var mouse = new MouseImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				IsWireless = true,
				Brand = "NewBrand",
				Type = "NewType",
				Sensitivity = "0 - 100 DPI",
				Color = null,
			};

			var userId = "invalid";

			var ex = Assert.ThrowsAsync<PCShopException>(async () => await this.mouseService.AddMouseAsync(mouse, userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidUserId));
		}

		[Test]
		public void DeleteMouseAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenInvalidMouseIdIsGiven()
		{
			var mouseId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.mouseService.DeleteMouseAsync(mouseId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public async Task DeleteMouseAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenMouseIdIsOfAMouseThatIsAlreadyDeleted()
		{
			var mouse = new MouseImportViewModel()
			{
				ImageUrl = null,
				Warranty = 1,
				Price = 1111.00M,
				Quantity = 1,
				IsWireless = true,
				Brand = "NewBrand",
				Type = "NewType",
				Sensitivity = "0 - 100 DPI",
				Color = null,
			};

			var userId = this.data.Users.FirstOrDefault()?.Id;

			var mouseId = await this.mouseService.AddMouseAsync(mouse, userId);

			var addedMouse = this.data.Mice.First(m => m.Id == mouseId);

			await this.mouseService.DeleteMouseAsync(mouseId);

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.mouseService.DeleteMouseAsync(mouseId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForDeletedProduct));

			addedMouse.IsDeleted = false;
		}

		[Test]
		public void EditMouseAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenInvalidMouseIdIsGiven()
		{
			var mouseOrigin = this.data.Mice.First();

			var mouse = new MouseEditViewModel()
			{
				Id = int.MinValue,
				ImageUrl = mouseOrigin.ImageUrl,
				Warranty = mouseOrigin.Warranty,
				Price = mouseOrigin.Price,
				Quantity = mouseOrigin.Quantity,
				IsWireless = mouseOrigin.IsWireless,
				Brand = mouseOrigin.Brand.Name,
				Type = mouseOrigin.Type.Name,
				Sensitivity = mouseOrigin.Sensitivity.Range,
				Color = mouseOrigin.Color?.Name,
				Seller = mouseOrigin.Seller,
			};

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.mouseService.EditMouseAsync(mouse));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void EditMouseAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenRangeForSensitivityDoesNotExistInThDb()
		{
			var mouseOrigin = this.data.Mice.First();

			var mouse = new MouseEditViewModel()
			{
				Id = mouseOrigin.Id,
				ImageUrl = mouseOrigin.ImageUrl,
				Warranty = mouseOrigin.Warranty,
				Price = mouseOrigin.Price,
				Quantity = mouseOrigin.Quantity,
				IsWireless = mouseOrigin.IsWireless,
				Brand = mouseOrigin.Brand.Name,
				Type = mouseOrigin.Type.Name,
				Sensitivity = "1000 - 2000 DPI",
				Color = mouseOrigin.Color?.Name,
				Seller = mouseOrigin.Seller,
			};

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.mouseService.EditMouseAsync(mouse));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForNotExistingValue));
		}

		[Test]
		public void GetMouseByIdAsMouseDetailsExportViewModelAsync_ShouldThrowAnArgumentExceptionWithTheCorrectMessageWhenThereIsNoMouseWithTheGivenId()
		{
			var mouseId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.mouseService.GetMouseByIdAsMouseDetailsExportViewModelAsync(mouseId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetMouseByIdAsMouseEditViewModelAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenMouseIdIsNotValid()
		{
			var mouseId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.mouseService.GetMouseByIdAsMouseEditViewModelAsync(mouseId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public void GetUserMiceAsync_ShouldThrowAPCShopExceptionWithTheCorrectMessageWhenThereIsNoClientWithTheGivenUserId()
		{
			var userId = "invalid";

			var ex = Assert.ThrowsAsync<PCShopException>(async () => await this.mouseService.GetUserMiceAsync(userId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidUserId));
		}

		[Test]
		public void MarkMouseAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenGivenMouseIdIsNotValid()
		{
			var mouseId = int.MinValue;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.mouseService.MarkMouseAsBoughtAsync(mouseId));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForInvalidProductId));
		}

		[Test]
		public async Task MarkMouseAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenMouseWithTheGivenMouseIdIsAlreadyDeleted()
		{
			var mouse = this.data.Mice.First();

			await this.mouseService.DeleteMouseAsync(mouse.Id);

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.mouseService.MarkMouseAsBoughtAsync(mouse.Id));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForDeletedProduct));

			mouse.IsDeleted = false;
		}

		[Test]
		public void MarkMouseAsBoughtAsync_ShouldThrowArgumentExceptionWithTheCorrectMessageWhenMouseWithTheGivenMouseIdIsOutOfStock()
		{
			var mouse = this.data.Mice.First();

			int realQuantity = mouse.Quantity;

			mouse.Quantity = 0;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.mouseService.MarkMouseAsBoughtAsync(mouse.Id));

			Assert.That(ex.Message, Is.EqualTo(ErrorMessageForProductThatIsOutOfStock));

			mouse.Quantity = realQuantity;
		}
	}
}
