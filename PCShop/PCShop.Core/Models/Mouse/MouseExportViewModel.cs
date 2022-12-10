using PCShop.Core.Models.Product;

namespace PCShop.Core.Models.Mouse
{
	/// <summary>
	/// MouseExportViewModel model
	/// </summary>
	public class MouseExportViewModel : ProductExportViewModel, IProductModel
	{
		/// <summary>
		/// Property that represents if the mouse is wireless
		/// </summary>
		public bool IsWireless { get; init; }

		/// <summary>
		/// Property that represents mouse type
		/// </summary>
		public string Type { get; init; } = null!;

		/// <summary>
		/// Property that represents mouse sensitivity
		/// </summary>
		public string Sensitivity { get; init; } = null!;
	}
}
