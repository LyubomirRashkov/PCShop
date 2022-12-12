using PCShop.Core.Constants;
using PCShop.Core.Models.Microphone;

namespace PCShop.Core.Services.Interfaces
{
	/// <summary>
	/// Abstraction of MicrophoneService
	/// </summary>
	public interface IMicrophoneService
	{
		/// <summary>
		/// Method to retrieve all active microphones according to specified criteria
		/// </summary>
		/// <param name="keyword">The criterion for keyword</param>
		/// <param name="sorting">The criterion for sorting</param>
		/// <param name="currentPage">Current page number</param>
		/// <returns>MicrophonesQueryModel object</returns>
		Task<MicrophonesQueryModel> GetAllMicrophonesAsync(
			string? keyword = null, 
			Sorting sorting = Sorting.Newest,
			int currentPage = 1);

		/// <summary>
		/// Method to retrieve a specific microphone
		/// </summary>
		/// <param name="id">Microphone unique identifier</param>
		/// <returns>The microphone as MicrophoneDetailsExportViewModel</returns>
		Task<MicrophoneDetailsExportViewModel> GetMicrophoneByIdAsMicrohoneDetailsExportViewModelAsync(int id);

		/// <summary>
		/// Method to mark a specific microphone as deleted
		/// </summary>
		/// <param name="id">Microphone unique identifier</param>
		Task DeleteMicrophoneAsync(int id);

		/// <summary>
		/// Method to add a microphone
		/// </summary>
		/// <param name="model">Microphone input model</param>
		/// <param name="userId">Microphone's owner unique identifier</param>
		/// <returns>The unique identifier of the added microphone</returns>
		Task<int> AddMicrophoneAsync(MicrophoneImportViewModel model, string? userId);

        /// <summary>
        /// Method to retrieve a specific microphone
        /// </summary>
        /// <param name="id">Microphone unique identifier</param>
        /// <returns>The microphone as MicrophoneEditViewModel</returns>
        Task<MicrophoneEditViewModel> GetMicrophoneByIdAsMicrophoneEditViewModelAsync(int id);

        /// <summary>
        /// Method to edit a microphone
        /// </summary>
        /// <param name="model">Microphone input model</param>
        /// <returns>The unique identifier of the edited microphone</returns>
        Task<int> EditMicrophoneAsync(MicrophoneEditViewModel model);

		/// <summary>
		/// Method to retrieve all active microphones sales of the currently logged in user
		/// </summary>
		/// <param name="userId">User unique identifier</param>
		/// <returns>Collection of MicrophoneDetailsExportViewModels</returns>
		Task<IEnumerable<MicrophoneDetailsExportViewModel>> GetUserMicrophonesAsync(string userId);
	}
}
