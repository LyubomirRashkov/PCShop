namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class DisplayTechnology
    {
        public DisplayTechnology()
        {
            this.DisplayTechnologies = new List<string>();
        }

        public IEnumerable<string> DisplayTechnologies { get; set; }
    }
}
