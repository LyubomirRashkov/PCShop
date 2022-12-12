using PCShop.Core.Constants;

namespace PCShop.Core.Models.Product
{
	/// <summary>
	/// AllProductsQueryModel model
	/// </summary>
	public abstract class AllProductsQueryModel
	{
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
		public int CurrentPage { get; init; } = 1;

		/// <summary>
		/// Property that represents total count of products
		/// </summary>
		public int TotalProductsCount { get; set; }
	}
}
