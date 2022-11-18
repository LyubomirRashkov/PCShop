using PCShop.Infrastructure.Data.Models.Account;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using System.ComponentModel.DataAnnotations.Schema;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;

namespace PCShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Headphone model
    /// </summary>
    public class Headphone
    {
        /// <summary>
        /// Property that represents headphone unique identifier
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
        /// Property that represents headphone price
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
        /// Property that represents if the headphone is wireless
        /// </summary>
        public bool IsWireless { get; set; }

        /// <summary>
        /// Property that represents if the headphone has a microphone
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
        /// Property that represents headphone image Url
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Property that represents headphone warranty
        /// </summary>
        public int Warranty { get; set; }

        /// <summary>
        /// Property that represents how namy headphones are in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Property that represents headphone availability
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Property that represents the date the headphone was added to the database
        /// </summary>
        public DateTime AddedOn { get; set; }

        /// <summary>
        /// Foreign key to headphone Seller unique identifier
        /// </summary>
        [ForeignKey(nameof(Seller))]
        public int? SellerId { get; set; }

        /// <summary>
        /// Navigation property to headphone Seller
        /// </summary>
        public Client? Seller { get; set; }
    }
}
