using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Models;

namespace Project1.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserContext _context;

        public RegistrationController(UserContext context)
        {
            _context = context;
        }

        // Action method for displaying the registration form
        public IActionResult Register()
        {
            return View();
        }

        // Action method to handle the submission of the registration form
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index", "Secure");
            }

            return View(user);
        }
    }
}
