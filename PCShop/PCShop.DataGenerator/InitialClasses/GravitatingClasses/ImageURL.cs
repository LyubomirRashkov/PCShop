namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
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

        public IEnumerable<string> LaptopImageURLs { get; set; }
        public IEnumerable<string> MonitorImageURLs { get; set; }
        public IEnumerable<string> KeyboardImageURLs { get; set; }
        public IEnumerable<string> MouseImageURLs { get; set; }
        public IEnumerable<string> HeadphoneImageURLs { get; set; }
        public IEnumerable<string> MicrophoneImageURLs { get; set; }
    }
}
