namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Brand model
    /// </summary>
    public class Brand
    {
        /// <summary>
        /// Constructor of Brand class
        /// </summary>
        public Brand()
        {
            this.LaptopBrands = new List<string>();
            this.MonitorBrands = new List<string>();
            this.KeyboardBrands = new List<string>();
            this.MouseBrands = new List<string>();
            this.HeadphoneBrands = new List<string>();
            this.MicrophoneBrands = new List<string>();
        }

        /// <summary>
        /// Property that represents a collection of laptop brands
        /// </summary>
        public IList<string> LaptopBrands { get; set; }

        /// <summary>
        /// Property that represents a collection of monitor brands
        /// </summary>
        public IList<string> MonitorBrands { get; set; }

        /// <summary>
        /// Property that represents a collection of keyboard brands
        /// </summary>
        public IList<string> KeyboardBrands { get; set; }

        /// <summary>
        /// Property that represents a collection of mouse brands
        /// </summary>
        public IList<string> MouseBrands { get; set; }

        /// <summary>
        /// Property that represents a collection of headphone brands
        /// </summary>
        public IList<string> HeadphoneBrands { get; set; }

        /// <summary>
        /// Property that represents a collection of microphone brands
        /// </summary>
        public IList<string> MicrophoneBrands { get; set; }
    }
}
