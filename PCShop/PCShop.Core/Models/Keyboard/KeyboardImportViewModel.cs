using System.ComponentModel.DataAnnotations;
using static PCShop.Core.Constants.Constant.BrandConstants;
using static PCShop.Core.Constants.Constant.ColorConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;
using static PCShop.Core.Constants.Constant.TypeConstants;
using static PCShop.Infrastructure.Constants.DataConstant.BrandConstants;
using static PCShop.Infrastructure.Constants.DataConstant.ColorConstants;
using static PCShop.Infrastructure.Constants.DataConstant.TypeConstants;

namespace PCShop.Core.Models.Keyboard
{
	/// <summary>
	/// KeyboardImportViewModel model
	/// </summary>
	public class KeyboardImportViewModel : IProductModel
    {
        /// <summary>
        /// Property that represents keyboard brand
        /// </summary>
        [Display(Name = "brand")]
        [Required]
        [StringLength(BrandNameMaxLength, MinimumLength = BrandNameMinLength)]
        public string Brand { get; init; } = null!;

        /// <summary>
        /// Property that represents if the keyboard is wireless
        /// </summary>
        [Display(Name = "wireless")]
        [Required(ErrorMessage = ErrorMessageForUnselectedOption)]
        public bool IsWireless { get; set; }

        /// <summary>
        /// Property that represents keyboard type
        /// </summary>
        [Display(Name = "type")]
        [Required]
        [StringLength(TypeNameMaxLength, MinimumLength = TypeNameMinLength)]
        public string Type { get; init; } = null!;

        /// <summary>
        /// Property that represents keyboards count
        /// </summary>
        [Display(Name = "quantity")]
        [Required]
        [Range(QuantityMinValue, QuantityMaxValue, ErrorMessage = IntegerErrorMessage)]
        public int Quantity { get; init; }

        /// <summary>
        /// Property that represents keyboard price
        /// </summary>
        [Display(Name = "price")]
        [Required]
        public decimal Price { get; init; }

        /// <summary>
        /// Property that represents keyboard warranty
        /// </summary>
        [Display(Name = "warranty")]
        [Range(WarrantyMinValue, WarrantyMaxValue, ErrorMessage = IntegerErrorMessage)]
        public int Warranty { get; init; }

        /// <summary>
        /// Property that represents keyboard format
        /// </summary>
        [Display(Name = "format")]
        public string? Format { get; init; }

        /// <summary>
        /// Property that represents keyboard color
        /// </summary>
        [Display(Name = "color")]
        [StringLength(ColorNameMaxLength, MinimumLength = ColorNameMinLength)]
        public string? Color { get; init; }

        /// <summary>
        /// Property that represents keyboard image url
        /// </summary>
        [Display(Name = "image url")]
        [Url]
        public string? ImageUrl { get; init; }
    }
}
