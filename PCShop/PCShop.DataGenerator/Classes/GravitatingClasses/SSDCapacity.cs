namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// SSDCapacity model
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
        /// Property that represents a collection of laptop SSD capacities
        /// </summary>
        public IList<int> LaptopSSDCapacities { get; set; }
    }
}
