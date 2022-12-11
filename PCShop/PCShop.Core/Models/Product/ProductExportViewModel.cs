namespace PCShop.Core.Models.Product
{
	/// <summary>
	/// ProductExportViewModel model
	/// </summary>
	public abstract class ProductExportViewModel
	{
		/// <summary>
		/// Property that represents product unique identifier
		/// </summary>
		public int Id { get; init; }

		/// <summary>
		/// Property that represents product brand
		/// </summary>
		public string Brand { get; init; } = null!;

		/// <summary>
		/// Property that represents product price
		/// </summary>
		public decimal? Price { get; init; }

		/// <summary>
		/// Property that represents product warranty
		/// </summary>
		public int Warranty { get; init; }
	}
}
