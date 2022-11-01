using System.ComponentModel.DataAnnotations;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Product brand model
    /// </summary>
    public class Brand
    {
        /// <summary>
        /// Constructor of Brand class
        /// </summary>
        public Brand()
        {
            this.BrandLaptops = new HashSet<Laptop>();
            this.BrandMonitors = new HashSet<Monitor>();
            this.BrandKeyboards = new HashSet<Keyboard>();
            this.BrandMice = new HashSet<Mouse>();
            this.BrandHeadphones = new HashSet<Headphone>();
            this.BrandMicrophones = new HashSet<Microphone>();
        }

        /// <summary>
        /// Brand unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Brand name
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> BrandLaptops { get; set; }

        /// <summary>
        /// Collection of monitors
        /// </summary>
        public virtual ICollection<Monitor> BrandMonitors { get; set; }

        /// <summary>
        /// Collection of keyboards
        /// </summary>
        public virtual ICollection<Keyboard> BrandKeyboards { get; set; }

        /// <summary>
        /// Collection of mice
        /// </summary>
        public virtual ICollection<Mouse> BrandMice { get; set; }

        /// <summary>
        /// Collection of headphones
        /// </summary>
        public virtual ICollection<Headphone> BrandHeadphones { get; set; }

        /// <summary>
        /// Collection of microphones
        /// </summary>
        public virtual ICollection<Microphone> BrandMicrophones { get; set; }
    }
}
