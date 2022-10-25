namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class RAM
    {
        public RAM()
        {
            this.LaptopRAMs = new List<int>();
        }

        public IEnumerable<int> LaptopRAMs { get; set; }
    }
}
