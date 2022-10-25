namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class VideoCard
    {
        public VideoCard()
        {
            this.LaptopVideoCards = new List<string>();
        }

        public IEnumerable<string> LaptopVideoCards { get; set; }
    }
}
