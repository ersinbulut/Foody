using Microsoft.AspNetCore.Mvc;

namespace Foody.PresentationLayer.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
	public class _MainPanelLayoutComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
