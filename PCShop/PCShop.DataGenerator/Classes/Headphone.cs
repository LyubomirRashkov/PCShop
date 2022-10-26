using PCShop.DataGenerator.Classes.BaseClass;

namespace PCShop.DataGenerator.Classes
{
    /// <summary>
    /// Headphone model
    /// </summary>
    public class Headphone : Product
    {
        /// <summary>
        /// Headphone type
        /// </summary>
        public string Type { get; set; } = null!;
    }
}
