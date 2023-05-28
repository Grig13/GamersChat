using Microsoft.AspNetCore.Mvc;

namespace GamersChat.Controllers
{
    public class ApplicationUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
