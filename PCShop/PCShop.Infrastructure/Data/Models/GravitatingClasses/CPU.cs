using System.ComponentModel.DataAnnotations;
using static PCShop.Infrastructure.Constants.DataConstant.CPUConstants;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// CPU model
    /// </summary>
    public class CPU
    {
        /// <summary>
        /// Constructor of CPU class
        /// </summary>
        public CPU()
        {
            this.CPULaptops = new HashSet<Laptop>();
        }

        /// <summary>
        /// Property that represents CPU unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property that represents CPU name
        /// </summary>
        [Required]
        [MaxLength(CPUNameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> CPULaptops { get; set; }
    }
}
