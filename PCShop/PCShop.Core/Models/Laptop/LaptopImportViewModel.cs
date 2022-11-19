using System.ComponentModel.DataAnnotations;
using static PCShop.Core.Constants.Constant.BrandConstants;
using static PCShop.Core.Constants.Constant.ColorConstants;
using static PCShop.Core.Constants.Constant.CPUConstants;
using static PCShop.Core.Constants.Constant.DisplayCoverageConstants;
using static PCShop.Core.Constants.Constant.DisplayTechnologyConstants;
using static PCShop.Core.Constants.Constant.LaptopConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;
using static PCShop.Core.Constants.Constant.ResolutionConstants;
using static PCShop.Core.Constants.Constant.TypeConstants;
using static PCShop.Core.Constants.Constant.VideoCardConstants;
using static PCShop.Infrastructure.Constants.DataConstant.BrandConstants;
using static PCShop.Infrastructure.Constants.DataConstant.ColorConstants;
using static PCShop.Infrastructure.Constants.DataConstant.CPUConstants;
using static PCShop.Infrastructure.Constants.DataConstant.DisplayCoverageConstants;
using static PCShop.Infrastructure.Constants.DataConstant.DisplayTechnologyConstants;
using static PCShop.Infrastructure.Constants.DataConstant.ResolutionConstants;
using static PCShop.Infrastructure.Constants.DataConstant.TypeConstants;
using static PCShop.Infrastructure.Constants.DataConstant.VideoCardConstants;

namespace PCShop.Core.Models.Laptop
{
    /// <summary>
    /// LaptopImportViewModel model
    /// </summary>
    public class LaptopImportViewModel
    {
        /// <summary>
        /// Property that represents laptop brand
        /// </summary>
        [Display(Name = "brand")]
        [Required]
        [StringLength(BrandNameMaxLength, MinimumLength = BrandNameMinLength)]
        public string Brand { get; init; } = null!;

        /// <summary>
        /// Property that represents laptop CPU
        /// </summary>
        [Display(Name = "CPU")]
        [Required]
        [StringLength(CPUNameMaxLength, MinimumLength = CPUNameMinLength)]
        public string CPU { get; init; } = null!;

        /// <summary>
        /// Property that represents laptop RAM
        /// </summary>
        [Display(Name = "RAM")]
        [Required]
        [Range(RAMMinValue, RAMMaxValue, ErrorMessage = IntegerErrorMessage)]
        public int RAM { get; init; }

        /// <summary>
        /// Property that represents laptop SSD capacity
        /// </summary>
        [Display(Name = "SSD capacity")]
        [Required]
        [Range(SSDCapacityMinValue, SSDCapacityMaxValue, ErrorMessage = IntegerErrorMessage)]
        public int SSDCapacity { get; init; }

        /// <summary>
        /// Property that represents laptop video card
        /// </summary>
        [Display(Name = "video card")]
        [Required]
        [StringLength(VideoCardNameMaxLength, MinimumLength = VideoCardNameMinLength)]
        public string VideoCard { get; init; } = null!;

        /// <summary>
        /// Property that represents laptop display size
        /// </summary>
        [Display(Name = "display size")]
        [Required]
        public double DisplaySize { get; init; }

        /// <summary>
        /// Property that represents laptop type
        /// </summary>
        [Display(Name = "type")]
        [Required]
        [StringLength(TypeNameMaxLength, MinimumLength = TypeNameMinLength)]
		public string Type { get; init; } = null!;

        /// <summary>
        /// Property that represents laptops count
        /// </summary>
        [Display(Name = "quantity")]
        [Required]
        [Range(QuantityMinValue, QuantityMaxValue, ErrorMessage = IntegerErrorMessage)]
		public int Quantity { get; init; }

        /// <summary>
        /// Property that represents laptop price
        /// </summary>
        [Display(Name = "price")]
        [Required]
        public decimal Price { get; init; }

        /// <summary>
        /// Property that represents laptop warranty
        /// </summary>
        [Display(Name = "warranty")]
        [Range(WarrantyMinValue, WarrantyMaxValue, ErrorMessage = IntegerErrorMessage)]
        public int Warranty { get; init; }

        /// <summary>
        /// Property that represents laptop display coverage
        /// </summary>
        [Display(Name = "display coverage")]
        [StringLength(DisplayCoverageNameMaxLength, MinimumLength = DisplayCoverageNameMinLength)]
		public string? DisplayCoverage { get; init; }

        /// <summary>
        /// Property that represents laptop display technology
        /// </summary>
        [Display(Name = "display technology")]
        [StringLength(DisplayTechnologyNameMaxLength, MinimumLength = DisplayTechnologyNameMinLength)]
		public string? DisplayTechnology { get; init; }

        /// <summary>
        /// Property that represents laptop display resolution
        /// </summary>
        [Display(Name = "resolution")]
        [StringLength(ResolutionValueMaxLength, MinimumLength = ResolutionValueMinLength)]
		public string? Resolution { get; init; }

        /// <summary>
        /// Property that represents laptop color
        /// </summary>
        [Display(Name  = "color")]
        [StringLength(ColorNameMaxLength, MinimumLength = ColorNameMinLength)]
		public string? Color { get; init; }

        /// <summary>
        /// Property that represents laptop image url
        /// </summary>
        [Display(Name = "image url")]
        [Url]
		public string? ImageUrl { get; init; }
	}
}
