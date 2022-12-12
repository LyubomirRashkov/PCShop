using PCShop.Infrastructure.Data.Models;

namespace PCShop.Core.Models.Microphone
{
	/// <summary>
	/// MicrophoneDetailsExportViewModel model
	/// </summary>
	public class MicrophoneDetailsExportViewModel : MicrophoneExportViewModel
	{
		/// <summary>
		/// Property that represents microphone color
		/// </summary>
		public string? Color { get; init; }

		/// <summary>
		/// Property that represents microphone image url
		/// </summary>
		public string? ImageUrl { get; init; }

		/// <summary>
		/// Property that represents the date the microphone was added to the database
		/// </summary>
		public string AddedOn { get; init; } = null!;

		/// <summary>
		/// Property that represents how many microphones are in stock
		/// </summary>
		public int Quantity { get; init; }

		/// <summary>
		/// Property that represents microphone Seller
		/// </summary>
		public Client? Seller { get; init; }

		/// <summary>
		/// Property that represents microphone seller first name
		/// </summary>
		public string? SellerFirstName { get; init; }

		/// <summary>
		/// Property that represents microphone seller last name
		/// </summary>
		public string? SellerLastName { get; init; }
	}
}
