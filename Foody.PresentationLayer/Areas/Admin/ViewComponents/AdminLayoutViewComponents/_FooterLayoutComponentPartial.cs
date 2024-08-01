using Microsoft.AspNetCore.Mvc;

namespace Foody.PresentationLayer.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
	public class _FooterLayoutComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
