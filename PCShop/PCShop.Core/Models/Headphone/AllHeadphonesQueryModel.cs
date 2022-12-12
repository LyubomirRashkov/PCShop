using PCShop.Core.Constants;
using PCShop.Core.Models.Product;

namespace PCShop.Core.Models.Headphone
{
	/// <summary>
	/// AllHeadphonesQueryModel model
	/// </summary>
	public class AllHeadphonesQueryModel : AllProductsQueryModel
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
		/// Property that represents a collecion of headphones according to specified criteria
		/// </summary>
		public IEnumerable<HeadphoneExportViewModel> Headphones { get; set; }
	}
}
