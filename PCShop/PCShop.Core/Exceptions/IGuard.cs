namespace PCShop.Core.Exceptions
{
    /// <summary>
    /// Abstraction of Guard
    /// </summary>
    public interface IGuard
    {
		/// <summary>
		/// Method that will throw a PCShopException when the given value is null
		/// </summary>
		/// <typeparam name="T">Type of the value</typeparam>
		/// <param name="value">The value that will be checked for null</param>
		/// <param name="errorMessage">The error message that will be attached to the PCShopException</param>
		void AgainstClientThatDoesNotExist<T>(T value, string? errorMessage = null);

		/// <summary>
		/// Method that will throw an ArgumentException when the given collection is null or empty
		/// </summary>
		/// <typeparam name="T">Type of the elements in the collection</typeparam>
		/// <param name="collection">The collection that will be checked</param>
		/// <param name="errorMessage">The error message that will be attached to the ArgumentException</param>
		void AgainstNullOrEmptyCollection<T>(IEnumerable<T> collection, string? errorMessage = null);

		/// <summary>
		/// Method that will throw an ArgumentException when the given boolean is true
		/// </summary>
		/// <param name="isDeleted">The boolean that will be checked</param>
		/// <param name="errorMessage">The error message that will be attached to the ArgumentException</param>
		void AgainstProductThatIsDeleted(bool isDeleted, string? errorMessage = null);

		/// <summary>
		/// Method that will throw an ArgumentException when the given quantity is zero
		/// </summary>
		/// <param name="quantity">The quantity that will be checked</param>
		/// <param name="errorMessage">The error message that will be attached to the ArgumentException</param>
		void AgainstProductThatIsOutOfStock(int quantity, string? errorMessage = null);

		/// <summary>
		/// Method that will throw an ArgumentException when the given value is null
		/// </summary>
		/// <typeparam name="T">Type of the value</typeparam>
		/// <param name="value">The value that will be checked for null</param>
		/// <param name="errorMessage">The error message that will be attached to the ArgumentException</param>
		void AgainstProductThatIsNull<T>(T value, string? errorMessage = null);
	}
}
