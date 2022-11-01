using PCShop.DataGenerator.Classes.BaseClass;

namespace PCShop.DataGenerator.Classes
{
    /// <summary>
    /// Monitor model
    /// </summary>
    public class Monitor : Product
    {
        /// <summary>
        /// Monitor display size
        /// </summary>
        public double DisplaySize { get; set; }

        /// <summary>
        /// Monitor type
        /// </summary>
        public string Type { get; set; } = null!;

        /// <summary>
        /// Monitor display technology
        /// </summary>
        public string DisplayTechnology { get; set; } = null!;

        /// <summary>
        /// Monitor display coverage
        /// </summary>
        public string DisplayCoverage { get; set; } = null!;

        /// <summary>
        /// Monitor display resolution
        /// </summary>
        public string Resolution { get; set; } = null!;

        /// <summary>
        /// Monitor refresh rate
        /// </summary>
        public int RefreshRate { get; set; }
    }
}
