using Microsoft.AspNetCore.Mvc;

namespace GBProject.WebUI.ViewComponents.ListeleViewComponents
{
    public class CustomerViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
