﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Models.Microphone;
using PCShop.Core.Services.Interfaces;
using PCShop.Extensions;
using System.Security.Claims;
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

		/// <summary>
		/// Constructor of MicrophoneController class
		/// </summary>
		/// <param name="microphoneService">The IMicrophoneService needed for functionality</param>
		public MicrophoneController(IMicrophoneService microphoneService)
		{
			this.microphoneService = microphoneService;
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
	}
}
