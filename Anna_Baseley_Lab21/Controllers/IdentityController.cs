using Anna_Baseley_Lab21.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anna_Baseley_Lab21.Controllers
{
    public class IdentityController : Controller
    {
        public UserManager<IdentityUser> userManager =>
            HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();

        // GET: Identity
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegisterModel newUser)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser() {
                    Email = newUser.Email,
                    PhoneNumber = newUser.Phone_Number,
                    UserName = newUser.Email,
                };

                var IdentityResult = userManager.Create(user, newUser.Password);
                if (IdentityResult.Succeeded)
                {
                    CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
                    User addUser = new User()
                    {
                        First_Name = newUser.First_Name,
                        Last_Name = newUser.Last_Name,
                        Email = newUser.Email,
                        Phone_Number = newUser.Phone_Number,
                    };

                    ORM.Users.Add(addUser);
                    ORM.SaveChanges();
                    return RedirectToAction("Login", newUser);
                }
            }
            return View();
        }

        public ActionResult Login() { return View(); }

        [HttpPost]
        public ActionResult Login(LoginModel loginUser)
        {

            if (ModelState.IsValid)
            {
                var authManager = HttpContext.GetOwinContext().Authentication;

                IdentityUser user = userManager.Find(loginUser.UserName, loginUser.Password);

                if(user != null)
                {
                    var ident = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);

                    return RedirectToAction("Confirm");

                }
            }

            ModelState.AddModelError("", "Invalid username or password");
            return RedirectToAction("Login");
        }

        public ActionResult Confirm()
        {
            string userEmail = User.Identity.Name;

            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            User currentUser = ORM.Users.FirstOrDefault(i => i.Email == userEmail);
            return View(currentUser);
        }


    }
}