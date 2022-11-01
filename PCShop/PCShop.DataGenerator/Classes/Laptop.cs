using PCShop.DataGenerator.Classes.BaseClass;

namespace PCShop.DataGenerator.Classes
{
    /// <summary>
    /// Laptop model
    /// </summary>
    public class Laptop : Product
    {
        /// <summary>
        /// Laptop CPU
        /// </summary>
        public string CPU { get; set; } = null!;

        /// <summary>
        /// Laptop RAM
        /// </summary>
        public int RAM { get; set; }

        /// <summary>
        /// Laptop SSD capacity
        /// </summary>
        public int SSDCapacity { get; set; }

        /// <summary>
        /// Laptop video card
        /// </summary>
        public string VideoCard { get; set; } = null!;

        /// <summary>
        /// Laptop type
        /// </summary>
        public string Type { get; set; } = null!;

        /// <summary>
        /// Laptop display size
        /// </summary>
        public double DisplaySize { get; set; }

        /// <summary>
        /// Laptop display coverage
        /// </summary>
        public string DisplayCoverage { get; set; } = null!;

        /// <summary>
        /// Laptop display technology
        /// </summary>
        public string DisplayTechnology { get; set; } = null!;

        /// <summary>
        /// Laptop display resolution
        /// </summary>
        public string Resolution { get; set; } = null!;
    }
}
