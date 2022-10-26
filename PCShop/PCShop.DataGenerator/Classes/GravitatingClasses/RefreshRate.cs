namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding a collection of monitor refresh rates
    /// </summary>
    public class RefreshRate
    {
        /// <summary>
        /// Constructor of RefreshRate class
        /// </summary>
        public RefreshRate()
        {
            this.RefreshRates = new List<int>();
        }

        /// <summary>
        /// Collection of monitor refresh rates
        /// </summary>
        public IList<int> RefreshRates { get; set; }
    }
}
