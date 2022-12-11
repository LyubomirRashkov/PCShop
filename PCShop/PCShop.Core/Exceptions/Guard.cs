namespace PCShop.Core.Exceptions
{
    /// <summary>
    /// Guard model
    /// </summary>
    public class Guard : IGuard
    {
        /// <summary>
        /// Method that will throw a PCShopException when the given value is null
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <param name="value">The value that will be checked for null</param>
        /// <param name="errorMessage">The error message that will be attached to the PCShopException</param>
        public void AgainstInvalidUserId<T>(T value, string? errorMessage = null)
        {
            if (value is null)
            {
                var exception = errorMessage is null 
                                ? new PCShopException() 
                                : new PCShopException(errorMessage);

                throw exception;
            }
        }

		/// <summary>
		/// Method that will throw an ArgumentException when the given collection is null or empty
		/// </summary>
		/// <typeparam name="T">Type of the elements in the collection</typeparam>
		/// <param name="collection">The collection that will be checked</param>
		/// <param name="errorMessage">The error message that will be attached to the ArgumentException</param>
		public void AgainstNullOrEmptyCollection<T>(IEnumerable<T> collection, string? errorMessage = null)
        {
            if (collection is null || !collection.Any())
            {
                var exception = errorMessage is null
                                ? new ArgumentException()
                                : new ArgumentException(errorMessage);

                throw exception;
            }
        }

		/// <summary>
		/// Method that will throw an ArgumentException when the given value is null
		/// </summary>
		/// <typeparam name="T">Type of the value</typeparam>
		/// <param name="value">The value that will be checked for null</param>
		/// <param name="errorMessage">The error message that will be attached to the ArgumentException</param>
		public void AgainstProductThatIsNull<T>(T value, string? errorMessage = null)
		{
			if (value is null)
			{
				var exception = errorMessage is null
								? new ArgumentException()
								: new ArgumentException(errorMessage);

				throw exception;
			}
		}

		/// <summary>
		/// Method that will throw an ArgumentException when the given boolean is true
		/// </summary>
		/// <param name="isDeleted">The boolean that will be checked</param>
		/// <param name="errorMessage">The error message that will be attached to the ArgumentException</param>
		public void AgainstProductThatIsDeleted(bool isDeleted, string? errorMessage = null)
		{
			if (isDeleted)
			{
				var exception = errorMessage is null
								? new ArgumentException()
								: new ArgumentException(errorMessage);

				throw exception;
			}
		}

		/// <summary>
		/// Method that will throw an ArgumentException when the given quantity is zero
		/// </summary>
		/// <param name="quantity">The quantity that will be checked</param>
		/// <param name="errorMessage">The error message that will be attached to the ArgumentException</param>
		public void AgainstProductThatIsOutOfStock(int quantity, string? errorMessage = null)
		{
			if (quantity == 0)
			{
				var exception = errorMessage is null
								? new ArgumentException()
								: new ArgumentException(errorMessage);

				throw exception;
			}
		}

		/// <summary>
		/// Method that will throw an ArgumentException when the given value is null
		/// </summary>
		/// <typeparam name="T">Type of the value</typeparam>
		/// <param name="value">The value that will be checked for null</param>
		/// <param name="errorMessage">The error message that will be attached to the ArgumentException</param>
		public void AgainstNotExistingValue<T>(T value, string? errorMessage = null)
		{
			if (value is null)
			{
				var exception = errorMessage is null
								? new ArgumentException()
								: new ArgumentException(errorMessage);

				throw exception;
			}
		}
	}
}
