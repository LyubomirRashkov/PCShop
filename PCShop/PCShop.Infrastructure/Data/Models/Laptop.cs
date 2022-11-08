using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;

namespace PCShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Laptop model
    /// </summary>
    public class Laptop
    {
        /// <summary>
        /// Property that represents laptop unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreign key to laptop Brand unique identifier
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Navigation property to laptop Brand
        /// </summary>
        public virtual Brand Brand { get; set; } = null!;

        /// <summary>
        /// Foreign key to laptop CPU unique identifier
        /// </summary>
        public int CPUId { get; set; }

        /// <summary>
        /// Navigation property to laptop CPU
        /// </summary>
        public virtual CPU CPU { get; set; } = null!;

        /// <summary>
        /// Foreign key to laptop RAM unique identifier
        /// </summary>
        public int RAMId { get; set; }

        /// <summary>
        /// Navigation property to laptop RAM
        /// </summary>
        public virtual RAM RAM { get; set; } = null!;

        /// <summary>
        /// Foreign key to laptop SSDCapacity unique identifier
        /// </summary>
        public int SSDCapacityId { get; set; }

        /// <summary>
        /// Navigation property to laptop SSDCapacity
        /// </summary>
        public virtual SSDCapacity SSDCapacity { get; set; } = null!;

        /// <summary>
        /// Foreign key to laptop VideoCard unique identifier
        /// </summary>
        public int VideoCardId { get; set; }

        /// <summary>
        /// Navigation property to laptop VideoCard
        /// </summary>
        public virtual VideoCard VideoCard { get; set; } = null!;

        /// <summary>
        /// Property that represents laptop price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Foreign key to laptop Type unique identifier
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Navigation property to laptop Type
        /// </summary>
        public virtual Type Type { get; set; } = null!;

        /// <summary>
        /// Foreign key to laptop DisplaySize unique identifier
        /// </summary>
        public int DisplaySizeId { get; set; }

        /// <summary>
        /// Navigation property to laptop DisplaySize
        /// </summary>
        public virtual DisplaySize DisplaySize { get; set; } = null!;

        /// <summary>
        /// Foreign key to laptop DisplayCoverage unique identifier
        /// </summary>
        public int? DisplayCoverageId { get; set; }

        /// <summary>
        /// Navigation property to laptop DisplayCoverage
        /// </summary>
        public virtual DisplayCoverage? DisplayCoverage { get; set; }

        /// <summary>
        /// Foreign key to laptop DisplayTechnology unique identifier
        /// </summary>
        public int? DisplayTechnologyId { get; set; }

        /// <summary>
        /// Navigation property to laptop DisplayTechnology
        /// </summary>
        public virtual DisplayTechnology? DisplayTechnology { get; set; }

        /// <summary>
        /// Foreign key to laptop Resolution unique identifier
        /// </summary>
        public int? ResolutionId { get; set; }

        /// <summary>
        /// Navigation property to laptop Resolution
        /// </summary>
        public virtual Resolution? Resolution { get; set; }

        /// <summary>
        /// Foreign key to laptop Color unique identifier
        /// </summary>
        public int? ColorId { get; set; }

        /// <summary>
        /// Navigation property to laptop Color
        /// </summary>
        public virtual Color? Color { get; set; }

        /// <summary>
        /// Property that represents laptop image Url
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Property that represents laptop warranty
        /// </summary>
        public int Warranty { get; set; }

        /// <summary>
        /// Property that represents how many laptops are in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Laptop availability
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Property that represents the date the laptop was added to the database
        /// </summary>
        public DateTime AddedOn { get; set; }
    }
}
