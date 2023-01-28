using Day3.Data;
using Day3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Diagnostics;

namespace Day3.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Home page shows list of items.
        // Item price is set through the ViewBag.
        public IActionResult Index()
        {
            return View("Index", "3.55|CAD");
        }

        // Home page shows list of items.
        // Item price is set through the ViewBag.
        public IActionResult Transactions()
        {
            DbSet<IPN> items = _context.IPNs;

            return View(items);
        }

        // This method receives and stores
        // the Paypal transaction details.
        [HttpPost]
        public JsonResult PaySuccess([FromBody] IPN ipn)
        {
            try
            {
                _context.IPNs.Add(ipn);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json(ipn);
        }

        // Home page shows list of items.
        // Item price is set through the ViewBag.
        public IActionResult Confirmation(string confirmationId)
        {
            IPN transaction =
            _context.IPNs.FirstOrDefault(t => t.paymentID == confirmationId);

            return View("Confirmation", transaction);
        }

    }
}