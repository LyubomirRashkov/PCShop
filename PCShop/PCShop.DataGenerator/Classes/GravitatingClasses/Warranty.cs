namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Warranty model
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
        /// Property that represents a collection of product warranties
        /// </summary>
        public IList<int> Warranties { get; set; }
    }
}
