namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Type model
    /// </summary>
    public class Type
    {
        /// <summary>
        /// Constructor of Type class
        /// </summary>
        public Type()
        {
            this.LaptopTypes = new List<string>();
            this.MonitorTypes = new List<string>();
            this.KeyboardTypes = new List<string>();
            this.MouseTypes = new List<string>();
            this.HeadphoneTypes = new List<string>();
        }

        /// <summary>
        /// Property that represents a collection of laptop types
        /// </summary>
        public IList<string> LaptopTypes { get; set; }

        /// <summary>
        /// Property that represents a collection of monitor types
        /// </summary>
        public IList<string> MonitorTypes { get; set; }

        /// <summary>
        /// Property that represents a collection of keyboard types
        /// </summary>
        public IList<string> KeyboardTypes { get; set; }

        /// <summary>
        /// Property that represents a collection of mouse types
        /// </summary>
        public IList<string> MouseTypes { get; set; }

        /// <summary>
        /// Property that represents a collection of headphone types
        /// </summary>
        public IList<string> HeadphoneTypes { get; set; }
    }
}
