namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Display technology model
    /// </summary>
    public class DisplayTechnology
    {
        /// <summary>
        /// Constructor of DisplayTechnology class
        /// </summary>
        public DisplayTechnology()
        {
            this.DisplayTechnologies = new List<string>();
        }

        /// <summary>
        /// Property that represents a collection of display technologies
        /// </summary>
        public IList<string> DisplayTechnologies { get; set; }
    }
}
