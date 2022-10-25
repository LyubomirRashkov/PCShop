namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class SSDCapacity
    {
        public SSDCapacity()
        {
            this.LaptopSSDCapacities = new List<int>();
        }

        public IEnumerable<int> LaptopSSDCapacities { get; set; }
    }
}
