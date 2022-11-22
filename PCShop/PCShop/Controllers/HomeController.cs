using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PCShop.Controllers
{
    /// <summary>
    /// Home controller class
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// Action that returns the home page
        /// </summary>
        /// <returns>The home page</returns>
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action that handles errors
        /// </summary>
        /// <param name="statusCode">The status code of the response</param>
        /// <returns>The corresponding page</returns>
        public IActionResult Error(int statusCode)
        {
			return statusCode switch
			{
				401 => View("Error401"),
				404 => View("Error404"),
				_ => View("Error")
			};
		}
    }
}