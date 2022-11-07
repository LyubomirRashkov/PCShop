namespace PCShop.DataGenerator.Classes.GravitatingClasses
{
    /// <summary>
    /// Video card model
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
        /// Property that represents a collection of laptop video cards
        /// </summary>
        public IList<string> LaptopVideoCards { get; set; }
    }
}
