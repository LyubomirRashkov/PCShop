using PCShop.DataGenerator.Classes.BaseClass;

namespace PCShop.DataGenerator.Classes
{
    /// <summary>
    /// Monitor model
    /// </summary>
    public class Monitor : Product
    {
        /// <summary>
        /// Property that represents monitor display size
        /// </summary>
        public double DisplaySize { get; set; }

        /// <summary>
        /// Property that represents monitor type
        /// </summary>
        public string Type { get; set; } = null!;

        /// <summary>
        /// Property that represents monitor display technology
        /// </summary>
        public string DisplayTechnology { get; set; } = null!;

        /// <summary>
        /// Property that represents monitor display coverage
        /// </summary>
        public string DisplayCoverage { get; set; } = null!;

        /// <summary>
        /// Property that represents monitor display resolution
        /// </summary>
        public string Resolution { get; set; } = null!;

        /// <summary>
        /// Property that represents monitor refresh rate
        /// </summary>
        public int RefreshRate { get; set; }
    }
}
