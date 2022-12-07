using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PCShop.Core.Models.User;
using PCShop.Infrastructure.Data.Models.Account;
using static PCShop.Areas.Administration.Constant;

namespace PCShop.Controllers
{
    /// <summary>
    /// Account controller class
    /// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMemoryCache memoryCache;

		/// <summary>
		/// Constructor of AccountController class
		/// </summary>
		/// <param name="userManager">The UserManager<c>User</c> needed for functionality</param>
		/// <param name="signInManager">The SignInManager<c>User</c> needed for functionality</param>
		/// <param name="memoryCache">The IMemoryCache needed for functionality</param>
		public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMemoryCache memoryCache)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.memoryCache = memoryCache;
        }

        /// <summary>
        /// HttpGet action for signing up
        /// </summary>
        /// <returns>A page that contains a form that must be filled</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            if (this.User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var model = new SignUpViewModel();

            return View(model);
        }

        /// <summary>
        /// HttpPost action for signing up
        /// </summary>
        /// <param name="model">The model that is filled by the user</param>
        /// <returns>If the model is valid creates the user, signs in the user and returns the home page. If there is an error returns the model</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, isPersistent: false);

                this.memoryCache.Remove(UsersCacheKey);

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        /// <summary>
        /// HttpGet action for signing in
        /// </summary>
        /// <returns>A page that contains a form that must be filled</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignIn(string? returnUrl = null)
        {
            if (this.User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var model = new SignInViewModel()
            {
                ReturnUrl = returnUrl,
            };
            return View(model);
        }

        /// <summary>
        /// HttpPost action for signing in
        /// </summary>
        /// <param name="model">The model that is filled by the user</param>
        /// <returns>If the model is valid signs in the user, then returns the required page or the home page. If there is an error returns the model</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var user = await this.userManager.FindByNameAsync(model.UserName);

            if (user is not null)
            {
                var result = await this.signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (model.ReturnUrl is not null)
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }

            this.ModelState.AddModelError("", "Invalid sign in attempt!");

            return View(model);
        }

        /// <summary>
        /// Action for signing out
        /// </summary>
        /// <returns>The home page</returns>
        public async Task<IActionResult> Signout()
        {
            await this.signInManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
	}
}
