namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// RefreshRate model
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
        /// Property that represents a collection of monitor refresh rates
        /// </summary>
        public IList<int> RefreshRates { get; set; }
    }
}
