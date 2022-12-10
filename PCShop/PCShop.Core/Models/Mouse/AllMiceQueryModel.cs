using PCShop.Core.Constants;

namespace PCShop.Core.Models.Mouse
{
	/// <summary>
	/// AllMiceQueryModel model
	/// </summary>
	public class AllMiceQueryModel
	{
		/// <summary>
		/// Constructor of AllMiceQueryModel class
		/// </summary>
		public AllMiceQueryModel()
		{
			this.Sensitivities = Enumerable.Empty<string>();
			this.Types = Enumerable.Empty<string>();

			this.CurrentPage = 1;

			this.Mice = Enumerable.Empty<MouseExportViewModel>();
		}

		/// <summary>
		/// Property that represents mouse sensitivity
		/// </summary>
		public string? Sensitivity { get; init; }

		/// <summary>
		/// Property that represents a collection of all possible mouse sensitivities
		/// </summary>
		public IEnumerable<string> Sensitivities { get; set; }

		/// <summary>
		/// Property that represents mouse type
		/// </summary>
		public string? Type { get; init; }

		/// <summary>
		/// Property that represents a collection of all possible mouse types
		/// </summary>
		public IEnumerable<string> Types { get; set; }

		/// <summary>
		/// Property that represents mouse connectivity
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
		/// Property that represents total count of mice
		/// </summary>
		public int TotalMiceCount { get; set; }

		/// <summary>
		/// Property that represents a collecion of mice according to specified criteria
		/// </summary>
		public IEnumerable<MouseExportViewModel> Mice { get; set; }
	}
}
