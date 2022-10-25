namespace PCShop.DataGenerator.Classes.GravitatingClasses
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

        public IList<string> LaptopBrands { get; set; }

        public IList<string> MonitorBrands { get; set; }

        public IList<string> KeyboardBrands { get; set; }

        public IList<string> MouseBrands { get; set; }

        public IList<string> HeadphoneBrands { get; set; }

        public IList<string> MicrophoneBrands { get; set; }
    }
}
