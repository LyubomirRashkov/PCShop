using PCShop.Core.Models.Product;

namespace PCShop.Core.Models.Headphone
{
	/// <summary>
	/// HeadphoneExportViewModel model
	/// </summary>
	public class HeadphoneExportViewModel : ProductExportViewModel, IProductModel
	{
		/// <summary>
		/// Property that represents headphone type
		/// </summary>
		public string Type { get; init; } = null!;

		/// <summary>
		/// Property that represents if the headphone is wireless
		/// </summary>
		public bool IsWireless { get; init; }

		/// <summary>
		/// Property that represents if the headphone has a microphone
		/// </summary>
		public bool HasMicrophone { get; init; }
	}
}
