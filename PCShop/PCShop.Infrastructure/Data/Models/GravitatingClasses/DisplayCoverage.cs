using System.ComponentModel.DataAnnotations;
using static PCShop.Infrastructure.Constants.DataConstant.DisplayCoverageConstants;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Display coverage model
    /// </summary>
    public class DisplayCoverage
    {
        /// <summary>
        /// Constructor of DisplayCoverage class
        /// </summary>
        public DisplayCoverage()
        {
            this.DisplayCoverageLaptops = new HashSet<Laptop>();
            this.DisplayCoverageMonitors = new HashSet<Monitor>();
        }

        /// <summary>
        /// Property that represents displayCoverage unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property that represents displayCoverage name
        /// </summary>
        [Required]
        [MaxLength(DisplayCoverageNameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> DisplayCoverageLaptops { get; set; }

        /// <summary>
        /// Property that represents a collection of monitors
        /// </summary>
        public virtual ICollection<Monitor> DisplayCoverageMonitors { get; set; }
    }
}
