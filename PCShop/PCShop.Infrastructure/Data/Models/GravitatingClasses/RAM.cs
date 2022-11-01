namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Product RAM model
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
        /// RAM unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// RAM value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> RAMLaptops { get; set; }
    }
}
