namespace PCShop.Core.Exceptions
{
    /// <summary>
    /// Abstraction of Guard
    /// </summary>
    public interface IGuard
    {
        /// <summary>
        /// Method, that will throw a PCShopException when the given value is null
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <param name="value">The value that will be checked for null</param>
        /// <param name="errorMessage">The error message that will be attached to the PCShopException</param>
        void AgainstNull<T>(T value, string? errorMessage = null);

        /// <summary>
        /// Method, that will throw a PCShopException when the given collection is null or empty
        /// </summary>
        /// <typeparam name="T">Type of the elements in the collection</typeparam>
        /// <param name="collection">The collection that will be checked</param>
        /// <param name="errorMessage">The error message that will be attached to the PCShopException</param>
        void AgainstNullOrEmptyCollection<T>(IEnumerable<T> collection, string? errorMessage = null);
    }
}
