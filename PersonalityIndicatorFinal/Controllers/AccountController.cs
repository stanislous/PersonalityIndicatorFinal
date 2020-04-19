using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PersonalityIndicatorFinal.DbContext;
using PersonalityIndicatorFinal.Models;

namespace PersonalityIndicatorFinal.Controllers
{
    public class AccountController : Controller
    {
        public readonly PiDBContext _PiDbContext = new PiDBContext();
        // GET: Account
       [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            bool userIsAvailable =
                _PiDbContext.Users.Any(x => x.UserName == user.UserName & x.Passward == user.Passward);
            if (userIsAvailable)
            {
                return RedirectToAction("Main", "Home");
            }
            else
            {
                ModelState.AddModelError("","Invalid UserName or Passward.");
                return View();
            }
            
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (user == null)
            {
                RedirectToAction("SignUp", "Account");
            }

            _PiDbContext.Users.Add(user);
            _PiDbContext.SaveChanges();
            return RedirectToAction("Login", "Account");
        }
    }
}