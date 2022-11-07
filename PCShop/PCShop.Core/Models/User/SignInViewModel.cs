using System.ComponentModel.DataAnnotations;

namespace PCShop.Core.Models.User
{
    /// <summary>
    /// ViewModel class for sign in
    /// </summary>
    public class SignInViewModel
    {
        /// <summary>
        /// Property that represents user's username
        /// </summary>
        [Required]
        [Display(Name = "username")]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// Property that represents user's password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Property that represents user's required url
        /// </summary>
        [UIHint("hidden")]
        public string? ReturnUrl { get; set; }
    }
}
