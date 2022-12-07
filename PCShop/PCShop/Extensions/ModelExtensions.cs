using PCShop.Core.Models;

namespace PCShop.Extensions
{
    /// <summary>
    /// ModelExtensions model
    /// </summary>
    public static class ModelExtensions
    {
        /// <summary>
        /// Extension method for getting additional information for the product
        /// </summary>
        /// <param name="productModel">The IProductModel that will be extended</param>
        /// <returns>A string that contains information about the product</returns>
        public static string GetInformation(this IProductModel productModel)
        {
            var brand = productModel.Brand.Replace("-", "");

            var price = $"{productModel.Price:F2}";

            var information = brand + "-" + price;

            return information;
        }
    }
}
