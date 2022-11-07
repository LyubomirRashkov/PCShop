using PCShop.DataGenerator.Classes.BaseClass;

namespace PCShop.DataGenerator.Classes
{
    /// <summary>
    /// Headphone model
    /// </summary>
    public class Headphone : Product
    {
        /// <summary>
        /// Property that represents headphone type
        /// </summary>
        public string Type { get; set; } = null!;
    }
}
