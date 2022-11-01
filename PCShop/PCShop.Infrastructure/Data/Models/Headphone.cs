using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;

namespace PCShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Headphone model
    /// </summary>
    public class Headphone
    {
        /// <summary>
        /// Headphone unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreign key to headphone Brand unique identifier
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Navigation property to headphone Brand
        /// </summary>
        public virtual Brand Brand { get; set; } = null!;

        /// <summary>
        /// Headphone price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Foreign key to headphone Type unique identifier
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Navigation property to headphone Type
        /// </summary>
        public virtual Type Type { get; set; } = null!;

        /// <summary>
        /// Headphone wireless (true / false)
        /// </summary>
        public bool IsWireless { get; set; }

        /// <summary>
        /// Headphone microphone (true / false)
        /// </summary>
        public bool HasMicrophone { get; set; }

        /// <summary>
        /// Foreign key to headphone Color unique identifier
        /// </summary>
        public int? ColorId { get; set; }

        /// <summary>
        /// Navigation property to headphone Color
        /// </summary>
        public virtual Color? Color { get; set; }

        /// <summary>
        /// Headphone image Url
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Headphone warranty
        /// </summary>
        public int Warranty { get; set; }

        /// <summary>
        /// Headphones in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Headphone availability
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Date when the mouse is added in the database
        /// </summary>
        public DateTime AddedOn { get; set; }
    }
}
