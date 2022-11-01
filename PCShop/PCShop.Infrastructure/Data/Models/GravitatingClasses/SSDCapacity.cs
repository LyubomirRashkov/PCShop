namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Product SSD capacity model
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
        /// SSDCapacity unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// SSDCapacity value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> SSDCapacityLaptops { get; set; }
    }
}
