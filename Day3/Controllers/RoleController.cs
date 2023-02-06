using Day3.Data;
using Day3.Repositories;
using Day3.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Runtime.Intrinsics.Arm;

namespace Day3.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class RoleController : Controller
    {
        ApplicationDbContext _context;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            RoleRepo roleRepo = new RoleRepo(_context);
            return View(roleRepo.GetAllRoles());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoleVM rVM) {

            var token = HttpContext.Request.Form["__RequestVerificationToken"];
            if (ModelState.IsValid)
            {
                RoleRepo rRepo = new RoleRepo(_context);
                Boolean result = rRepo.CreateRole(rVM.RoleName);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(rVM);
        }
    }
}
