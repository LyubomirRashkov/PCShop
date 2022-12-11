namespace PCShop.Core.Models.Headphone
{
	/// <summary>
	/// HeadphonesQueryModel model
	/// </summary>
	public class HeadphonesQueryModel
	{
		/// <summary>
		/// Constructor of HeadphonesQueryModel class
		/// </summary>
		public HeadphonesQueryModel()
		{
			this.Headphones = new List<HeadphoneExportViewModel>();
		}

		/// <summary>
		/// Property that represents total count of headphones
		/// </summary>
		public int TotalHeadphonesCount { get; set; }

		/// <summary>
		/// Property that represents a collection of headphones
		/// </summary>
		public IEnumerable<HeadphoneExportViewModel> Headphones { get; set; }
	}
}
