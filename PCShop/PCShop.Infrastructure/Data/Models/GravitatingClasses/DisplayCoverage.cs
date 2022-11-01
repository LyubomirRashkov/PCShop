using System.ComponentModel.DataAnnotations;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Product display coverage model
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
        /// DisplayCoverage unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DisplayCoverage name
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> DisplayCoverageLaptops { get; set; }

        /// <summary>
        /// Collection of monitors
        /// </summary>
        public virtual ICollection<Monitor> DisplayCoverageMonitors { get; set; }
    }
}
