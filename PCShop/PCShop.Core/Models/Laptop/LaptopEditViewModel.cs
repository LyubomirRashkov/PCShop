namespace PCShop.Core.Models.Laptop
{
    /// <summary>
    /// LaptopEditViewModel model
    /// </summary>
    public class LaptopEditViewModel : LaptopImportViewModel
	{
        /// <summary>
        /// Property that represents laptop unique identifier
        /// </summary>
		public int Id { get; init; }

        /// <summary>
        /// Property that represents laptop Seller unique identifier
        /// </summary>
		public string? SellerId { get; init; }
	}
}
