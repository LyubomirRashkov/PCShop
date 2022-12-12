using PCShop.Core.Constants;
using PCShop.Core.Models.Product;

namespace PCShop.Core.Models.Keyboard
{
	/// <summary>
	/// AllKeyboardsQueryModel model
	/// </summary>
	public class AllKeyboardsQueryModel : AllProductsQueryModel
	{
		/// <summary>
		/// Constructor of AllKeyboardsQueryModel class
		/// </summary>
		public AllKeyboardsQueryModel()
		{
			this.Formats = Enumerable.Empty<string>();
			this.Types = Enumerable.Empty<string>();

			this.CurrentPage = 1;

			this.Keyboards = Enumerable.Empty<KeyboardExportViewModel>();
		}

		/// <summary>
		/// Property that represents keyboard format
		/// </summary>
		public string? Format { get; init; }

		/// <summary>
		/// Property that represents a collection of all possible keyboard formats
		/// </summary>
		public IEnumerable<string> Formats { get; set; }

		/// <summary>
		/// Property that represents keyboard type
		/// </summary>
		public string? Type { get; init; }

		/// <summary>
		/// Property that represents a collection of all possible keyboard types
		/// </summary>
		public IEnumerable<string> Types { get; set; }

		/// <summary>
		/// Property that represents keyboard connectivity
		/// </summary>
		public Wireless Wireless { get; init; }

		/// <summary>
		/// Property that represents a collecion of keyboards according to specified criteria
		/// </summary>
		public IEnumerable<KeyboardExportViewModel> Keyboards { get; set; }
	}
}
