namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    public class Resolution
    {
        public Resolution()
        {
            this.LaptopResolutions = new List<string>();
            this.MonitorResolutions = new List<string>();
        }

        public IList<string> LaptopResolutions { get; set; }

        public IList<string> MonitorResolutions { get; set; }
    }
}
