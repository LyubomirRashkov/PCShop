namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class CPU
    {
        public CPU()
        {
            this.LaptopCPUs = new List<string>();
        }

        public IList<string> LaptopCPUs { get; set; }
    }
}
