using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Models;
using System.Diagnostics;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}