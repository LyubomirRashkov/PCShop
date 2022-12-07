using Microsoft.AspNetCore.Mvc;

namespace PCShop.Areas.Administration.Controllers
{
	/// <summary>
	/// Home controller class
	/// </summary>
	public class HomeController : BaseController
	{
		/// <summary>
		/// Action that returns the admin page
		/// </summary>
		/// <returns>The admin page</returns>
		public IActionResult Index()
		{
			return View();
		}
	}
}
