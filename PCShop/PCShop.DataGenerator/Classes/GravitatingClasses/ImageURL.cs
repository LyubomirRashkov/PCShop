namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// ImageUrl model
    /// </summary>
    public class ImageUrl
    {
        /// <summary>
        /// Constructor of ImageURL class
        /// </summary>
        public ImageUrl()
        {
            this.LaptopImageUrls = new List<string>();
            this.MonitorImageUrls = new List<string>();
            this.KeyboardImageUrls = new List<string>();
            this.MouseImageUrls = new List<string>();
            this.HeadphoneImageUrls = new List<string>();
            this.MicrophoneImageUrls = new List<string>();
        }

        /// <summary>
        /// Property that represents a collection of Urls of images of laptops
        /// </summary>
        public IList<string> LaptopImageUrls { get; set; }

        /// <summary>
        /// Property that represents a collection of Urls of images of monitors
        /// </summary>
        public IList<string> MonitorImageUrls { get; set; }

        /// <summary>
        /// Property that represents a collection of Urls of images of keyboards
        /// </summary>
        public IList<string> KeyboardImageUrls { get; set; }

        /// <summary>
        /// Property that represents a collection of Urls of images of mice
        /// </summary>
        public IList<string> MouseImageUrls { get; set; }

        /// <summary>
        /// Property that represents a collection of Urls of images of headphones
        /// </summary>
        public IList<string> HeadphoneImageUrls { get; set; }

        /// <summary>
        /// Property that represents a collection of Urls of images of microphones
        /// </summary>
        public IList<string> MicrophoneImageUrls { get; set; }
    }
}
