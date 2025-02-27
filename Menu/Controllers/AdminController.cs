using Microsoft.AspNetCore.Mvc;
using Menu.Data;
using Menu.Models;

namespace Menu.Controllers
{
    public class AdminController : Controller
    {
        private readonly MenuContext _context;

        public AdminController(MenuContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Dish dish)
        {
            if (ModelState.IsValid)
            {
                _context.Dishes.Add(dish);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home"); // Redirect to Home after adding
            }
            return View(dish);
        }
    }
}
