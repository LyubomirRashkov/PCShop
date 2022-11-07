using System.ComponentModel.DataAnnotations;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Format model
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
        /// Property that represents format unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property that represents format name
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of keyboards
        /// </summary>
        public virtual ICollection<Keyboard> FormatKeyboards { get; set; }
    }
}
