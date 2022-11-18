using PCShop.Infrastructure.Data.Models.Account;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCShop.Infrastructure.Data.Models
{
    /// <summary>
    /// Client model
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Constructor or Client class
        /// </summary>
        public Client()
        {
            this.Laptops = new HashSet<Laptop>();
            this.Monitors = new HashSet<Monitor>();
            this.Keyboards = new HashSet<Keyboard>();
            this.Mice = new HashSet<Mouse>();
            this.Headphones = new HashSet<Headphone>();
            this.Microphones = new HashSet<Microphone>();
        }

        /// <summary>
        /// Client unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreign key to User unique identifier
        /// </summary>
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        /// <summary>
        /// Navigation property to User
        /// </summary>
        public User User { get; set; } = null!;
        
        /// <summary>
        /// Property that represents the count of purchases the client made
        /// </summary>
        public int CountOfPurchases { get; set; }

        /// <summary>
        /// Inverse property to client's laptops
        /// </summary>
        public virtual ICollection<Laptop> Laptops { get; set; }

        /// <summary>
        /// Inverse property to client's monitors
        /// </summary>
        public virtual ICollection<Monitor> Monitors { get; set; }

        /// <summary>
        /// Inverse property to client's keyboards
        /// </summary>
        public virtual ICollection<Keyboard> Keyboards { get; set; }

        /// <summary>
        /// Inverse property to client's mice
        /// </summary>
        public virtual ICollection<Mouse> Mice { get; set; }

        /// <summary>
        /// Inverse property to user's headphones
        /// </summary>
        public virtual ICollection<Headphone> Headphones { get; set; }

        /// <summary>
        /// Inverse property to client's microphones
        /// </summary>
        public virtual ICollection<Microphone> Microphones { get; set; }
    }
}
