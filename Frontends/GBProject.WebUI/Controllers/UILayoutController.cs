using Microsoft.AspNetCore.Mvc;

namespace GBProject.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
