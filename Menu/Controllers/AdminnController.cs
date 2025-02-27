using Microsoft.AspNetCore.Mvc;

namespace Menu.Controllers
{
    public class AdminnController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
