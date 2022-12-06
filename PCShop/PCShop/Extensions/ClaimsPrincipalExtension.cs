namespace System.Security.Claims
{
	/// <summary>
	/// ClaimsPrincipalExtension model
	/// </summary>
	public static class ClaimsPrincipalExtension
	{
		/// <summary>
		/// Extension method for getting ClaimsPrincipal's unique identifier
		/// </summary>
		/// <param name="user">The ClaimsPrincipal that will be extended</param>
		/// <returns>ClaimsPrincipal's unique identifier</returns>
		public static string Id(this ClaimsPrincipal user)
		{
			return user.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
