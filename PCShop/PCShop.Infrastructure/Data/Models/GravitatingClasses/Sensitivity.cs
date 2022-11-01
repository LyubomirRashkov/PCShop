using System.ComponentModel.DataAnnotations;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Product sensitivity model
    /// </summary>
    public class Sensitivity
    {
        /// <summary>
        /// Constructor of Sensitivity class
        /// </summary>
        public Sensitivity()
        {
            this.SensitivityMice = new HashSet<Mouse>();
        }

        /// <summary>
        /// Sensitivity unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Sensitivity range
        /// </summary>
        [Required]
        public string Range { get; set; } = null!;

        /// <summary>
        /// Collection of mice
        /// </summary>
        public virtual ICollection<Mouse> SensitivityMice { get; set; }
    }
}
