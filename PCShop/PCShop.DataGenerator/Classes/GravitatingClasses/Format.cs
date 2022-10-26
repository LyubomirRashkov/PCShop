namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding a collection of keyboard formats
    /// </summary>
    public class Format
    {
        /// <summary>
        /// Constructor of Format class
        /// </summary>
        public Format()
        {
            this.KeyboardFormats = new List<string>();
        }

        /// <summary>
        /// Collection of keyboard formats
        /// </summary>
        public IList<string> KeyboardFormats { get; set; }
    }
}
