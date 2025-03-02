using Microsoft.AspNetCore.Mvc;
using Menu.Data;
using Menu.Models;
using Microsoft.EntityFrameworkCore;

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







        [HttpGet]
        public IActionResult AddIngrediant()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddIngrediant(Ingrediant ingrediant)
        {
            if (ModelState.IsValid)
            {
                _context.Ingrediants.Add(ingrediant);
                _context.SaveChanges();
            }
            return View("AddIngrediant");

        }

        [HttpGet]
        public async Task<IActionResult> LinkDishesWithIngredients()
        {
            ViewBag.Dishes = await _context.Dishes.ToListAsync();
            ViewBag.Ingredients = await _context.Ingrediants.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LinkDishesWithIngredients(int DishId, List<int> SelectedIngredients)
        {
            if (SelectedIngredients == null || !SelectedIngredients.Any())
            {
                ModelState.AddModelError("", "Please select at least one ingredient.");
                return RedirectToAction("LinkDishesWithIngredients");
            }

            foreach (var ingId in SelectedIngredients)
            {
                var dishIngredient = new DishIngrediant { DishId = DishId, IngrediantId = ingId };
                _context.DishIngrediants.Add(dishIngredient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Menu"); // Redirect to menu listing
        }



    }
}
