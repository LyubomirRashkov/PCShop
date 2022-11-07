namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// RAM model
    /// </summary>
    public class RAM
    {
        /// <summary>
        /// Constructor of RAM class
        /// </summary>
        public RAM()
        {
            this.LaptopRAMs = new List<int>();
        }

        /// <summary>
        /// Property that represents a collection of laptop RAMs
        /// </summary>
        public IList<int> LaptopRAMs { get; set; }
    }
}
