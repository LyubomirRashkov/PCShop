using System.ComponentModel.DataAnnotations;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Product video card model
    /// </summary>
    public class VideoCard
    {
        /// <summary>
        /// Constructor of VideoCard class
        /// </summary>
        public VideoCard()
        {
            this.VideoCardLaptops = new HashSet<Laptop>();
        }

        /// <summary>
        /// VideoCard unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// VideoCard name
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> VideoCardLaptops { get; set; }
    }
}
