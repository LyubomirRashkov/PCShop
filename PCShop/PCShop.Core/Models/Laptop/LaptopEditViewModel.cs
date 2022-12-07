using PCShop.Infrastructure.Data.Models;

namespace PCShop.Core.Models.Laptop
{
    /// <summary>
    /// LaptopEditViewModel model
    /// </summary>
    public class LaptopEditViewModel : LaptopImportViewModel, IProductModel
	{
        /// <summary>
        /// Property that represents laptop unique identifier
        /// </summary>
		public int Id { get; init; }

        /// <summary>
        /// Property that represents laptop Seller
        /// </summary>
		public Client? Seller { get; init; }
	}
}
