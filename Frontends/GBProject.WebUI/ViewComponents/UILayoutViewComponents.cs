using Microsoft.AspNetCore.Mvc;

namespace GBProject.WebUI.ViewComponents
{
    public class UILayoutViewComponents: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); //view component'ler asp.net core ile gelen bir özellik.Mvc'de de var ama view component'ler daha gelişmiş.
        }
    }
}
