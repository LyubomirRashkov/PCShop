namespace PCShop.Core.Models.Mouse
{
	/// <summary>
	/// MiceQueryModel model
	/// </summary>
	public class MiceQueryModel
	{
		/// <summary>
		/// Constructor of MiceQueryModel class
		/// </summary>
		public MiceQueryModel()
		{
			this.Mice = new List<MouseExportViewModel>();
		}

		/// <summary>
		/// Property that represents total count of mice
		/// </summary>
		public int TotalMiceCount { get; set; }

		/// <summary>
		/// Property that represents a collection of mice
		/// </summary>
		public IEnumerable<MouseExportViewModel> Mice { get; set; }
	}
}
