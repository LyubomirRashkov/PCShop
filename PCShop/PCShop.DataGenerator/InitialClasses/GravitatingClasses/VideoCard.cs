namespace PCShop.DataGenerator.InitialClasses.GravitatingClasses
{
    public class VideoCard
    {
        public VideoCard()
        {
            this.LaptopVideoCards = new List<string>();
        }

        public IList<string> LaptopVideoCards { get; set; }
    }
}
