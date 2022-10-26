namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding a collection of laptop CPUs
    /// </summary>
    public class CPU
    {
        /// <summary>
        /// Constructor of CPU class
        /// </summary>
        public CPU()
        {
            this.LaptopCPUs = new List<string>();
        }

        /// <summary>
        /// Collection holding laptop CPUs
        /// </summary>
        public IList<string> LaptopCPUs { get; set; }
    }
}
