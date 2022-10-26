namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding a collection of display technologies
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
        /// Collection holding display technologies
        /// </summary>
        public IList<string> DisplayTechnologies { get; set; }
    }
}
