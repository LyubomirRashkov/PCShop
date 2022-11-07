using PCShop.DataGenerator.Classes.BaseClass;

namespace PCShop.DataGenerator.Classes
{
    /// <summary>
    /// Mouse model
    /// </summary>
    public class Mouse : Product
    {
        /// <summary>
        /// Property that represents mouse type
        /// </summary>
        public string Type { get; set; } = null!;

        /// <summary>
        /// Property that represents mouse sensitivity
        /// </summary>
        public string Sensitivity { get; set; } = null!;
    }
}
