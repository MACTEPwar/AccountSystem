using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace AccountSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public HomeController(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (!HttpContext.User.Identity.IsAuthenticated) return Redirect("~/Identity/Account/Login");
            //if (_userManager.Users.FirstOrDefault(u => u.))
            ViewData["asd"] = HttpContext.User.Identity.Name;
                return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
