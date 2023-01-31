using Day3.Data;
using Day3.Models;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public IActionResult Transactions()
        {
            DbSet<IPN> items = _context.IPNs;
            return View(items);
        }

        [Authorize]
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


        [Authorize]
        public IActionResult Confirmation(string confirmationId)
        {
            IPN transaction =
            _context.IPNs.FirstOrDefault(t => t.paymentID == confirmationId);

            return View("Confirmation", transaction);
        }

        [Authorize]
        public IActionResult SecureArea()
        {   
            string userName = User.Identity.Name;

            var registeredUser = _context.MyRegisteredUsers
                                         .Where(ru => ru.Email == userName)
                                         .FirstOrDefault();

            return View(registeredUser);
        }

 


    }
}