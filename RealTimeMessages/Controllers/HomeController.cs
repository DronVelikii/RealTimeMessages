using Microsoft.AspNetCore.Mvc;

namespace RealTimeMessages.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
