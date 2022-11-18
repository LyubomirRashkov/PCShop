using PCShop.Infrastructure.Data.Models.Account;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Microphone model
    /// </summary>
    public class Microphone
    {
        /// <summary>
        /// Property that represents microphone unique identifier
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
        /// Property that represents microphone price
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
        /// Property that represents microphone image Url
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Property that represents microphone warranty
        /// </summary>
        public int Warranty { get; set; }

        /// <summary>
        /// Property that represents how many microphones are in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Property that represents microphone availability
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Property that represents the date the microphone was added to the database
        /// </summary>
        public DateTime AddedOn { get; set; }

        /// <summary>
        /// Foreign key to microphone Seller unique identifier
        /// </summary>
        [ForeignKey(nameof(Seller))]
        public int? SellerId { get; set; }

        /// <summary>
        /// Navigation property to microphone Seller
        /// </summary>
        public Client? Seller { get; set; }
    }
}
