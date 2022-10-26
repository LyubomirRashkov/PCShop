using PCShop.DataGenerator.Classes.BaseClass;

namespace PCShop.DataGenerator.Classes
{
    /// <summary>
    /// Keyboard model
    /// </summary>
    public class Keyboard : Product
    {
        /// <summary>
        /// Keyboard format
        /// </summary>
        public string Format { get; set; } = null!;

        /// <summary>
        /// Keyboard type
        /// </summary>
        public string Type { get; set; } = null!;
    }
}
