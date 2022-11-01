using System.ComponentModel.DataAnnotations;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Product resolution model
    /// </summary>
    public class Resolution
    {
        /// <summary>
        /// Constructor of Resolution class
        /// </summary>
        public Resolution()
        {
            this.ResolutionLaptops = new HashSet<Laptop>();
            this.ResolutionMonitors = new HashSet<Monitor>();
        }

        /// <summary>
        /// Resolution unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Resolution value
        /// </summary>
        [Required]
        public string Value { get; set; } = null!;

        /// <summary>
        /// Collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> ResolutionLaptops { get; set; }

        /// <summary>
        /// Collection of monitors
        /// </summary>
        public virtual ICollection<Monitor> ResolutionMonitors { get; set; }
    }
}
