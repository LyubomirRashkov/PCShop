using PCShop.Infrastructure.Data.Models;

namespace PCShop.Core.Models.Monitor
{
    /// <summary>
    /// MonitorEditViewModel model
    /// </summary>
    public class MonitorEditViewModel : MonitorImportViewModel, IProductModel
    {
        /// <summary>
        /// Property that represents monitor unique identifier
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Property thaat represents monitor Seller
        /// </summary>
        public Client? Seller { get; init; }
    }
}
