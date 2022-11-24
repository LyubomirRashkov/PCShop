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
			this.Laptops = new List<LaptopExportViewModel>();
		}

		/// <summary>
		/// Property that represents total count of laptops
		/// </summary>
		public int TotalLaptopsCount { get; set; }

		/// <summary>
		/// Property that represents a collection of laptops
		/// </summary>
		public IEnumerable<LaptopExportViewModel> Laptops { get; set; }
	}
}
