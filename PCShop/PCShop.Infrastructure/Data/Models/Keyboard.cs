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
        /// Property that represents keyboard unique identifier
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
        /// Property that represents keyboard price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Property that represents if the keyboard is wireless
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
        /// Property that represents keyboard image Url
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Property that represents keyboard warranty
        /// </summary>
        public int Warranty { get; set; }

        /// <summary>
        /// Property that represents how many keyboards are in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Property that represents keyboard availability
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Property that represents the date the keyboard was added to the database
        /// </summary>
        public DateTime AddedOn { get; set; }
    }
}
