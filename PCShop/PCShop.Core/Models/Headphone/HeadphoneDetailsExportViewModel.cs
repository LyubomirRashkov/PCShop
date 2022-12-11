using PCShop.Infrastructure.Data.Models;

namespace PCShop.Core.Models.Headphone
{
	/// <summary>
	/// HeadphoneDetailsExportViewModel model
	/// </summary>
	public class HeadphoneDetailsExportViewModel : HeadphoneExportViewModel
	{
		/// <summary>
		/// Property that represents headphone color
		/// </summary>
		public string? Color { get; init; }

		/// <summary>
		/// Property that represents headphone image url
		/// </summary>
		public string? ImageUrl { get; init; }

		/// <summary>
		/// Property that represents the date the headphone was added to the database
		/// </summary>
		public string AddedOn { get; init; } = null!;

		/// <summary>
		/// Property that represents how many headphones are in stock
		/// </summary>
		public int Quantity { get; init; }

		/// <summary>
		/// Property that represents headphone Seller
		/// </summary>
		public Client? Seller { get; init; }

		/// <summary>
		/// Property that represents headphone seller first name
		/// </summary>
		public string? SellerFirstName { get; init; }

		/// <summary>
		/// Property that represents headphone seller last name
		/// </summary>
		public string? SellerLastName { get; init; }
	}
}
