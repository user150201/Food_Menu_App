using Microsoft.AspNetCore.Mvc;
using Menu.Data;
using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class Menu : Controller
    {

        private readonly MenuContext _context;

        public Menu(MenuContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index(string searchString)
        {
            var dishes = from d in _context.Dishes 
                       select d;

            if (!string.IsNullOrEmpty(searchString))
            {
                dishes=dishes.Where(d=>d.Name.Contains(searchString));
                return View(await dishes.ToListAsync());

            }

            return View(await _context.Dishes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var dish = await _context.Dishes
                .Include(di=>di.DishIngrediants)
                .ThenInclude(i=>i.Ingrediant)
                .FirstOrDefaultAsync(x=>x.Id==id);

            if(dish == null)
            {
                return NotFound();
            }


            return View(dish);
        }
    }
}
