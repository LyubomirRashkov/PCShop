namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Resolution model
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
        /// Property that represents a collection of laptop resolutions
        /// </summary>
        public IList<string> LaptopResolutions { get; set; }

        /// <summary>
        /// Property that represents a collection of monitor resolutions
        /// </summary>
        public IList<string> MonitorResolutions { get; set; }
    }
}
