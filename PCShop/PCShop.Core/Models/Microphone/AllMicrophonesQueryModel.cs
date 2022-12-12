using PCShop.Core.Models.Product;

namespace PCShop.Core.Models.Microphone
{
	/// <summary>
	/// AllMicrophonesQueryModel model
	/// </summary>
	public class AllMicrophonesQueryModel : AllProductsQueryModel
	{
		/// <summary>
		/// Constructor of AllMicrophonesQueryModel class
		/// </summary>
		public AllMicrophonesQueryModel()
		{
			this.Microphones = Enumerable.Empty<MicrophoneExportViewModel>();
		}

		/// <summary>
		/// Property that represents a collecion of microphones according to specified criteria
		/// </summary>
		public IEnumerable<MicrophoneExportViewModel> Microphones { get; set; }
	}
}
