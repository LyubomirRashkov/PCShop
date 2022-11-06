using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static PCShop.Infrastructure.Constants.DataConstant.User;

namespace PCShop.Infrastructure.Data.Models.Account
{
    /// <summary>
    /// Class User -> extending IdentityUser functionality
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// User first name
        /// </summary>
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// User last name
        /// </summary>
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;
    }
}
