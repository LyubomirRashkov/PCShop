﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Models.Microphone;
using PCShop.Core.Services.Interfaces;

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
	}
}
