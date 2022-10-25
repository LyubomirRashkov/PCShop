namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class Color
    {
        public Color()
        {
            this.LaptopColors = new List<string>();
            this.MonitorColors = new List<string>();
            this.KeyboardColors = new List<string>();
            this.MouseColors = new List<string>();
            this.HeadphoneColors = new List<string>();
            this.MicrophoneColors = new List<string>();
        }

        public IEnumerable<string> LaptopColors { get; set; }

        public IEnumerable<string> MonitorColors { get; set; }

        public IEnumerable<string> KeyboardColors { get; set; }

        public IEnumerable<string> MouseColors { get; set; }

        public IEnumerable<string> HeadphoneColors { get; set; }

        public IEnumerable<string> MicrophoneColors { get; set; }
    }
}
