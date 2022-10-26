using PCShop.DataGenerator.Classes.BaseClass;

namespace PCShop.DataGenerator.Classes
{
    /// <summary>
    /// Mouse model
    /// </summary>
    public class Mouse : Product
    {
        /// <summary>
        /// Mouse type
        /// </summary>
        public string Type { get; set; } = null!;

        /// <summary>
        /// Mouse sensitivity
        /// </summary>
        public string Sensitivity { get; set; } = null!;
    }
}
