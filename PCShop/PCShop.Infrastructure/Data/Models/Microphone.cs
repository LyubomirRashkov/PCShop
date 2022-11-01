using PCShop.Infrastructure.Data.Models.GravitatingClasses;

namespace PCShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Microphone model
    /// </summary>
    public class Microphone
    {
        /// <summary>
        /// Microphone unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreign key to microphone Brand unique identifier
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Navigation property to microphone Brand
        /// </summary>
        public virtual Brand Brand { get; set; } = null!;

        /// <summary>
        /// Microphone price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Foreign key to microphone Color unique identifier
        /// </summary>
        public int? ColorId { get; set; }

        /// <summary>
        /// Navigation property to microphone Color
        /// </summary>
        public virtual Color? Color { get; set; }

        /// <summary>
        /// Microphone image Url
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Microphone warranty
        /// </summary>
        public int Warranty { get; set; }

        /// <summary>
        /// Microphones in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Microphone availability
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Date when the microphone is added in the database
        /// </summary>
        public DateTime AddedOn { get; set; }
    }
}
