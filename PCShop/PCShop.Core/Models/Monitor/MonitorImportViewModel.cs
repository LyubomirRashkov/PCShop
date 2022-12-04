using System.ComponentModel.DataAnnotations;
using static PCShop.Core.Constants.Constant.BrandConstants;
using static PCShop.Core.Constants.Constant.ColorConstants;
using static PCShop.Core.Constants.Constant.DisplayCoverageConstants;
using static PCShop.Core.Constants.Constant.DisplayTechnologyConstants;
using static PCShop.Core.Constants.Constant.MonitorConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;
using static PCShop.Core.Constants.Constant.ResolutionConstants;
using static PCShop.Core.Constants.Constant.TypeConstants;
using static PCShop.Infrastructure.Constants.DataConstant.BrandConstants;
using static PCShop.Infrastructure.Constants.DataConstant.ColorConstants;
using static PCShop.Infrastructure.Constants.DataConstant.DisplayCoverageConstants;
using static PCShop.Infrastructure.Constants.DataConstant.DisplayTechnologyConstants;
using static PCShop.Infrastructure.Constants.DataConstant.ResolutionConstants;
using static PCShop.Infrastructure.Constants.DataConstant.TypeConstants;

namespace PCShop.Core.Models.Monitor
{
    /// <summary>
    /// MonitorImportViewModel model
    /// </summary>
    public class MonitorImportViewModel
    {
        /// <summary>
        /// Property that represents monitor brand
        /// </summary>
        [Display(Name = "brand")]
        [Required]
        [StringLength(BrandNameMaxLength, MinimumLength = BrandNameMinLength)]
        public string Brand { get; init; } = null!;

        /// <summary>
        /// Property that represents monitor display size
        /// </summary>
        [Display(Name = "display size")]
        [Required]
        public double DisplaySize { get; init; }

        /// <summary>
        /// Property that represents monitor display resolution
        /// </summary>
        [Display(Name = "resolution")]
        [Required]
        [StringLength(ResolutionValueMaxLength, MinimumLength = ResolutionValueMinLength)]
        public string Resolution { get; init; } = null!;

        /// <summary>
        /// Property that represents monitor refresh rate
        /// </summary>
        [Display(Name = "refresh rate")]
        [Required]
        [Range(RefreshRateMinValue, RefreshRateMaxValue, ErrorMessage = IntegerErrorMessage)]
        public int RefreshRate { get; init; }

        /// <summary>
        /// Property that represents monitor type
        /// </summary>
        [Display(Name = "type")]
        [Required]
        [StringLength(TypeNameMaxLength, MinimumLength = TypeNameMinLength)]
        public string Type { get; init; } = null!;

        /// <summary>
        /// Property that represents monitor count
        /// </summary>
        [Display(Name = "quantity")]
        [Required]
        [Range(QuantityMinValue, QuantityMaxValue, ErrorMessage = IntegerErrorMessage)]
        public int Quantity { get; init; }

        /// <summary>
        /// Property that represents monitor price
        /// </summary>
        [Display(Name = "price")]
        [Required]
        public decimal Price { get; init; }

        /// <summary>
        /// Property that represents monitor warranty
        /// </summary>
        [Display(Name = "warranty")]
        [Range(WarrantyMinValue, WarrantyMaxValue, ErrorMessage = IntegerErrorMessage)]
        public int Warranty { get; init; }

        /// <summary>
        /// Property that represents monitor display coverage
        /// </summary>
        [Display(Name = "display coverage")]
        [StringLength(DisplayCoverageNameMaxLength, MinimumLength = DisplayCoverageNameMinLength)]
        public string? DisplayCoverage { get; init; }

        /// <summary>
        /// Property that represents monitor display technology
        /// </summary>
        [Display(Name = "display technology")]
        [StringLength(DisplayTechnologyNameMaxLength, MinimumLength = DisplayTechnologyNameMinLength)]
        public string? DisplayTechnology { get; init; }

        /// <summary>
        /// Property that represents monitor color
        /// </summary>
        [Display(Name = "color")]
        [StringLength(ColorNameMaxLength, MinimumLength = ColorNameMinLength)]
        public string? Color { get; init; }

        /// <summary>
        /// Property that represents monitor image url
        /// </summary>
        [Display(Name = "image url")]
        [Url]
        public string? ImageUrl { get; init; }
    }
}
