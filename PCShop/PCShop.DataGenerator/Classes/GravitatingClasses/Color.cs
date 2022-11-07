namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Color model
    /// </summary>
    public class Color
    {
        /// <summary>
        /// Constructor of Color class
        /// </summary>
        public Color()
        {
            this.LaptopColors = new List<string>();
            this.MonitorColors = new List<string>();
            this.KeyboardColors = new List<string>();
            this.MouseColors = new List<string>();
            this.HeadphoneColors = new List<string>();
            this.MicrophoneColors = new List<string>();
        }

        /// <summary>
        /// Property that represents a collection of laptop colors
        /// </summary>
        public IList<string> LaptopColors { get; set; }

        /// <summary>
        /// Property that represents a collection of monitor colors
        /// </summary>
        public IList<string> MonitorColors { get; set; }

        /// <summary>
        /// Property that represents a collection of keyboard colors
        /// </summary>
        public IList<string> KeyboardColors { get; set; }

        /// <summary>
        /// Property that represents a collection of mouse colors
        /// </summary>
        public IList<string> MouseColors { get; set; }

        /// <summary>
        /// Property that represents a collection of headphone colors
        /// </summary>
        public IList<string> HeadphoneColors { get; set; }

        /// <summary>
        /// Property that represents a collection of microphone colors
        /// </summary>
        public IList<string> MicrophoneColors { get; set; }
    }
}
