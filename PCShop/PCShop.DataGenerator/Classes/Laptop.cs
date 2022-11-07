using PCShop.DataGenerator.Classes.BaseClass;

namespace PCShop.DataGenerator.Classes
{
    /// <summary>
    /// Laptop model
    /// </summary>
    public class Laptop : Product
    {
        /// <summary>
        /// Property that represents laptop CPU
        /// </summary>
        public string CPU { get; set; } = null!;

        /// <summary>
        /// Property that represents laptop RAM
        /// </summary>
        public int RAM { get; set; }

        /// <summary>
        /// Property that represents laptop SSD capacity
        /// </summary>
        public int SSDCapacity { get; set; }

        /// <summary>
        /// Property that represents laptop video card
        /// </summary>
        public string VideoCard { get; set; } = null!;

        /// <summary>
        /// Property that represents laptop type
        /// </summary>
        public string Type { get; set; } = null!;

        /// <summary>
        /// Property that represents laptop display size
        /// </summary>
        public double DisplaySize { get; set; }

        /// <summary>
        /// Property that represents laptop display coverage
        /// </summary>
        public string DisplayCoverage { get; set; } = null!;

        /// <summary>
        /// Property that represents laptop display technology
        /// </summary>
        public string DisplayTechnology { get; set; } = null!;

        /// <summary>
        /// Property that represents laptop display resolution
        /// </summary>
        public string Resolution { get; set; } = null!;
    }
}
