using PCShop.DataGenerator.Classes.BaseClass;

namespace PCShop.DataGenerator.Classes
{
    /// <summary>
    /// Keyboard model
    /// </summary>
    public class Keyboard : Product
    {
        /// <summary>
        /// Property that represents keyboard format
        /// </summary>
        public string Format { get; set; } = null!;

        /// <summary>
        /// Property that represents keyboard type
        /// </summary>
        public string Type { get; set; } = null!;
    }
}
