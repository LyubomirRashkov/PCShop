using System.ComponentModel.DataAnnotations;
using static PCShop.Infrastructure.Constants.DataConstant.VideoCardConstants;

namespace PCShop.Infrastructure.Data.Models.GravitatingClasses
{
    /// <summary>
    /// Video card model
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
        /// Property that represents videoCard unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property that represents videoCard name
        /// </summary>
        [Required]
        [MaxLength(VideoCardNameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of laptops
        /// </summary>
        public virtual ICollection<Laptop> VideoCardLaptops { get; set; }
    }
}
