using Microsoft.AspNetCore.Mvc;
using Menu.Models;
using Newtonsoft.Json;

namespace Menu.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Plate()
        {
            var cart = GetCartFromSession();

            
            double totalPrice = cart.Sum(item => item.Price * item.Quantity);

            ViewBag.TotalPrice = totalPrice; // Pass total price to the view
          
            return View("~/Views/Menu/Plate.cshtml", cart); // Specify the correct view path
        }

        [HttpGet]
        public IActionResult GetCartCount()
        {
            var cart = GetCartFromSession();
            return Json(cart.Count);
        }


        [HttpPost]
        public IActionResult AddToCart(int dishId, string name, double price, string imageUrl)
        {
            var cart = GetCartFromSession();

            var existingItem = cart.FirstOrDefault(i => i.DishId == dishId);
            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
            else
            {
                cart.Add(new CartItem { DishId = dishId, Name = name, Price = price, ImageUrl = imageUrl, Quantity = 1 });
            }

            SaveCartToSession(cart);
            return RedirectToAction("Plate", "Cart"); // Ensure it points to CartController
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int dishId)
        {
            var cart = GetCartFromSession();
            var item = cart.FirstOrDefault(i => i.DishId == dishId);
            if (item != null)
            {
                cart.Remove(item);
                SaveCartToSession(cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Payment(double totalPrice)
        {
            ViewBag.TotalAmount = totalPrice; // Pass totalPrice to the view
            return View("~/Views/Menu/Payment.cshtml"); // Specify the exact view path
                                                        
                                                        
        }

            private List<CartItem> GetCartFromSession()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            return cartJson == null ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
        }

        private void SaveCartToSession(List<CartItem> cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("Cart", cartJson);
        }
    }
}
