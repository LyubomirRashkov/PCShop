namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    public class Warranty
    {
        public Warranty()
        {
            this.Warranties = new List<int>();
        }

        public IList<int> Warranties { get; set; }
    }
}
