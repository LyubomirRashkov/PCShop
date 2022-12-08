using PCShop.Core.Models.Product;

namespace PCShop.Core.Models.Keyboard
{
	/// <summary>
	/// LaptopExportViewModel model
	/// </summary>
	public class KeyboardExportViewModel : ProductExportViewModel, IProductModel
	{
		/// <summary>
		/// Property that represents if the keyboard is wireless
		/// </summary>
		public bool Wireless { get; init; }

		/// <summary>
		/// Property that represents keyboard type
		/// </summary>
		public string Type { get; init; } = null!;

		/// <summary>
		/// Property that represents keyboard format
		/// </summary>
		public string? Format { get; init; }
	}
}
