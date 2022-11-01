using System.ComponentModel.DataAnnotations;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Product type model
    /// </summary>
    public class Type
    {
        /// <summary>
        /// Constructor of Type class
        /// </summary>
        public Type()
        {
            this.TypeLaptops = new HashSet<Laptop>();
            this.TypeMonitors = new HashSet<Monitor>();
            this.TypeKeyboards = new HashSet<Keyboard>();
            this.TypeMice = new HashSet<Mouse>();
            this.TypeHeadphones = new HashSet<Headphone>();
        }

        /// <summary>
        /// Type unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type name
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> TypeLaptops { get; set; }

        /// <summary>
        /// Collection of monitors
        /// </summary>
        public virtual ICollection<Monitor> TypeMonitors { get; set; }

        /// <summary>
        /// Collection of keyboards
        /// </summary>
        public virtual ICollection<Keyboard> TypeKeyboards { get; set; }

        /// <summary>
        /// Collection of mice
        /// </summary>
        public virtual ICollection<Mouse> TypeMice { get; set; }

        /// <summary>
        /// Collection of headphones
        /// </summary>
        public virtual ICollection<Headphone> TypeHeadphones { get; set; }
    }
}
