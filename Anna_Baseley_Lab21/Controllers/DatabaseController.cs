using Anna_Baseley_Lab21.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anna_Baseley_Lab21.Controllers
{
    public class DatabaseController : Controller
    {
        // GET: Database
        public ActionResult Index()
        {
            string userEmail = User.Identity.Name;
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            ViewBag.UserItems = ORM.Items.Where(x => x.Email == userEmail).ToList();

            return View();
        }
    }
}