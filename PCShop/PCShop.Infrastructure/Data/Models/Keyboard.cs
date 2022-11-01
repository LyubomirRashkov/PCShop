using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;

namespace PCShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Keyboard model
    /// </summary>
    public class Keyboard
    {
        /// <summary>
        /// Keyboard unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreign key to keyboard Brand unique identifier
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Navigation property to keyboard Brand
        /// </summary>
        public virtual Brand Brand { get; set; } = null!;

        /// <summary>
        /// Keyboard price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Keyboard wireless (true / false)
        /// </summary>
        public bool IsWireless { get; set; }

        /// <summary>
        /// Foreign key to keyboard Format unique identifier
        /// </summary>
        public int? FormatId { get; set; }

        /// <summary>
        /// Navigation property to keyboard Format
        /// </summary>
        public virtual Format? Format { get; set; }

        /// <summary>
        /// Foreign key to keyboard Type unique identifier
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Navigation property to keyboard Type
        /// </summary>
        public virtual Type Type { get; set; } = null!;

        /// <summary>
        /// Foreign key to keyboard Color unique identifier
        /// </summary>
        public int? ColorId { get; set; }

        /// <summary>
        /// Navigation property to keyboard Color
        /// </summary>
        public virtual Color? Color { get; set; }

        /// <summary>
        /// Keyboard image Url
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Keyboard warranty
        /// </summary>
        public int Warranty { get; set; }

        /// <summary>
        /// Keyboards in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Keyboard availability
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Date when the keyboard is added in the database
        /// </summary>
        public DateTime AddedOn { get; set; }
    }
}
