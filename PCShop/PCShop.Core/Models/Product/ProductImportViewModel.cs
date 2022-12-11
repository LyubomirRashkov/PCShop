using System.ComponentModel.DataAnnotations;
using static PCShop.Core.Constants.Constant.BrandConstants;
using static PCShop.Core.Constants.Constant.ColorConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;
using static PCShop.Infrastructure.Constants.DataConstant.BrandConstants;
using static PCShop.Infrastructure.Constants.DataConstant.ColorConstants;

namespace PCShop.Core.Models.Product
{
	/// <summary>
	/// ProductImportViewModel model
	/// </summary>
	public abstract class ProductImportViewModel : IProductModel
	{
		/// <summary>
		/// Property that represents product brand
		/// </summary>
		[Display(Name = "brand")]
		[Required]
		[StringLength(BrandNameMaxLength, MinimumLength = BrandNameMinLength)]
		public string Brand { get; init; } = null!;

		/// <summary>
		/// Property that represents products count
		/// </summary>
		[Display(Name = "quantity")]
		[Required]
		[Range(QuantityMinValue, QuantityMaxValue, ErrorMessage = IntegerErrorMessage)]
		public int? Quantity { get; init; }

		/// <summary>
		/// Property that represents product price
		/// </summary>
		[Display(Name = "price")]
		[Required]
		public decimal? Price { get; init; }

		/// <summary>
		/// Property that represents product warranty
		/// </summary>
		[Display(Name = "warranty")]
		[Required]
		[Range(WarrantyMinValue, WarrantyMaxValue, ErrorMessage = IntegerErrorMessage)]
		public int Warranty { get; init; }

		/// <summary>
		/// Property that represents product color
		/// </summary>
		[Display(Name = "color")]
		[StringLength(ColorNameMaxLength, MinimumLength = ColorNameMinLength)]
		public string? Color { get; init; }

		/// <summary>
		/// Property that represents product image url
		/// </summary>
		[Display(Name = "image url")]
		[Url]
		public string? ImageUrl { get; init; }
	}
}
