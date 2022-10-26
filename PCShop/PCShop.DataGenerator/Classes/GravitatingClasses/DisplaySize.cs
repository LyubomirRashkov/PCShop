namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding collections of display sizes by product type
    /// </summary>
    public class DisplaySize
    {
        /// <summary>
        /// Constructor of DisplaySize class
        /// </summary>
        public DisplaySize()
        {
            this.LaptopDisplaySizes = new List<double>();
            this.MonitorDisplaySizes = new List<double>();
        }

        /// <summary>
        /// Collection of laptop display sizes
        /// </summary>
        public IList<double> LaptopDisplaySizes { get; set; }

        /// <summary>
        /// Collection of monitor display sizes
        /// </summary>
        public IList<double> MonitorDisplaySizes { get; set; }
    }
}
