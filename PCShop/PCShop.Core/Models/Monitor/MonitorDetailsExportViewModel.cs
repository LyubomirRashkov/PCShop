using PCShop.Infrastructure.Data.Models;

namespace PCShop.Core.Models.Monitor
{
	/// <summary>
	/// MonitorDetailsExportViewModel model
	/// </summary>
	public class MonitorDetailsExportViewModel : MonitorExportViewModel
	{
		/// <summary>
		/// Property that represents monitor type
		/// </summary>
		public string Type { get; init; } = null!;

		/// <summary>
		/// Property that represents monitor color
		/// </summary>
		public string? Color { get; init; }

		/// <summary>
		/// Property that represents monitor image url
		/// </summary>
		public string? ImageUrl { get; init; }

		/// <summary>
		/// Property that represents the date the monitor was added to the database
		/// </summary>
		public string AddedOn { get; init; } = null!;

		/// <summary>
		/// Property that represents how many monitors are in stock
		/// </summary>
		public int Quantity { get; init; }

		/// <summary>
		/// Property that represents monior Seller
		/// </summary>
		public Client? Seller { get; init; }

		/// <summary>
		/// Property that represents monitor seller first name
		/// </summary>
		public string? SellerFirstName { get; init; }

		/// <summary>
		/// Property that represents monitor seller last name
		/// </summary>
		public string? SellerLastName { get; init; }
	}
}
