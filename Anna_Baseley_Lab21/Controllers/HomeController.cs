using Anna_Baseley_Lab21.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anna_Baseley_Lab21.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult AddUser(UserInfo newUser)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = $"Hello,{newUser.FirstName}!";
                return View("Confirm");
            }
            else
            {
                ViewBag.Address = Request.UserHostAddress;
                return View("Error");
            }
        }
    }
}