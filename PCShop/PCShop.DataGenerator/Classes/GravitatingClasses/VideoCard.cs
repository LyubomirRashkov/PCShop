namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Class holding a collection of laptop video cards
    /// </summary>
    public class VideoCard
    {
        /// <summary>
        /// Constructor of VideoCard class
        /// </summary>
        public VideoCard()
        {
            this.LaptopVideoCards = new List<string>();
        }

        /// <summary>
        /// Collection of laptop video cards
        /// </summary>
        public IList<string> LaptopVideoCards { get; set; }
    }
}
