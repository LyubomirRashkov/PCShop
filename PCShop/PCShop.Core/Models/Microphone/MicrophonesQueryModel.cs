namespace PCShop.Core.Models.Microphone
{
	/// <summary>
	/// MicrophonesQueryModel model
	/// </summary>
	public class MicrophonesQueryModel
	{
		/// <summary>
		/// Constructor of MicrophonesQueryModel class
		/// </summary>
		public MicrophonesQueryModel()
		{
			this.Microphones = new List<MicrophoneExportViewModel>();
		}

		/// <summary>
		/// Property that represents total count of microphones
		/// </summary>
		public int TotalMicrophonesCount { get; set; }

		/// <summary>
		/// Property that represents a collection of microphones
		/// </summary>
		public IEnumerable<MicrophoneExportViewModel> Microphones { get; set; }
	}
}
