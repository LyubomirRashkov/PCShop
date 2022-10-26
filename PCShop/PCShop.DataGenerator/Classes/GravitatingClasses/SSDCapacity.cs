namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding a collection of laptop SSD capacities
    /// </summary>
    public class SSDCapacity
    {
        /// <summary>
        /// Constructor of SSDCapacity class
        /// </summary>
        public SSDCapacity()
        {
            this.LaptopSSDCapacities = new List<int>();
        }

        /// <summary>
        /// Collection of laptop SSD capacities
        /// </summary>
        public IList<int> LaptopSSDCapacities { get; set; }
    }
}
