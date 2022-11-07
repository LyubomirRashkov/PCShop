using System.ComponentModel.DataAnnotations;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Type model
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
        /// Property that represents type unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property that represents type name
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> TypeLaptops { get; set; }

        /// <summary>
        /// Property that represents a collection of monitors
        /// </summary>
        public virtual ICollection<Monitor> TypeMonitors { get; set; }

        /// <summary>
        /// Property that represents a collection of keyboards
        /// </summary>
        public virtual ICollection<Keyboard> TypeKeyboards { get; set; }

        /// <summary>
        /// Property that represents a collection of mice
        /// </summary>
        public virtual ICollection<Mouse> TypeMice { get; set; }

        /// <summary>
        /// Property that represents a collection of headphones
        /// </summary>
        public virtual ICollection<Headphone> TypeHeadphones { get; set; }
    }
}
