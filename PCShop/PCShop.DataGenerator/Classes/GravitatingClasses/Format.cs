namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Format model
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
        /// Property that represents a collection of keyboard formats
        /// </summary>
        public IList<string> KeyboardFormats { get; set; }
    }
}
