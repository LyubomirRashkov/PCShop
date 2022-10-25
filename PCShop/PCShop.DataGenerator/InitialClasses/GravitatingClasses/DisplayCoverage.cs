namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class DisplayCoverage
    {
        public DisplayCoverage()
        {
            this.DisplayCoverages = new List<string>();
        }

        public IEnumerable<string> DisplayCoverages { get; set; }
    }
}
