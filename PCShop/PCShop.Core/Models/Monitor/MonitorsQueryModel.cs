namespace PCShop.Core.Models.Monitor
{
	/// <summary>
	/// MonitorsQueryModel model
	/// </summary>
	public class MonitorsQueryModel
	{
		/// <summary>
		/// Constructor of MonitorsQueryModel
		/// </summary>
		public MonitorsQueryModel()
		{
			this.Monitors = new List<MonitorExportViewModel>();
		}

		/// <summary>
		/// Property that represents total count of monitors
		/// </summary>
		public int TotalMonitorsCount { get; set; }

		/// <summary>
		/// Property that represents a collection of monitors
		/// </summary>
		public IEnumerable<MonitorExportViewModel> Monitors { get; set; }
	}
}
