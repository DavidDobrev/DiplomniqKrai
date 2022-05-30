using BusStationTickets.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusStationTickets.Models;

namespace BusStationTickets.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Category.OrderBy(c => c.Name).ToList();
            return View(categories);
        }
        public IActionResult Browse(int id)
        {
            var products = _context.Products.Where(p => p.CategoryId == id).OrderBy(p => p.Name).ToList();
            ViewBag.categories = _context.Products.Find(id).Name.ToString();
            return View(products);
        }
        public IActionResult AddToCart(int ProductId , int Quality)
        {
            var price = _context.Products.Find(ProductId).Price;
            var currectDateTime = DateTime.Now;
            var CustomerId = GetCustomerId();

            var cart = new Cart
            {
                ProductId = ProductId,
                Quality = Quality,
                Price = price,
                DateCreated = currectDateTime,
                CustomerId = CustomerId
            };
            _context.Carts.Add(cart);
            _context.SaveChanges();

            return RedirectToAction("Cart");
        }
        private string GetCustomerId()
        {
            if (HttpContext.Session.GetString("CustomerId") == null)
            {
                var CustomerId = "";
                if (User.Identity.IsAuthenticated)
                {
                    CustomerId = User.Identity.Name;
                }
                else
                {
                    CustomerId = Guid.NewGuid().ToString();
                }
                HttpContext.Session.SetString("CustomerId", CustomerId);
            }
            
            return HttpContext.Session.GetString("CustomerId");
        }
        
        public IActionResult Cart()
        {
            var CustomerId = "";
            if (HttpContext.Session.GetString("CustomerId") == null)
            {
                CustomerId = GetCustomerId();
            }
            else
            {
                CustomerId = HttpContext.Session.GetString("CustomerId"); 
            }
            var cartItems = _context.Carts.Where(c => c.CustomerId == CustomerId).ToList();
                return View();
        }
    }
}
