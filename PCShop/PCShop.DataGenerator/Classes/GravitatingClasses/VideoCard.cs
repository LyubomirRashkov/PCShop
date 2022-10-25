namespace PCShop.DataGenerator.Classes.GravitatingClasses
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
