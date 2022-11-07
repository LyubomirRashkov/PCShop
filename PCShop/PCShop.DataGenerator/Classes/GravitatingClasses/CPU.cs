namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// CPU model
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
        /// Property that represents a collection of laptop CPUs
        /// </summary>
        public IList<string> LaptopCPUs { get; set; }
    }
}
