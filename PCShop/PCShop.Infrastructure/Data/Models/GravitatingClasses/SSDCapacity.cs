namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// SSD capacity model
    /// </summary>
    public class SSDCapacity
    {
        /// <summary>
        /// Constructor of SSDCapacity class
        /// </summary>
        public SSDCapacity()
        {
            this.SSDCapacityLaptops = new HashSet<Laptop>();
        }

        /// <summary>
        /// Property that represents SSDCapacity unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property that represents SSDCapacity value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Property that represents a collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> SSDCapacityLaptops { get; set; }
    }
}
