namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding collections of types by product type
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
        /// Collection of laptop types
        /// </summary>
        public IList<string> LaptopTypes { get; set; }

        /// <summary>
        /// Collection of monitor types
        /// </summary>
        public IList<string> MonitorTypes { get; set; }

        /// <summary>
        /// Collection of keyboard types
        /// </summary>
        public IList<string> KeyboardTypes { get; set; }
        
        /// <summary>
        /// Collection of mouse types
        /// </summary>
        public IList<string> MouseTypes { get; set; }
        
        /// <summary>
        /// Collection of headphone types
        /// </summary>
        public IList<string> HeadphoneTypes { get; set; }
    }
}
