namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class Resolution
    {
        public Resolution()
        {
            this.LaptopResolutions = new List<string>();
            this.MonitorResolutions = new List<string>();
        }

        public IEnumerable<string> LaptopResolutions { get; set; }

        public IEnumerable<string> MonitorResolutions { get; set; }
    }
}
