using PCShop.Core.Constants;
using PCShop.Core.Models.Product;

namespace PCShop.Core.Models.Monitor
{
	/// <summary>
	/// AllMonitorsQueryModel model
	/// </summary>
	public class AllMonitorsQueryModel : AllProductsQueryModel
	{
		/// <summary>
		/// Constructor of AllMonitorsQueryModel class
		/// </summary>
		public AllMonitorsQueryModel()
		{
			this.Brands = Enumerable.Empty<string>();
			this.DisplaySizes = Enumerable.Empty<double>();
			this.Resolutions = Enumerable.Empty<string>();
			this.RefreshRates = Enumerable.Empty<int>();

			this.CurrentPage = 1;

			this.Monitors = Enumerable.Empty<MonitorExportViewModel>();
		}

		/// <summary>
		/// Property that represents monitor brand
		/// </summary>
		public string? Brand { get; init; }

		/// <summary>
		/// Property that represents a collection of all possible monitor brands
		/// </summary>
		public IEnumerable<string> Brands { get; set; }

		/// <summary>
		/// Property that represents monitor display size
		/// </summary>
		public double? DisplaySize { get; init; }

		/// <summary>
		/// Property that represents a collection of all possible monitor display sizes
		/// </summary>
		public IEnumerable<double> DisplaySizes { get; set; }

		/// <summary>
		/// Property that represents monitor resolution
		/// </summary>
		public string? Resolution { get; init; }

		/// <summary>
		/// Property that represents a collection of all possible monitor resolutions
		/// </summary>
		public IEnumerable<string> Resolutions { get; set; }

		/// <summary>
		/// Property that represents monitorr refresh rate
		/// </summary>
		public int? RefreshRate { get; init; }

		/// <summary>
		/// Property that represents a collection of all possible monitor refresh rates
		/// </summary>
		public IEnumerable<int> RefreshRates { get; set; }

		/// <summary>
		/// Property that represents a collecion of monitors according to specified criteria
		/// </summary>
		public IEnumerable<MonitorExportViewModel> Monitors { get; set; }
	}
}
