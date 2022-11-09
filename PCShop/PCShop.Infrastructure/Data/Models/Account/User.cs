using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static PCShop.Infrastructure.Constants.DataConstant.UserConstants;

namespace PCShop.Infrastructure.Data.Models.Account
{
    /// <summary>
    /// User model -> extending IdentityUser
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Constructor or User class
        /// </summary>
        public User()
        {
            this.Laptops = new HashSet<Laptop>();
            this.Monitors = new HashSet<Monitor>();
            this.Keyboards = new HashSet<Keyboard>();
            this.Mice = new HashSet<Mouse>();
            this.Headphones = new HashSet<Headphone>();
            this.Microphones = new HashSet<Microphone>();
        }

        /// <summary>
        /// Property that represents user's first name
        /// </summary>
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Property that represents user's last name
        /// </summary>
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Property that represents the count of purchases the user made
        /// </summary>
        public int CountOfPurchases { get; set; }

        /// <summary>
        /// Inverse property to user's laptops
        /// </summary>
        public virtual ICollection<Laptop> Laptops { get; set; }

        /// <summary>
        /// Inverse property to user's monitors
        /// </summary>
        public virtual ICollection<Monitor> Monitors { get; set; }

        /// <summary>
        /// Inverse property to user's keyboards
        /// </summary>
        public virtual ICollection<Keyboard> Keyboards { get; set; }

        /// <summary>
        /// Inverse property to user's mice
        /// </summary>
        public virtual ICollection<Mouse> Mice { get; set; }

        /// <summary>
        /// Inverse property to user's headphones
        /// </summary>
        public virtual ICollection<Headphone> Headphones { get; set; }

        /// <summary>
        /// Inverse property to user's microphones
        /// </summary>
        public virtual ICollection<Microphone> Microphones { get; set; }
    }
}
