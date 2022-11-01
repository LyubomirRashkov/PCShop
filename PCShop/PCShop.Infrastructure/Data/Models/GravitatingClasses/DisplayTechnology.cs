using System.ComponentModel.DataAnnotations;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Product display technology model
    /// </summary>
    public class DisplayTechnology
    {
        /// <summary>
        /// Constructor of DisplayTechnology class
        /// </summary>
        public DisplayTechnology()
        {
            this.DisplayTechnologyLaptops = new HashSet<Laptop>();
            this.DisplayTechnologyMonitors = new HashSet<Monitor>();
        }

        /// <summary>
        /// DisplayTechnology unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DisplayTechnology name
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> DisplayTechnologyLaptops { get; set; }

        /// <summary>
        /// Collection of monitors
        /// </summary>
        public virtual ICollection<Monitor> DisplayTechnologyMonitors { get; set; }
    }
}
