namespace PCShop.Core.Constants
{
    /// <summary>
    /// An enumeration of product sortings
    /// </summary>
    public enum Sorting
    {
        /// <summary>
        /// Enum value for sorting by the date of addition
        /// </summary>
        Newest = 0,
        /// <summary>
        /// Enum value for sorting by the brand name
        /// </summary>
        Brand = 1,
        /// <summary>
        /// Enum value for sorting by price (min first, max last)
        /// </summary>
        PriceMinToMax = 2,
        /// <summary>
        /// Enum value for sorting by price (max first, min last)
        /// </summary>
        PriceMaxToMin = 3,
    }
}
