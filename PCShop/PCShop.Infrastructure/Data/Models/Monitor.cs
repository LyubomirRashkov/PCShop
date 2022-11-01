using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;

namespace PCShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Monitor model
    /// </summary>
    public class Monitor
    {
        /// <summary>
        /// Monitor unique identifier
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
        /// Monitor price
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
        /// Monitor image Url
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Monitor warranty
        /// </summary>
        public int Warranty { get; set; }

        /// <summary>
        /// Monitors in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Monitor availability
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Date when the monitor is added in the database
        /// </summary>
        public DateTime AddedOn { get; set; }
    }
}
