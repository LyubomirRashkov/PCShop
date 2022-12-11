using PCShop.Core.Models.Product;
using System.ComponentModel.DataAnnotations;
using static PCShop.Core.Constants.Constant.TypeConstants;
using static PCShop.Infrastructure.Constants.DataConstant.TypeConstants;

namespace PCShop.Core.Models.Headphone
{
	/// <summary>
	/// HeadphoneImportViewModel model
	/// </summary>
	public class HeadphoneImportViewModel : ProductImportViewModel
	{
		/// <summary>
		/// Property that represents headphone type
		/// </summary>
		[Display(Name = "type")]
		[Required]
		[StringLength(TypeNameMaxLength, MinimumLength = TypeNameMinLength)]
		public string Type { get; init; } = null!;

		/// <summary>
		/// Property that represents if the headphone is wireless
		/// </summary>
		[Display(Name = "wireless")]
		public bool? IsWireless { get; set; }

		/// <summary>
		/// Property that represents if the headphone has a microphone
		/// </summary>
		[Display(Name = "microphone")]
		public bool? HasMicrophone { get; set; }
	}
}
