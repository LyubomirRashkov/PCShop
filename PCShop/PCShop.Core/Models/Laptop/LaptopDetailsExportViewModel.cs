namespace PCShop.Core.Models.Laptop
{
    using PCShop.Infrastructure.Data.Models;

    /// <summary>
    /// LaptopDetailsExportViewModel model
    /// </summary>
    public class LaptopDetailsExportViewModel : LaptopExportViewModel
    {
        /// <summary>
        /// Property that represents laptop type
        /// </summary>
        public string Type { get; init; } = null!;

        /// <summary>
        /// Property that represents laptop display coverage
        /// </summary>
        public string? DisplayCoverage { get; init; }

        /// <summary>
        /// Property that represents laptop display technology
        /// </summary>
        public string? DisplayTechnology { get; init; }

        /// <summary>
		/// Property that represents laptop display resolution
		/// </summary>
		public string? Resolution { get; init; }

        /// <summary>
		/// Property that represents laptop color
		/// </summary>
		public string? Color { get; init; }

        /// <summary>
        /// Property that represents laptop image url
        /// </summary>
        public string? ImageUrl { get; init; }

        /// <summary>
		/// Property that represents the date the laptop was added to the database
		/// </summary>
		public string AddedOn { get; init; } = null!;

        /// <summary>
        /// Property that represents how many laptops are in stock
        /// </summary>
		public int Quantity { get; init; }

        /// <summary>
        /// Property that represents laptop Seller
        /// </summary>
        public Client? Seller { get; init; }

		/// <summary>
		/// Property that represents laptop seller first name
		/// </summary>
		public string? SellerFirstName { get; init; }

		/// <summary>
		/// Property that represents laptop seller last name
		/// </summary>
		public string? SellerLastName { get; init; }
    }
}
