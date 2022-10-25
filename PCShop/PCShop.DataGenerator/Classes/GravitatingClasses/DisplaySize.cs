namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    public class DisplaySize
    {
        public DisplaySize()
        {
            this.LaptopDisplaySizes = new List<double>();
            this.MonitorDisplaySizes = new List<double>();
        }

        public IList<double> LaptopDisplaySizes { get; set; }

        public IList<double> MonitorDisplaySizes { get; set; }
    }
}
