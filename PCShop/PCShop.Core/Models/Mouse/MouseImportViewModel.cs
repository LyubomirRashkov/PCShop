using PCShop.Core.Models.Product;
using System.ComponentModel.DataAnnotations;
using static PCShop.Core.Constants.Constant.TypeConstants;
using static PCShop.Infrastructure.Constants.DataConstant.TypeConstants;

namespace PCShop.Core.Models.Mouse
{
	/// <summary>
	/// MouseImportViewModel model
	/// </summary>
	public class MouseImportViewModel : ProductImportViewModel
	{
		/// <summary>
		/// Constructor of MouseImportViewModel class
		/// </summary>
		public MouseImportViewModel()
		{
			this.Sensitivities = Enumerable.Empty<string>();
		}

		/// <summary>
		/// Property that represents if the mouse is wireless
		/// </summary>
		[Display(Name = "wireless")]
		public bool? IsWireless { get; set; }

		/// <summary>
		/// Property that represents mouse type
		/// </summary>
		[Display(Name = "type")]
		[Required]
		[StringLength(TypeNameMaxLength, MinimumLength = TypeNameMinLength)]
		public string Type { get; init; } = null!;

		/// <summary>
		/// Property that represents mouse sensitivity range
		/// </summary>
		[Display(Name = "sensitivity range")]
		public string? Sensitivity { get; set; }

		/// <summary>
		/// Property that represents a collection of all mouse sensitivity ranges
		/// </summary>
		public IEnumerable<string> Sensitivities { get; set; }
	}
}
