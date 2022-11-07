using System.ComponentModel.DataAnnotations;
using static PCShop.Core.Constants.Constant.User;
using static PCShop.Infrastructure.Constants.DataConstant.User;

namespace PCShop.Core.Models.User
{
    /// <summary>
    /// ViewModel class for sign up
    /// </summary>
    public class SignUpViewModel
    {
        /// <summary>
        /// Property that represents user's first name
        /// </summary>
        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [Display(Name = "first name")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Property that represents user's last name
        /// </summary>
        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [Display(Name = "last name")]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Property that represents user's username
        /// </summary>
        [Required]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
        [Display(Name = "username")]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// Property that represents user's email
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        [Display(Name = "email")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Property that represents user's password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [Display(Name = "password")]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Property for password confirmation
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name = "confirm password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
