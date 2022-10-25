namespace PCShop.DataGenerator.Classes.GravitatingClasses
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

        public IList<string> LaptopColors { get; set; }

        public IList<string> MonitorColors { get; set; }

        public IList<string> KeyboardColors { get; set; }

        public IList<string> MouseColors { get; set; }

        public IList<string> HeadphoneColors { get; set; }

        public IList<string> MicrophoneColors { get; set; }
    }
}
