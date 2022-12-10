using PCShop.Infrastructure.Data.Models;

namespace PCShop.Core.Models.Mouse
{
	/// <summary>
	/// MouseDetailsExportViewModel model
	/// </summary>
	public class MouseDetailsExportViewModel : MouseExportViewModel
	{
		/// <summary>
		/// Property that represents mouse color
		/// </summary>
		public string? Color { get; init; }

		/// <summary>
		/// Property that represents mouse image url
		/// </summary>
		public string? ImageUrl { get; init; }

		/// <summary>
		/// Property that represents the date the mouse was added to the database
		/// </summary>
		public string AddedOn { get; init; } = null!;

		/// <summary>
		/// Property that represents how many mice are in stock
		/// </summary>
		public int Quantity { get; init; }

		/// <summary>
		/// Property that represents mouse Seller
		/// </summary>
		public Client? Seller { get; init; }

		/// <summary>
		/// Property that represents mouse seller first name
		/// </summary>
		public string? SellerFirstName { get; init; }

		/// <summary>
		/// Property that represents mouse seller last name
		/// </summary>
		public string? SellerLastName { get; init; }
	}
}
