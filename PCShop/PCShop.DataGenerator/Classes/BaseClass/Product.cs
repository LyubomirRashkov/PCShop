namespace PCShop.DataGenerator.Classes.BaseClass
{
    /// <summary>
    /// Base class for all other classes
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product brand
        /// </summary>
        public string Brand { get; set; } = null!;

        /// <summary>
        /// Product color
        /// </summary>
        public string Color { get; set; } = null!;

        /// <summary>
        /// Product imageURL
        /// </summary>
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// Product warranty
        /// </summary>
        public int Warranty { get; set; }
    }
}
