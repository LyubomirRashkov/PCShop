namespace PCShop.DataGenerator.Classes.BaseClass
{
    /// <summary>
    /// Base class for other classes
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Property that represents product's brand
        /// </summary>
        public string Brand { get; set; } = null!;

        /// <summary>
        /// Property that represents product's color
        /// </summary>
        public string Color { get; set; } = null!;

        /// <summary>
        /// Property that represents product's imageUrl
        /// </summary>
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// Property that represents product's warranty
        /// </summary>
        public int Warranty { get; set; }
    }
}
