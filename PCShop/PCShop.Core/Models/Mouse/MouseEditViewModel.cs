using PCShop.Infrastructure.Data.Models;

namespace PCShop.Core.Models.Mouse
{
    /// <summary>
    /// MouseEditViewModel model
    /// </summary>
    public class MouseEditViewModel : MouseImportViewModel, IProductModel
    {
        /// <summary>
		/// Property that represents mouse unique identifier
		/// </summary>
		public int Id { get; init; }

        /// <summary>
        /// Property that represents mouse Seller
        /// </summary>
        public Client? Seller { get; init; }
    }
}
