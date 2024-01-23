using Microsoft.AspNetCore.Mvc;

namespace GBProject.WebUI.ViewComponents.UILayoutComponents
{
    public class _HeadUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}