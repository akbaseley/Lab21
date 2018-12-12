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
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            ViewBag.ItemList = ORM.Items.ToList();

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

        public ActionResult AddUser(User newUser)
        {
            if (ModelState.IsValid)
            {
                CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
                ORM.Users.Add(newUser);
                ORM.SaveChanges();

                ViewBag.Message = $"Hello,{newUser.First_Name}!";
                return View("Confirm");
            }
            else
            {
                ViewBag.Message = "Oops! It looks as though something has gone wrong!";
                return View("Error");
            }
        }

        public ActionResult SearchByItemName(string item)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            ViewBag.ItemList = ORM.Items.Where(i=> i.Name.Contains(item)).ToList();

            return View("Index");
        }

        public ActionResult ItemAdmin()
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            ViewBag.ItemList = ORM.Items.ToList();

            return View();
        }

        public ActionResult DeleteItem(string Name)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            Item Found = ORM.Items.Find(Name);

            if(Found != null)
            {
                ORM.Items.Remove(Found);

                ORM.SaveChanges();

                return RedirectToAction("ItemAdmin");
            }
            else
            {
                ViewBag.ErrorMessage = "Item not found!";
                return View("Error");
            }
        }

        public ActionResult ShowItemDetails(string Name)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            Item Found = ORM.Items.Find(Name);

            if (Found != null)
            {
                return View(Found);
            }
            else
            {
                ViewBag.ErrorMessage = "The Item was not found";
                return View("Error");
            }
        }

        public ActionResult SaveItemUpdates(Item updatedItem)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            Item oldItem = ORM.Items.Find(updatedItem.Name);

            if(oldItem !=null && ModelState.IsValid)
            {
                oldItem.Description = updatedItem.Description;
                oldItem.Quantity = updatedItem.Quantity;
                oldItem.Price = updatedItem.Price;

                ORM.Entry(oldItem).State = System.Data.Entity.EntityState.Modified;

                ORM.SaveChanges();

                return RedirectToAction("ItemAdmin");
            }
            else
            {
                ViewBag.ErrorMessage = "Oops!  Something went wrong!";
                return View("Error");
            }
        }

        public ActionResult ItemForm()
        {
            return View();
        }

        public ActionResult AddNewItem(Item newItem)
        {
            if (ModelState.IsValid)
            {
                CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
                ORM.Items.Add(newItem);
                ORM.SaveChanges();

                return RedirectToAction("ItemAdmin");
            }
            else
            {
                ViewBag.ErrorMessage = "Oops! Something appears to have gone wrong!";
                return View("Error");
            }
        }
    }
}