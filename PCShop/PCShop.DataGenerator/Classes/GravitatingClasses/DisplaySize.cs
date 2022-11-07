namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Display size model
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
        /// Property that represents a collection of laptop display sizes
        /// </summary>
        public IList<double> LaptopDisplaySizes { get; set; }

        /// <summary>
        /// Property that represents a collection of monitor display sizes
        /// </summary>
        public IList<double> MonitorDisplaySizes { get; set; }
    }
}
