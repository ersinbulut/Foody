using Microsoft.AspNetCore.Mvc;

namespace Foody.PresentationLayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
