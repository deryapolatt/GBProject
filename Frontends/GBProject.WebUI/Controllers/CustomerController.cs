using Microsoft.AspNetCore.Mvc;

namespace GBProject.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
