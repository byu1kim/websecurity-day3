using Day3.Data;
using Day3.ViewModels;
using Day3.Models;
using Microsoft.EntityFrameworkCore;

namespace Day3.Repositories
{
    public class ProductRepo
    {
        ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Product> GetAllProducts()
        {
            var product = _context.Products;

            return product.ToList();
        }

    }
}
