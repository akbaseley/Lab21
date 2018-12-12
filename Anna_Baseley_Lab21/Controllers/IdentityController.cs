using Anna_Baseley_Lab21.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;

namespace Anna_Baseley_Lab21.Controllers
{
    public class IdentityController : Controller
    {
        // GET: Identity

        public ActionResult Registration() { return View(); }

        [HttpPost]
        public ActionResult Registration(LoginModel newUser)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.First_Name = newUser.First_Name;
                user.Last_Name = newUser.Last_Name;
                user.Email = newUser.Email;
                user.UserName = newUser.Email;

                var userManager = HttpContext.GetOwinContext().Get<UserManager<User>>();
                var x = userManager.Create(user, newUser.PasswordHash);

                if (x.Succeeded)
                {
                    return RedirectToAction("Login", "Identity", newUser);
                }
            }

            return RedirectToAction("Registration");

        }

        public ActionResult Login() { return View(); }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {

            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().Get<UserManager<User>>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                User user = userManager.Find(login.UserName, login.PasswordHash);

                if(user != null)
                {
                    var ident = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authManager.SignIn(new AuthenticationProperties
                        { IsPersistent = false }, ident);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}