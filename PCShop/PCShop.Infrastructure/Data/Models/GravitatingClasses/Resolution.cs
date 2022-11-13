using System.ComponentModel.DataAnnotations;
using static PCShop.Infrastructure.Constants.DataConstant.ResolutionConstants;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Resolution model
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
        /// Property that represents resolution unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property that represents resolution value
        /// </summary>
        [Required]
        [MaxLength(ResolutionValueMaxLength)]
        public string Value { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> ResolutionLaptops { get; set; }

        /// <summary>
        /// Property that represents a collection of monitors
        /// </summary>
        public virtual ICollection<Monitor> ResolutionMonitors { get; set; }
    }
}
