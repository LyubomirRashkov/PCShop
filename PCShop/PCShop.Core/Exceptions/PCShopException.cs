namespace PCShop.Core.Exceptions
{
    /// <summary>
    /// PCShopException model
    /// </summary>
    public class PCShopException : ApplicationException
    {
        /// <summary>
        /// Constructor of PCShopException class
        /// </summary>
        public PCShopException()
        {
        }

        /// <summary>
        /// Constructor of PCShopException class
        /// </summary>
        /// <param name="errorMessage">The error message that will be attached to the exception</param>
        public PCShopException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
