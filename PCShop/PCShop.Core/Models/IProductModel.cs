namespace PCShop.Core.Models
{
    /// <summary>
    /// Abstraction of ProductModel
    /// </summary>
    public interface IProductModel
    {
        /// <summary>
        /// Property that represents product brand
        /// </summary>
        public string Brand { get; }

        /// <summary>
        /// Property that represents product price
        /// </summary>
        public decimal? Price { get; }
    }
}
