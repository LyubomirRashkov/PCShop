namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class DisplaySize
    {
        public DisplaySize()
        {
            this.LaptopDisplaySizes = new List<int>();
            this.MonitorDisplaySizes = new List<int>();
        }

        public IEnumerable<int> LaptopDisplaySizes { get; set; }

        public IEnumerable<int> MonitorDisplaySizes { get; set; }
    }
}
