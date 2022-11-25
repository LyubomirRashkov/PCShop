using PCShop.Core.Models.Product;

namespace PCShop.Core.Models.Monitor
{
	/// <summary>
	/// MonitorExportViewModel model
	/// </summary>
	public class MonitorExportViewModel : ProductExportViewModel
	{
		/// <summary>
		/// Property that represents monitor display size
		/// </summary>
		public double DisplaySize { get; init; }

		/// <summary>
		/// Property that represents monitor display technology
		/// </summary>
		public string DisplayTechnology { get; init; } = null!;

		/// <summary>
		/// Property that represents monitor resolution
		/// </summary>
		public string Resolution { get; init; } = null!;

		/// <summary>
		/// Property that represents monitor display coverage
		/// </summary>
		public string DisplayCoverage { get; init; } = null!;

		/// <summary>
		/// Property that represents monitor refresh rate
		/// </summary>
		public int RefreshRate { get; init; }
	}
}
