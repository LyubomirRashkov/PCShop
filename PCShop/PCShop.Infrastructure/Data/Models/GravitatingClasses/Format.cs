using System.ComponentModel.DataAnnotations;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Product format model
    /// </summary>
    public class Format
    {
        /// <summary>
        /// Constructor of Format class
        /// </summary>
        public Format()
        {
            this.FormatKeyboards = new HashSet<Keyboard>();
        }

        /// <summary>
        /// Format unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Format name
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Collection of keyboards
        /// </summary>
        public virtual ICollection<Keyboard> FormatKeyboards { get; set; }
    }
}
