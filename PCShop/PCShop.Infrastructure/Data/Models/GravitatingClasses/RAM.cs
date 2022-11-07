namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// RAM model
    /// </summary>
    public class RAM
    {
        /// <summary>
        /// Constructor of RAM class
        /// </summary>
        public RAM()
        {
            this.RAMLaptops = new HashSet<Laptop>();
        }

        /// <summary>
        /// Property that represents RAM unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property that represents RAM value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Property that represents a collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> RAMLaptops { get; set; }
    }
}
