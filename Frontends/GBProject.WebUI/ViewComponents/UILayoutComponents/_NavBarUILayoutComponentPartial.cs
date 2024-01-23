using Microsoft.AspNetCore.Mvc;

namespace GBProject.WebUI.ViewComponents.UILayoutComponents
{
    public class _NavBarUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
