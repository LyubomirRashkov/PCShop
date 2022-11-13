using System.ComponentModel.DataAnnotations;
using static PCShop.Infrastructure.Constants.DataConstant.DisplayTechnologyConstants;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Display technology model
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
        /// Property that represents displayTechnology unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property that represents displayTechnology name
        /// </summary>
        [Required]
        [MaxLength(DisplayTechnologyNameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> DisplayTechnologyLaptops { get; set; }

        /// <summary>
        /// Property that represents a collection of monitors
        /// </summary>
        public virtual ICollection<Monitor> DisplayTechnologyMonitors { get; set; }
    }
}
