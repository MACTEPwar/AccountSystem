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
            var _currentUser = _userManager.Users.FirstOrDefault(u => u._login == HttpContext.User.Identity.Name);
            if (!_currentUser.EmailConfirmed)
            {
                string[] em = _currentUser.Email.Split(new char[] { '@' });
                ViewData["_emailUrl"] = em[1];
                try
                {
                    
                    ViewData["user_email"] = em[0].Substring(0, em[0].Length - 3) + $"**@{em[1]}";
                }
                catch
                {
                    string ret = string.Empty;
                    for (int i = 0;i < em[0].Length;i++)
                    {
                        ret.Insert(ret.Length, "*");
                    }
                    ViewData["user_email"] =  $"{ret}{em[1]}";
                }
                return View("EmailNotConfimed");
            }
            else
            {

            }
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
