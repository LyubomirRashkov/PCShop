namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding collections of brands by product type
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
        /// Collection of laptop brands
        /// </summary>
        public IList<string> LaptopBrands { get; set; }

        /// <summary>
        /// Collection of monitor brands
        /// </summary>
        public IList<string> MonitorBrands { get; set; }

        /// <summary>
        /// Collection of keyboard brands
        /// </summary>
        public IList<string> KeyboardBrands { get; set; }

        /// <summary>
        /// Collection of mouse brands
        /// </summary>
        public IList<string> MouseBrands { get; set; }

        /// <summary>
        /// Collection of headphone brands
        /// </summary>
        public IList<string> HeadphoneBrands { get; set; }

        /// <summary>
        /// Collection of microphone brands
        /// </summary>
        public IList<string> MicrophoneBrands { get; set; }
    }
}
