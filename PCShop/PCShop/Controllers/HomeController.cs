using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static PCShop.Infrastructure.Constants.DataConstant.RoleConstants;

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
            if (this.User.IsInRole(Administrator))
            {
                return RedirectToAction(nameof(HomeController.Index), "Home", new { area = "Administration" });
            }

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