using PCShop.Core.Constants;

namespace PCShop.Core.Models.Laptop
{
	/// <summary>
	/// LaptopsQueryModel model
	/// </summary>
	public class LaptopsQueryModel
	{
		/// <summary>
		/// Constructor of LaptopsQueryModel class
		/// </summary>
		public LaptopsQueryModel()
		{
			this.Cpus = Enumerable.Empty<string>();
			this.Rams = Enumerable.Empty<int>();
			this.SsdCapacities = Enumerable.Empty<int>();
			this.VideoCards = Enumerable.Empty<string>();
			this.Laptops = Enumerable.Empty<LaptopExportViewModel>();
		}

		/// <summary>
		/// Property that represents laptop CPU model
		/// </summary>
		public string? Cpu { get; set; }

		/// <summary>
		/// Property that represents a collection of all possible laptop CPU models
		/// </summary>
		public IEnumerable<string> Cpus { get; set; }

		/// <summary>
		/// Propeerty that represents laptop RAM
		/// </summary>
		public int? Ram { get; set; }

		/// <summary>
		/// Property that represents a collection of all possible laptop RAMs
		/// </summary>
		public IEnumerable<int> Rams { get; set; }

		/// <summary>
		/// Property that represents laptop SSD capacity
		/// </summary>
		public int? SsdCapacity { get; set; }

		/// <summary>
		/// Property that represents all possible laptop SSD capacities
		/// </summary>
		public IEnumerable<int> SsdCapacities { get; set; }

		/// <summary>
		/// Property that represents laptop video card model
		/// </summary>
		public string? VideoCard { get; set; }

		/// <summary>
		/// Property that represents all possible laptop video card models
		/// </summary>
		public IEnumerable<string> VideoCards { get; set; }

		/// <summary>
		/// Property that represent a seacrh keyword
		/// </summary>
		public string? KeyWord { get; set; }

		/// <summary>
		/// Property that represents a sorting criterion
		/// </summary>
		public Sorting Sorting { get; set; }

		/// <summary>
		/// Property that represents a collecion of laptops according to specified criteria
		/// </summary>
		public IEnumerable<LaptopExportViewModel> Laptops { get; set; }
	}
}
