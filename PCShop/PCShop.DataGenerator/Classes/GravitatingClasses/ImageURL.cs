namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding collections of URLs of images by product type
    /// </summary>
    public class ImageURL
    {
        /// <summary>
        /// Constructor of ImageURL class
        /// </summary>
        public ImageURL()
        {
            this.LaptopImageURLs = new List<string>();
            this.MonitorImageURLs = new List<string>();
            this.KeyboardImageURLs = new List<string>();
            this.MouseImageURLs = new List<string>();
            this.HeadphoneImageURLs = new List<string>();
            this.MicrophoneImageURLs = new List<string>();
        }

        /// <summary>
        /// Collection of URLs of images of laptops
        /// </summary>
        public IList<string> LaptopImageURLs { get; set; }

        /// <summary>
        /// Collection of URLs of images of monitors
        /// </summary>
        public IList<string> MonitorImageURLs { get; set; }

        /// <summary>
        /// Collection of URLs of images of keyboards
        /// </summary>
        public IList<string> KeyboardImageURLs { get; set; }

        /// <summary>
        /// Collection of URLs of images of mice
        /// </summary>
        public IList<string> MouseImageURLs { get; set; }

        /// <summary>
        /// Collection of URLs of images of headphones
        /// </summary>
        public IList<string> HeadphoneImageURLs { get; set; }

        /// <summary>
        /// Collection of URLs of images of microphones
        /// </summary>
        public IList<string> MicrophoneImageURLs { get; set; }
    }
}
