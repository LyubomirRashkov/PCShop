namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Display conerage model
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
        /// Property that represents a collection of display coverages
        /// </summary>
        public IList<string> DisplayCoverages { get; set; }
    }
}
