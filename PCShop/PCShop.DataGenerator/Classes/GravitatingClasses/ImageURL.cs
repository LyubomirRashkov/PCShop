namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    public class ImageURL
    {
        public ImageURL()
        {
            this.LaptopImageURLs = new List<string>();
            this.MonitorImageURLs = new List<string>();
            this.KeyboardImageURLs = new List<string>();
            this.MouseImageURLs = new List<string>();
            this.HeadphoneImageURLs = new List<string>();
            this.MicrophoneImageURLs = new List<string>();
        }

        public IList<string> LaptopImageURLs { get; set; }

        public IList<string> MonitorImageURLs { get; set; }

        public IList<string> KeyboardImageURLs { get; set; }

        public IList<string> MouseImageURLs { get; set; }

        public IList<string> HeadphoneImageURLs { get; set; }

        public IList<string> MicrophoneImageURLs { get; set; }
    }
}
