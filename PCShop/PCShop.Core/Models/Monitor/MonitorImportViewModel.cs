using PCShop.Core.Models.Product;
using System.ComponentModel.DataAnnotations;
using static PCShop.Core.Constants.Constant.DisplayCoverageConstants;
using static PCShop.Core.Constants.Constant.DisplayTechnologyConstants;
using static PCShop.Core.Constants.Constant.MonitorConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;
using static PCShop.Core.Constants.Constant.ResolutionConstants;
using static PCShop.Core.Constants.Constant.TypeConstants;
using static PCShop.Infrastructure.Constants.DataConstant.DisplayCoverageConstants;
using static PCShop.Infrastructure.Constants.DataConstant.DisplayTechnologyConstants;
using static PCShop.Infrastructure.Constants.DataConstant.ResolutionConstants;
using static PCShop.Infrastructure.Constants.DataConstant.TypeConstants;

namespace PCShop.Core.Models.Monitor
{
    /// <summary>
    /// MonitorImportViewModel model
    /// </summary>
    public class MonitorImportViewModel : ProductImportViewModel
    {
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
    }
}
