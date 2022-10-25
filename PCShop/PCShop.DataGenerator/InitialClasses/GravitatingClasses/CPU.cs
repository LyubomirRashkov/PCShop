namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class CPU
    {
        public CPU()
        {
            this.LaptopCPUs = new List<string>();
        }

        public IEnumerable<string> LaptopCPUs { get; set; }
    }
}
