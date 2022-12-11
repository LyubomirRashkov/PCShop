using PCShop.Core.Models.Product;
using System.ComponentModel.DataAnnotations;
using static PCShop.Core.Constants.Constant.ProductConstants;
using static PCShop.Core.Constants.Constant.TypeConstants;
using static PCShop.Infrastructure.Constants.DataConstant.TypeConstants;

namespace PCShop.Core.Models.Keyboard
{
    /// <summary>
    /// KeyboardImportViewModel model
    /// </summary>
    public class KeyboardImportViewModel : ProductImportViewModel
    {
        /// <summary>
        /// Property that represents if the keyboard is wireless
        /// </summary>
        [Display(Name = "wireless")]
        public bool? IsWireless { get; set; }

        /// <summary>
        /// Property that represents keyboard type
        /// </summary>
        [Display(Name = "type")]
        [Required]
        [StringLength(TypeNameMaxLength, MinimumLength = TypeNameMinLength)]
        public string Type { get; init; } = null!;

        /// <summary>
        /// Property that represents keyboard format
        /// </summary>
        [Display(Name = "format")]
        public string? Format { get; init; }
    }
}
