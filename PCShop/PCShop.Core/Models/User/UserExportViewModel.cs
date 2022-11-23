namespace PCShop.Core.Models.User
{
	/// <summary>
	/// UserExportViewModel model
	/// </summary>
	public class UserExportViewModel
	{
		/// <summary>
		/// Constructor of UserExportViewModel class
		/// </summary>
		public UserExportViewModel()
		{
			this.Roles = Enumerable.Empty<string>();
		}

		/// <summary>
		/// Property that represents user unique identifier
		/// </summary>
		public string Id { get; init; } = null!;

		/// <summary>
		/// Property that represents user username
		/// </summary>
		public string Username { get; init; } = null!;

		/// <summary>
		/// Property that represents user email
		/// </summary>
		public string Email { get; init; } = null!;

		/// <summary>
		/// Property that represents user first name
		/// </summary>
		public string FirstName { get; init; } = null!;

		/// <summary>
		/// Property that represents user last name
		/// </summary>
		public string LastName { get; init; } = null!;

		/// <summary>
		/// Property that represents user roles
		/// </summary>
		public IEnumerable<string> Roles { get; init; }
	}
}
