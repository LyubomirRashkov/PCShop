namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding collections of resolutions by product type
    /// </summary>
    public class Resolution
    {
        /// <summary>
        /// Constructor of Resolution class
        /// </summary>
        public Resolution()
        {
            this.LaptopResolutions = new List<string>();
            this.MonitorResolutions = new List<string>();
        }

        /// <summary>
        /// Collection of laptop resolutions
        /// </summary>
        public IList<string> LaptopResolutions { get; set; }

        /// <summary>
        /// Collection of monitor resolutions
        /// </summary>
        public IList<string> MonitorResolutions { get; set; }
    }
}
