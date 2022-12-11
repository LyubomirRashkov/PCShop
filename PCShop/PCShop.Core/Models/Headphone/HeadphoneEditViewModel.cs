using PCShop.Infrastructure.Data.Models;

namespace PCShop.Core.Models.Headphone
{
	/// <summary>
	/// HeadphoneEditViewModel model
	/// </summary>
	public class HeadphoneEditViewModel : HeadphoneImportViewModel, IProductModel
	{
		/// <summary>
		/// Property that represents headphone unique identifier
		/// </summary>
		public int Id { get; init; }

		/// <summary>
		/// Property that represents headphone Seller
		/// </summary>
		public Client? Seller { get; init; }
	}
}
