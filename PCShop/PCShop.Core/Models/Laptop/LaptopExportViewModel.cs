using PCShop.Core.Models.Product;

namespace PCShop.Core.Models.Laptop
{
    /// <summary>
    /// LaptopExportViewModel model
    /// </summary>
    public class LaptopExportViewModel : ProductExportViewModel, IProductModel
    {
        /// <summary>
        /// Property that represents laptop CPU
        /// </summary>
        public string CPU { get; init; } = null!;

        /// <summary>
        /// Property that represents laptop RAM
        /// </summary>
        public int RAM { get; init; }

        /// <summary>
        /// Property that represents laptop SSD capacity
        /// </summary>
        public int SSDCapacity { get; init; }

        /// <summary>
        /// Property that represents laptop video card
        /// </summary>
        public string VideoCard { get; init; } = null!;

        /// <summary>
        /// Property that represents laptop display size
        /// </summary>
        public double DisplaySize { get; init; }
    }
}
