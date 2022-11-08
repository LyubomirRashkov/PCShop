using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Services.Interfaces;

namespace PCShop.Controllers
{
    /// <summary>
    /// Laptop controller class
    /// </summary>
    [Authorize]
    public class LaptopController : Controller
    {
        private readonly ILaptopService laptopService;

        /// <summary>
        /// Constructor of LaptopController class
        /// </summary>
        /// <param name="laptopService">The ILaptopService needed for functionality</param>
        public LaptopController(ILaptopService laptopService)
        {
            this.laptopService = laptopService;
        }

        /// <summary>
        /// HttpGet action to retrieve all active laptops
        /// </summary>
        /// <returns>Collection of laptops</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var laptops = await this.laptopService.GetAllLaptopsAsync();

            return View(laptops);
        }

        /// <summary>
        /// HttpGet action to retrieve detailed information about a specific laptop
        /// </summary>
        /// <param name="id">Laptop unique identifier</param>
        /// <returns>Detailed information about the laptop</returns>
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var laptop = await this.laptopService.GetLaptopByIdAsync(id);

                return View(laptop);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
