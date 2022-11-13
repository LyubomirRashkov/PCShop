using System.ComponentModel.DataAnnotations;
using static PCShop.Infrastructure.Constants.DataConstant.SensitivityConstants;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Sensitivity model
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
        /// Property that represents sensitivity unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property that represents sensitivity range
        /// </summary>
        [Required]
        [MaxLength(SensitivityRangeMaxLength)]
        public string Range { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of mice
        /// </summary>
        public virtual ICollection<Mouse> SensitivityMice { get; set; }
    }
}
