namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class Warranty
    {
        public Warranty()
        {
            this.Warranties = new List<int>();
        }

        public IEnumerable<int> Warranties { get; set; }
    }
}
