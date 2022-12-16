using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Microphone;
using PCShop.Core.Services.Interfaces;
using PCShop.Extensions;
using System.Security.Claims;
using static PCShop.Core.Constants.Constant.ClientConstants;
using static PCShop.Core.Constants.Constant.GlobalConstants;
using static PCShop.Core.Constants.Constant.ProductConstants;
using static PCShop.Infrastructure.Constants.DataConstant.RoleConstants;

namespace PCShop.Controllers
{
	/// <summary>
	/// Microphone controller class
	/// </summary>
	[Authorize]
	public class MicrophoneController : Controller
	{
		private readonly IMicrophoneService microphoneService;
		private readonly IClientService clientService;
		private readonly IUserService userService;

		/// <summary>
		/// Constructor of MicrophoneController class
		/// </summary>
		/// <param name="microphoneService">The IMicrophoneService needed for functionality</param>
		/// <param name="clientService">The IClientService needed for functionality</param>
		/// <param name="userService">The IUserService needed for functionality</param>
		public MicrophoneController(
			IMicrophoneService microphoneService,
			IClientService clientService,
			IUserService userService)
		{
			this.microphoneService = microphoneService;
			this.clientService = clientService;
			this.userService = userService;
		}

		/// <summary>
		/// HttpGet action to retrieve all active microphones according to specified criteria
		/// </summary>
		/// <param name="query">The entity that holds the specified criteria</param>
		/// <returns>Collection of all active microphones according to specified criteria</returns>
		[HttpGet]
		public async Task<IActionResult> Index([FromQuery] AllMicrophonesQueryModel query)
		{
			var result = await this.microphoneService.GetAllMicrophonesAsync(
				query.Keyword,
				query.Sorting,
				query.CurrentPage);

			query.TotalProductsCount = result.TotalMicrophonesCount;

			query.Microphones = result.Microphones;

			return View(query);
		}

		/// <summary>
		/// HttpGet action to retrieve detailed information about a specific microphone
		/// </summary>
		/// <param name="id">Microphone unique identifier</param>
		/// <param name="information">Microphone additional information</param>
		/// <returns>Detailed information about the microphone</returns>
		[HttpGet]
		public async Task<IActionResult> Details(int id, string information)
		{
			try
			{
				var microphone = await this.microphoneService.GetMicrophoneByIdAsMicrohoneDetailsExportViewModelAsync(id);

				if (information.ToLower() != microphone.GetInformation().ToLower())
				{
					return NotFound();
				}

				return View(microphone);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Action to mark a specific microphone as deleted
		/// </summary>
		/// <param name="id">Microphone unique identifier</param>
		/// <returns>Redirection to /Microphone/Index</returns>
		[HttpGet]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var microphone = await this.microphoneService.GetMicrophoneByIdAsMicrohoneDetailsExportViewModelAsync(id);

				if (this.User.IsInRole(SuperUser)
					&& (microphone.Seller is null || this.User.Id() != microphone.Seller.UserId))
				{
					return Unauthorized();
				}

				await this.microphoneService.DeleteMicrophoneAsync(id);

				TempData[TempDataMessage] = ProductSuccessfullyDeleted;

				return RedirectToAction(nameof(Index));
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// HttpGet action to return the form for adding a microphone
		/// </summary>
		/// <returns>The form for adding a microphone</returns>
		[HttpGet]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Add()
		{
			if (this.User.IsInRole(SuperUser))
			{
				var userId = this.User.Id();

				try
				{
					var numberOfActiveSales = await this.clientService.GetNumberOfActiveSales(userId);

					if (numberOfActiveSales == MaxNumberOfAllowedSales)
					{
						ViewData["Title"] = "Add a microphone";

						return View(AddNotAllowedViewName);
					}
				}
				catch (PCShopException)
				{
					return View(ErrorCommonViewName);
				}
			}

			return View();
		}

		/// <summary>
		/// HttpPost action to add a microphone
		/// </summary>
		/// <param name="model">Microphone import model</param>
		/// <returns>Redirection to /Microphone/Details</returns>
		[HttpPost]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Add(MicrophoneImportViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return View(model);
			}

			string? userId = null;

			if (this.User.IsInRole(SuperUser))
			{
				userId = this.User.Id();
			}

			try
			{
				int id = await this.microphoneService.AddMicrophoneAsync(model, userId);

				TempData[TempDataMessage] = ProductSuccessfullyAdded;

				return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
			}
			catch (PCShopException)
			{
				return View(ErrorCommonViewName);
			}
			catch (ArgumentException)
			{
				return View(ErrorCommonViewName);
			}
		}

        /// <summary>
        /// HttpGet action to return the form for editing a microphone
        /// </summary>
        /// <param name="id">Microphone unique identifier</param>
        /// <returns>The form for editing a microphone</returns>
        [HttpGet]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				var microphone = await this.microphoneService.GetMicrophoneByIdAsMicrophoneEditViewModelAsync(id);

				if (this.User.IsInRole(SuperUser)
					&& (microphone.Seller is null || this.User.Id() != microphone.Seller.UserId))
				{
					return Unauthorized();
				}

				return View(microphone);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

        /// <summary>
        /// HttpPost action to edit a microphone
        /// </summary>
        /// <param name="model">Microphone import model</param>
        /// <returns>Redirection to /Microphone/Details</returns>
        [HttpPost]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Edit(MicrophoneEditViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				var microphone = await this.microphoneService.GetMicrophoneByIdAsMicrophoneEditViewModelAsync(model.Id);

                if (this.User.IsInRole(SuperUser)
                    && (microphone.Seller is null || this.User.Id() != microphone.Seller.UserId))
                {
                    return Unauthorized();
                }

				int id = await this.microphoneService.EditMicrophoneAsync(model);

                TempData[TempDataMessage] = ProductSuccessfullyEdited;

                return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
            }
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// HttpGet action to retrieve all active microphone sales of the currently logged in user
		/// </summary>
		/// <returns>Collection of all active microphone sales of the currently logged in user</returns>
		[HttpGet]
		[Authorize(Roles = SuperUser)]
		public async Task<IActionResult> Mine()
		{
			var userId = this.User.Id();

			try
			{
				var userMicrophones = await this.microphoneService.GetUserMicrophonesAsync(userId);

				return View(userMicrophones);
			}
			catch (PCShopException)
			{
				return View(ErrorCommonViewName);
			}
		}

		/// <summary>
		/// HttpGet action to buy a microphone
		/// </summary>
		/// <param name="id">Microphone unique identifier</param>
		/// <returns>The corresponding view</returns>
		[HttpGet]
		public async Task<IActionResult> Buy(int id)
		{
			if (this.User.IsInRole(Administrator))
			{
				return Unauthorized();
			}

			try
			{
				var userId = this.User.Id();

				if (this.User.IsInRole(SuperUser))
				{
					var microphoneSeller = (await this.microphoneService.GetMicrophoneByIdAsMicrophoneEditViewModelAsync(id)).Seller;

					if (microphoneSeller is not null && microphoneSeller.UserId == userId)
					{
						return Unauthorized();
					}
				}

				ViewData["Title"] = "Buy a microphone";

				await this.microphoneService.MarkMicrophoneAsBoughtAsync(id);

				var client = await this.clientService.BuyProduct(userId);

				var isNowPromotedToSuperUser = await this.userService.ShouldBePromotedToSuperUser(client);

				if (isNowPromotedToSuperUser)
				{
					return View(PromoteToSuperUserViewName);
				}

				return View(PurchaseMadeViewName);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}
	}
}
