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
        /// Property that represents user's first name
        /// </summary>
        [MaxLength(FirstNameMaxLength)]
        public string? FirstName { get; set; }

        /// <summary>
        /// Property that represents user's last name
        /// </summary>
        [MaxLength(LastNameMaxLength)]
        public string? LastName { get; set; }
    }
}
