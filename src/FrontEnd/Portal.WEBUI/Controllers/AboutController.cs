using Microsoft.AspNetCore.Mvc;

namespace Portal.WEBUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
