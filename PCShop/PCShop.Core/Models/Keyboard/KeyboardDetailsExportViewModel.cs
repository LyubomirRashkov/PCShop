using PCShop.Infrastructure.Data.Models;

namespace PCShop.Core.Models.Keyboard
{
	/// <summary>
	/// KeyboardDetailsExportViewModel model
	/// </summary>
	public class KeyboardDetailsExportViewModel : KeyboardExportViewModel
	{
		/// <summary>
		/// Property that represents keyboard color
		/// </summary>
		public string? Color { get; init; }

		/// <summary>
		/// Property that represents keyboard image url
		/// </summary>
		public string? ImageUrl { get; init; }

		/// <summary>
		/// Property that represents the date the keyboard was added to the database
		/// </summary>
		public string AddedOn { get; init; } = null!;

		/// <summary>
		/// Property that represents how many keyboards are in stock
		/// </summary>
		public int Quantity { get; init; }

		/// <summary>
		/// Property that represents keyboard Seller
		/// </summary>
		public Client? Seller { get; init; }

		/// <summary>
		/// Property that represents keyboard seller first name
		/// </summary>
		public string? SellerFirstName { get; init; }

		/// <summary>
		/// Property that represents keyboard seller last name
		/// </summary>
		public string? SellerLastName { get; init; }
	}
}
