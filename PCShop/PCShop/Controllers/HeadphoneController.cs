﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Models.Headphone;
using PCShop.Core.Services.Interfaces;

namespace PCShop.Controllers
{
	/// <summary>
	/// Headphone controller class
	/// </summary>
	[Authorize]
	public class HeadphoneController : Controller
	{
		private readonly IHeadphoneService headphoneService;

		/// <summary>
		/// Constructor of HeadphoneController class
		/// </summary>
		/// <param name="headphoneService">The IHeadphoneService needed for functionality</param>
		public HeadphoneController(IHeadphoneService headphoneService)
		{
			this.headphoneService = headphoneService;
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
	}
}
