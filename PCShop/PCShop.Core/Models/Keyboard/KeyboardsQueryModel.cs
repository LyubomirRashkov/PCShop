namespace PCShop.Core.Models.Keyboard
{
	/// <summary>
	/// KeyboardsQueryModel model
	/// </summary>
	public class KeyboardsQueryModel
	{
		/// <summary>
		/// Constructor of KeyboardsQueryModel class
		/// </summary>
		public KeyboardsQueryModel()
		{
			this.Keyboards = new List<KeyboardExportViewModel>();
		}

		/// <summary>
		/// Property that represents total count of keyboards
		/// </summary>
		public int TotalKeyboardsCount { get; set; }

		/// <summary>
		/// Property that represents a collection of keyboards
		/// </summary>
		public IEnumerable<KeyboardExportViewModel> Keyboards { get; set; }
	}
}
