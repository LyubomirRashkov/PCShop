﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Headphone;
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
	/// Headphone controller class
	/// </summary>
	[Authorize]
	public class HeadphoneController : Controller
	{
		private readonly IHeadphoneService headphoneService;
		private readonly IClientService clientService;

		/// <summary>
		/// Constructor of HeadphoneController class
		/// </summary>
		/// <param name="headphoneService">The IHeadphoneService needed for functionality</param>
		/// <param name="clientService">The IClientService needed for functionality</param>
		public HeadphoneController(
			IHeadphoneService headphoneService,
			IClientService clientService)
		{
			this.headphoneService = headphoneService;
			this.clientService = clientService;
		}

		/// <summary>
		/// HttpGet action to retrieve all active headphones according to specified criteria
		/// </summary>
		/// <param name="query">The entity that holds the specified criteria</param>
		/// <returns>Collection of all active headphones according to specified criteria</returns>
		[HttpGet]
		public async Task<IActionResult> Index([FromQuery] AllHeadphonesQueryModel query)
		{
			var result = await this.headphoneService.GetAllHeadphonesAsync(
				query.Type,
				query.Wireless,
				query.Keyword,
				query.Sorting,
				query.CurrentPage);

			query.TotalHeadphonesCount = result.TotalHeadphonesCount;

			query.Types = await this.headphoneService.GetAllHeadphonesTypesAsync();

			query.Headphones = result.Headphones;

			return View(query);
		}

		/// <summary>
		/// HttpGet action to retrieve detailed information about a specific headphone
		/// </summary>
		/// <param name="id">Headphone unique identifier</param>
		/// <param name="information">Headphone additional information</param>
		/// <returns>Detailed information about the headphone</returns>
		[HttpGet]
		public async Task<IActionResult> Details(int id, string information)
		{
			try
			{
				var headphone = await this.headphoneService.GetHeadphoneByIdAsHeadphoneDetailsExportViewModelAsync(id);

				if (information.ToLower() != headphone.GetInformation().ToLower())
				{
					return NotFound();
				}

				return View(headphone);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Action to mark a specific headphone as deleted
		/// </summary>
		/// <param name="id">Headphone unique identifier</param>
		/// <returns>Redirection to /Headphone/Index</returns>
		[HttpGet]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var headphone = await this.headphoneService.GetHeadphoneByIdAsHeadphoneDetailsExportViewModelAsync(id);

				if (this.User.IsInRole(SuperUser)
					&& (headphone.Seller is null || this.User.Id() != headphone.Seller.UserId))
				{
					return Unauthorized();
				}

				await this.headphoneService.DeleteHeadphoneAsync(id);

				TempData[TempDataMessage] = ProductSuccessfullyDeleted;

				return RedirectToAction(nameof(Index));
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// HttpGet action to return the form for adding a headphone
		/// </summary>
		/// <returns>The form for adding a headphone</returns>
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
						ViewData["Title"] = "Add a headphone";

						return View(AddNotAllowedViewName);
					}
				}
				catch (PCShopException)
				{
					return View(ErrorCommonViewName);
				}
			}

			var model = new HeadphoneImportViewModel();

			return View(model);
		}

		/// <summary>
		/// HttpPost action to add a headphone
		/// </summary>
		/// <param name="model">Headphone import model</param>
		/// <param name="rbIsWireless">The value of selected radio button for connectivity</param>
		/// <param name="rbHasMicrophone">The value of selected radio button for microphone availability</param>
		/// <returns>Redirection to /Headphone/Details</returns>
		[HttpPost]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Add(HeadphoneImportViewModel model, bool? rbIsWireless, bool? rbHasMicrophone)
		{
			if (rbIsWireless is null && rbHasMicrophone is null)
			{
				this.ModelState.AddModelError("IsWireless", ErrorMessageForUnselectedOption);

				this.ModelState.AddModelError("HasMicrophone", ErrorMessageForUnselectedOption);
			}
			else if (rbIsWireless is null)
			{
				this.ModelState.AddModelError("IsWireless", ErrorMessageForUnselectedOption);

				model.HasMicrophone = rbHasMicrophone;
			}
			else if (rbHasMicrophone is null)
			{
				this.ModelState.AddModelError("HasMicrophone", ErrorMessageForUnselectedOption);

				model.IsWireless = rbIsWireless;
			}
			else
			{
				model.IsWireless = rbIsWireless;

				model.HasMicrophone = rbHasMicrophone;
			}

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
				int id = await this.headphoneService.AddHeadphoneAsync(model, userId);

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
	}
}
