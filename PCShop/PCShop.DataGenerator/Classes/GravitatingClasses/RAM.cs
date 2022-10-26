namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding a collection of laptop RAMs
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
        /// Collection of laptop RAMs
        /// </summary>
        public IList<int> LaptopRAMs { get; set; }
    }
}
