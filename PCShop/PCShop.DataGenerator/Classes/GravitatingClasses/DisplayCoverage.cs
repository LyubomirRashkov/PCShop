namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding a collection of display coverages
    /// </summary>
    public class DisplayCoverage
    {
        /// <summary>
        /// Constructor of DisplayCoverage class
        /// </summary>
        public DisplayCoverage()
        {
            this.DisplayCoverages = new List<string>();
        }

        /// <summary>
        /// Collection holding display coverages
        /// </summary>
        public IList<string> DisplayCoverages { get; set; }
    }
}
