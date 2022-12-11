using PCShop.Core.Constants;

namespace PCShop.Core.Models.Headphone
{
	/// <summary>
	/// AllHeadphonesQueryModel model
	/// </summary>
	public class AllHeadphonesQueryModel
	{
		/// <summary>
		/// Constructor of AllHeadphonesQueryModel class
		/// </summary>
		public AllHeadphonesQueryModel()
		{
			this.Types = Enumerable.Empty<string>();

			this.CurrentPage = 1;

			this.Headphones = Enumerable.Empty<HeadphoneExportViewModel>();
		}

		/// <summary>
		/// Property that represents headphone type
		/// </summary>
		public string? Type { get; init; }

		/// <summary>
		/// Property that represents a collection of all possible headphone types
		/// </summary>
		public IEnumerable<string> Types { get; set; }

		/// <summary>
		/// Property that represents headphone connectivity
		/// </summary>
		public Wireless Wireless { get; init; }

		/// <summary>
		/// Property that represents a search keyword
		/// </summary>
		public string? Keyword { get; init; }

		/// <summary>
		/// Property that represents a sorting criterion
		/// </summary>
		public Sorting Sorting { get; init; }

		/// <summary>
		/// Property that represents the number of the current page
		/// </summary>
		public int CurrentPage { get; init; }

		/// <summary>
		/// Property that represents total count of headphones
		/// </summary>
		public int TotalHeadphonesCount { get; set; }

		/// <summary>
		/// Property that represents a collecion of headphones according to specified criteria
		/// </summary>
		public IEnumerable<HeadphoneExportViewModel> Headphones { get; set; }
	}
}
