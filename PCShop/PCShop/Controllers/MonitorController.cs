﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Core.Exceptions;
using PCShop.Core.Models.Monitor;
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
	/// Monitor controller class
	/// </summary>
	[Authorize]
	public class MonitorController : Controller
	{
		private readonly IMonitorService monitorService;
		private readonly IClientService clientService;
		private readonly IUserService userService;

		/// <summary>
		/// Constructor of MonitorController class
		/// </summary>
		/// <param name="monitorService">The IMonitorService needed for functionality</param>
		/// <param name="clientService">The IClientService needed for functionality</param>
		/// <param name="userService">The IUserService needed for functionality</param>
		public MonitorController(
			IMonitorService monitorService, 
			IClientService clientService,
			IUserService userService)
		{
			this.monitorService = monitorService;
			this.clientService = clientService;
			this.userService = userService;
		}

		/// <summary>
		/// HttpGet action to retrieve all active monitors according to specified criteria
		/// </summary>
		/// <param name="query">The entity that holds the specified criteria</param>
		/// <returns>Collection of all active monitors according to specified criteria</returns>
		[HttpGet]
		public async Task<IActionResult> Index([FromQuery] AllMonitorsQueryModel query)
		{
			var result = await this.monitorService.GetAllMonitorsAsync(
				query.Brand,
				query.DisplaySize,
				query.Resolution,
				query.RefreshRate,
				query.Keyword,
				query.Sorting,
				query.CurrentPage);

			query.TotalProductsCount = result.TotalMonitorsCount;

			query.Brands = await this.monitorService.GetAllBrandsNamesAsync();
			query.DisplaySizes = await this.monitorService.GetAllDisplaysSizesValuesAsync();
			query.Resolutions = await this.monitorService.GetAllResolutionsValuesAsync();
			query.RefreshRates = await this.monitorService.GetAllRefreshRatesValuesAsync();

			query.Monitors = result.Monitors;

			return View(query);
		}

		/// <summary>
		/// HttpGet action to retrieve detailed information about a specific monitor
		/// </summary>
		/// <param name="id">Monitor unique identifier</param>
		/// <param name="information">Monitor additional information</param>
		/// <returns>Detailedinformation about the monitor</returns>
		[HttpGet]
		public async Task<IActionResult> Details(int id, string information)
		{
			try
			{
				var monitor = await this.monitorService.GetMonitorByIdAsMonitorDetailsExportViewModelAsync(id);

				if (information.ToLower() != monitor.GetInformation().ToLower())
				{
					return NotFound();
				}

				return View(monitor);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Action to mark a specific monitor as deleted
		/// </summary>
		/// <param name="id">Monitor unique identifier</param>
		/// <returns>Redirection to /Monitor/Index</returns>
		[HttpGet]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var monitor = await this.monitorService.GetMonitorByIdAsMonitorDetailsExportViewModelAsync(id);

				if (this.User.IsInRole(SuperUser) 
					&& (monitor.Seller is null || this.User.Id() != monitor.Seller.UserId))
				{
					return Unauthorized();
				}

				await this.monitorService.DeleteMonitorAsync(id);

				TempData[TempDataMessage] = ProductSuccessfullyDeleted;

				return RedirectToAction(nameof(Index));
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

        /// <summary>
        /// HttpGet action to return the form for adding a monitor
        /// </summary>
        /// <returns>The form for adding a monitor</returns>
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
						ViewData["Title"] = "Add a monitor";

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
        /// HttpPost action to add a monitor
        /// </summary>
        /// <param name="model">Monitor import model</param>
        /// <returns>Redirection to /Monitor/Details</returns>
        [HttpPost]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Add(MonitorImportViewModel model)
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
				int id = await this.monitorService.AddMonitorAsync(model, userId);

				TempData[TempDataMessage] = ProductSuccessfullyAdded;

				return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
			}
			catch (PCShopException)
			{
				return View(ErrorCommonViewName);
			}
		}

        /// <summary>
        /// HttpGet action to return the form for editing a monitor
        /// </summary>
        /// <param name="id">Monitor unique identifier</param>
        /// <returns>The form for editing a monitor</returns>
        [HttpGet]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				var monitor = await this.monitorService.GetMonitorByIdAsMonitorEditViewModelAsync(id);

				if (this.User.IsInRole(SuperUser) 
					&& (monitor.Seller is null || this.User.Id() != monitor.Seller.UserId))
				{
					return Unauthorized();
				}

				return View(monitor);
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

        /// <summary>
        /// HttpPost action to edit a monitor
        /// </summary>
        /// <param name="model">Monitor import model</param>
        /// <returns>Redirection to /Monitor/Details</returns>
        [HttpPost]
		[Authorize(Roles = $"{Administrator}, {SuperUser}")]
		public async Task<IActionResult> Edit(MonitorEditViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				var monitor = await this.monitorService.GetMonitorByIdAsMonitorEditViewModelAsync(model.Id);

				if ((this.User.IsInRole(SuperUser)) 
					&& (monitor.Seller is null || this.User.Id() != monitor.Seller.UserId))
				{
					return Unauthorized();
				}

				int id = await this.monitorService.EditMonitorAsync(model);

				TempData[TempDataMessage] = ProductSuccessfullyEdited;

				return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
			}
			catch (ArgumentException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// HttpGet action to retrieve all active monitor sales of the currently logged in user
		/// </summary>
		/// <returns>Collection of all active monitor sales of the currently logged in user</returns>
		[HttpGet]
		[Authorize(Roles = SuperUser)]
		public async Task<IActionResult> Mine()
		{
			var userId = this.User.Id();

			try
			{
				var userMonitors = await this.monitorService.GetUserMonitorsAsync(userId);

				return View(userMonitors);
			}
			catch (PCShopException)
			{
				return View(ErrorCommonViewName);
			}
		}

		/// <summary>
		/// HttpGet action to buy a monitor
		/// </summary>
		/// <param name="id">Monitor unique identifier</param>
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
					var monitorSeller = (await this.monitorService.GetMonitorByIdAsMonitorEditViewModelAsync(id)).Seller;

					if (monitorSeller is not null && monitorSeller.UserId == userId)
					{
						return Unauthorized();
					}
				}

				ViewData["Title"] = "Buy a monitor";

				await this.monitorService.MarkMonitorAsBoughtAsync(id);

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
