using System.ComponentModel.DataAnnotations;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Color model
    /// </summary>
    public class Color
    {
        /// <summary>
        /// Constructor of Color class
        /// </summary>
        public Color()
        {
            this.ColorLaptops = new HashSet<Laptop>();
            this.ColorMonitors = new HashSet<Monitor>();
            this.ColorKeyboards = new HashSet<Keyboard>();
            this.ColorMice = new HashSet<Mouse>();
            this.ColorHeadphones = new HashSet<Headphone>();
            this.ColorMicrophones = new HashSet<Microphone>();
        }

        /// <summary>
        /// Property that represents color unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property that represents color name
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> ColorLaptops { get; set; }

        /// <summary>
        /// Property that represents a collection of monitors
        /// </summary>
        public virtual ICollection<Monitor> ColorMonitors { get; set; }

        /// <summary>
        /// Property that represents a collection of keyboards
        /// </summary>
        public virtual ICollection<Keyboard> ColorKeyboards { get; set; }

        /// <summary>
        /// Property that represents a collection of mice
        /// </summary>
        public virtual ICollection<Mouse> ColorMice { get; set; }

        /// <summary>
        /// Property that represents a collection of headphones
        /// </summary>
        public virtual ICollection<Headphone> ColorHeadphones { get; set; }

        /// <summary>
        /// Property that represents a collection of microphones
        /// </summary>
        public virtual ICollection<Microphone> ColorMicrophones { get; set; }
    }
}
