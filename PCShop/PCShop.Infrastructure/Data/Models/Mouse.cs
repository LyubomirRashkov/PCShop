using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;

namespace PCShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Mouse model
    /// </summary>
    public class Mouse
    {
        /// <summary>
        /// Mouse unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreign key to mouse Brand unique identifier
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Navigation property to mouse Brand
        /// </summary>
        public virtual Brand Brand { get; set; } = null!;

        /// <summary>
        /// Mouse price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Mouse wireless (true / false)
        /// </summary>
        public bool IsWireless { get; set; }

        /// <summary>
        /// Foreign key to mouse Type unique identifier
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Navigation property to mouse Type
        /// </summary>
        public virtual Type Type { get; set; } = null!;

        /// <summary>
        /// Foreign key to mouse Sensitivity unique identifier
        /// </summary>
        public int SensitivityId { get; set; }

        /// <summary>
        /// Navigation property to mouse Sensitivity
        /// </summary>
        public virtual Sensitivity Sensitivity { get; set; } = null!;

        /// <summary>
        /// Foreign key to mouse Color unique identifier
        /// </summary>
        public int? ColorId { get; set; }

        /// <summary>
        /// Navigation property to mouse Color
        /// </summary>
        public virtual Color? Color { get; set; }

        /// <summary>
        /// Mouse image Url
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Mouse warranty
        /// </summary>
        public int Warranty { get; set; }

        /// <summary>
        /// Mice in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Mouse availability
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Date when the mouse is added in the database
        /// </summary>
        public DateTime AddedOn { get; set; }
    }
}
