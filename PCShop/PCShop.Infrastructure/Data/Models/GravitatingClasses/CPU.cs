using System.ComponentModel.DataAnnotations;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Product CPU model
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
        /// CPU unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// CPU name
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> CPULaptops { get; set; }
    }
}
