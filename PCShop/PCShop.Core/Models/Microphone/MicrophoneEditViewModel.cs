using PCShop.Infrastructure.Data.Models;

namespace PCShop.Core.Models.Microphone
{
	/// <summary>
	/// MicrophoneEditViewModel model
	/// </summary>
	public class MicrophoneEditViewModel : MicrophoneImportViewModel, IProductModel
	{
		/// <summary>
		/// Property that represents microphone unique identifier
		/// </summary>
		public int Id { get; init; }

		/// <summary>
		/// Property that represents microphone Seller
		/// </summary>
		public Client? Seller { get; init; }
	}
}
