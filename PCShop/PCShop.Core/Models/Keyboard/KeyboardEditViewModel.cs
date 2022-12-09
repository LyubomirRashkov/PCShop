using PCShop.Infrastructure.Data.Models;

namespace PCShop.Core.Models.Keyboard
{
	/// <summary>
	/// KeyboardEditViewModel model
	/// </summary>
	public class KeyboardEditViewModel : KeyboardImportViewModel, IProductModel
	{
		/// <summary>
		/// Property that represents keyboard unique identifier
		/// </summary>
		public int Id { get; init; }

		/// <summary>
		/// Property that represents keyboard Seller
		/// </summary>
		public Client? Seller { get; init; }
	}
}
