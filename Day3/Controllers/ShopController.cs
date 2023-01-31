using Day3.Data;
using Day3.Models;
using Day3.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Day3.Controllers
{
    
    public class ShopController : Controller
    {
        ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ProductRepo pRepo = new ProductRepo(_context);
            List<Product> products = pRepo.GetAllProducts();
            return View(products);
        }
    }
}
