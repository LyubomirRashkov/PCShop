using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static PCShop.Infrastructure.Constants.DataConstant.RoleConstants;

namespace PCShop.Areas.Administration.Controllers
{
	/// <summary>
	/// Base controller class for Administration area
	/// </summary>
	[Area("Administration")]
    [Route("Administration/[controller]/[action]/{id?}")]
    [Authorize(Roles = Administrator)]
	public class BaseController : Controller
	{
	}
}
