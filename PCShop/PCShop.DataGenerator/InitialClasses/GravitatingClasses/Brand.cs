namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class Brand
    {
        public Brand()
        {
            this.LaptopBrands = new List<string>();
            this.MonitorBrands = new List<string>();
            this.KeyboardBrands = new List<string>();
            this.MouseBrands = new List<string>();
            this.HeadphoneBrands = new List<string>();
            this.MicrophoneBrands = new List<string>();
        }

        public IEnumerable<string> LaptopBrands { get; set; }

        public IEnumerable<string> MonitorBrands { get; set; }

        public IEnumerable<string> KeyboardBrands { get; set; }

        public IEnumerable<string> MouseBrands { get; set; }

        public IEnumerable<string> HeadphoneBrands { get; set; }

        public IEnumerable<string> MicrophoneBrands { get; set; }
    }
}
