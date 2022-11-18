using PCShop.Infrastructure.Data.Models.Account;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using System.ComponentModel.DataAnnotations.Schema;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;

namespace PCShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Monitor model
    /// </summary>
    public class Monitor
    {
        /// <summary>
        /// Property that represents monitor unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreign key to monitor Brand unique identifier
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Navigation property to monitor Brand
        /// </summary>
        public virtual Brand Brand { get; set; } = null!;

        /// <summary>
        /// Property that represents monitor price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Foreign key to monitor DisplaySize unique identifier
        /// </summary>
        public int DisplaySizeId { get; set; }

        /// <summary>
        /// Navigation property to monitor DisplaySize
        /// </summary>
        public virtual DisplaySize DisplaySize { get; set; } = null!;

        /// <summary>
        /// Foreign key to monitor Type unique identifier
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Navigation property to monitor Type
        /// </summary>
        public virtual Type Type { get; set; } = null!;

        /// <summary>
        /// Foreign key to monitor DisplayCoverage unique identifier
        /// </summary>
        public int? DisplayCoverageId { get; set; }

        /// <summary>
        /// Navigation property to monitor DisplayCoverage
        /// </summary>
        public virtual DisplayCoverage? DisplayCoverage { get; set; }

        /// <summary>
        /// Foreign key to monitor DisplayTechnology unique identifier
        /// </summary>
        public int? DisplayTechnologyId { get; set; }

        /// <summary>
        /// Navigation property to monitor DisplayTechnology
        /// </summary>
        public virtual DisplayTechnology? DisplayTechnology { get; set; }

        /// <summary>
        /// Foreign key to monitor Resolution unique identifier
        /// </summary>
        public int ResolutionId { get; set; }

        /// <summary>
        /// Navigation property to monitor Resolution
        /// </summary>
        public virtual Resolution Resolution { get; set; } = null!;

        /// <summary>
        /// Foreign key to monitor RefreshRate unique identifier
        /// </summary>
        public int RefreshRateId { get; set; }

        /// <summary>
        /// Navigation property to monitor RefreshRate
        /// </summary>
        public virtual RefreshRate RefreshRate { get; set; } = null!;

        /// <summary>
        /// Foreign key to monitor Color unique identifier
        /// </summary>
        public int? ColorId { get; set; }

        /// <summary>
        /// Navigation property to monitor Color
        /// </summary>
        public virtual Color? Color { get; set; }

        /// <summary>
        /// Property that represents monitor image Url
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Property that represents monitor warranty
        /// </summary>
        public int Warranty { get; set; }

        /// <summary>
        /// Property that represents how many monitors are in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Property that represents monitor availability
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Property that represents the date the monitor was added to the database
        /// </summary>
        public DateTime AddedOn { get; set; }

        /// <summary>
        /// Foreign key to monitor Seller unique identifier
        /// </summary>
        [ForeignKey(nameof(Seller))]
        public int? SellerId { get; set; }

        /// <summary>
        /// Navigation property to monitor Seller
        /// </summary>
        public Client? Seller { get; set; }
    }
}
