namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding a collection of product warranties
    /// </summary>
    public class Warranty
    {
        /// <summary>
        /// Constructor of Warranty class
        /// </summary>
        public Warranty()
        {
            this.Warranties = new List<int>();
        }

        /// <summary>
        /// Collection of product warranties
        /// </summary>
        public IList<int> Warranties { get; set; }
    }
}
