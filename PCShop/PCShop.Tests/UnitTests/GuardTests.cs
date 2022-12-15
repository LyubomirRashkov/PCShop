using PCShop.Core.Exceptions;

namespace PCShop.Tests.UnitTests
{
	[TestFixture]
	public class GuardTests
	{
		private IGuard guard;
		private string message;

		[OneTimeSetUp]
		public void SetUp()
		{
			this.guard = new Guard();
			this.message = "Error message";
		}

		[Test]
		public void AgainstInvalidUserId_ShouldThrowAPCShopExceptionWhenTheGivenValueIsNull()
		{
			Assert.Throws<PCShopException>(() => this.guard.AgainstInvalidUserId<object?>(null));
		}

		[Test]
		public void AgainstInvalidUserId_ShouldThrowAPCShopExceptionWithTheCorrectMessageWhenTheGivenValueIsNull()
		{
			var ex = Assert.Throws<PCShopException>(() => this.guard.AgainstInvalidUserId<object?>(null, this.message));

			Assert.That(ex.Message, Is.EqualTo(this.message));
		}

		[Test]
		public void AgainstNullOrEmptyCollection_ShouldThrowAnArgumentExceptionWhenTheGivenCollectionIsNull()
		{
			Assert.Throws<ArgumentException>(() => this.guard.AgainstNullOrEmptyCollection<object>(null));
		}

		[Test]
		public void AgainstNullOrEmptyCollection_ShouldThrowAnArgumentExceptionWithTheCorrectMessageWhenTheGivenCollectionIsNull()
		{
			var ex = Assert.Throws<PCShopException>(() => this.guard.AgainstInvalidUserId<object?>(null, this.message));

			Assert.That(ex.Message, Is.EqualTo(this.message));
		}

		[Test]
		public void AgainstNullOrEmptyCollection_ShouldThrowAnArgumentExceptionWhenTheGivenCollectionIsEmpty()
		{
			var collection = new List<object>();

			Assert.Throws<ArgumentException>(() => this.guard.AgainstNullOrEmptyCollection<object>(collection));
		}

		[Test]
		public void AgainstNullOrEmptyCollection_ShouldThrowAnArgumentExceptionWithTheCorrectMessageWhenTheGivenCollectionIsEmpty()
		{
			var collection = new List<object>();

			var ex = Assert.Throws<ArgumentException>(() => this.guard.AgainstNullOrEmptyCollection<object>((collection), this.message));

			Assert.That(ex.Message, Is.EqualTo(this.message));
		}

		[Test]
		public void AgainstProductThatIsNull_ShouldThrowAnArgumentExceptionWhenTheGivenValueIsNull()
		{
			Assert.Throws<ArgumentException>(() => this.guard.AgainstProductThatIsNull<object?>(null));
		}

		[Test]
		public void AgainstProductThatIsNull_ShouldThrowAnArgumentExceptionWithTheCorrectMessageWhenTheGivenValueIsNull()
		{
			var ex = Assert.Throws<ArgumentException>(() => this.guard.AgainstProductThatIsNull<object?>(null, this.message));

			Assert.That(ex.Message, Is.EqualTo(this.message));
		}

		[Test]
		public void AgainstProductThatIsDeleted_ShouldThrowAnArgumentExceptionWhenTheGivenBooleanIsTrue()
		{
			Assert.Throws<ArgumentException>(() => this.guard.AgainstProductThatIsDeleted(true));
		}

		[Test]
		public void AgainstProductThatIsDeleted_ShouldThrowAnArgumentExceptionWithTheCorrectMessageWhenTheGivenBooleanIsTrue()
		{
			var ex = Assert.Throws<ArgumentException>(() => this.guard.AgainstProductThatIsDeleted(true, this.message));

			Assert.That(ex.Message, Is.EqualTo(this.message));
		}

		[Test]
		public void AgainstProductThatIsOutOfStock_ShouldThrowAnArgumentExceptionWhenTheGivenValueIsEqualToZero()
		{
			Assert.Throws<ArgumentException>(() => this.guard.AgainstProductThatIsOutOfStock(0));
		}

		[Test]
		public void AgainstProductThatIsOutOfStock_ShouldThrowAnArgumentExceptionWithTheCorrectMessageWhenTheGivenValueIsEqualToZero()
		{
			var ex = Assert.Throws<ArgumentException>(() => this.guard.AgainstProductThatIsOutOfStock(0, this.message));

			Assert.That(ex.Message, Is.EqualTo(this.message));
		}

		[Test]
		public void AgainstNotExistingValue_ShouldThrowAnArgumentExceptionWhenTheGivenValueIsNull()
		{
			Assert.Throws<ArgumentException>(() => this.guard.AgainstNotExistingValue<object?>(null));
		}

		[Test]
		public void AgainstNotExistingValue_ShouldThrowAnArgumentExceptionWithTheCorrectMessageWhenTheGivenValueIsNull()
		{
			var ex = Assert.Throws<ArgumentException>(() => this.guard.AgainstNotExistingValue<object?>(null, this.message));

			Assert.That(ex.Message, Is.EqualTo(this.message));
		}
	}
}
