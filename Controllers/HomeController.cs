using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using chefs_dishes.Models;
using ProjName.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace chefs_dishes.Controllers
{
    public class HomeController : Controller
    {
        // NOTE DB function
        private chefs_dishesContext db;
        public HomeController(chefs_dishesContext context)
        {
            db = context;
        }


        // NOTE Chef routes
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = db.Chefs.Include(d => d.Dishes).OrderByDescending (d => d.CreatedAt).ToList();
            return View("Index", AllChefs);
        }


        [HttpGet("newchef")]
        public IActionResult NewChef()
        {
            return View("Newchef");
        }


        [HttpPost("createchef")]
        public IActionResult CreateChef(Chef createChef)
        {   
            if (ModelState.IsValid)
            {
                db.Add(createChef);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Newchef");
        }


        // NOTE Dish routes
        [HttpGet("viewdishes")]
        public IActionResult ViewDishes()
        {
            List<Dish> AllDishes = db.Dishes.OrderByDescending (d => d.CreatedAt).ToList();
            return View("Viewdishes", AllDishes);
        }


        [HttpGet("newdish")]
        public IActionResult NewDish()
        {
            ViewBag.AllChefs = db.Chefs.ToList();
            return View("Newdish");
        }


        [HttpPost("createdish")]
        public IActionResult CreateDish(Dish createDish)
        {
            if (ModelState.IsValid)
            {
                Chef creator = db.Chefs.FirstOrDefault(c => c.ChefId == createDish.ChefId);
                createDish.Creator = creator;
                createDish.ChefName = createDish.Creator.FirstName + " " + createDish.Creator.LastName;
                db.Add(createDish);
                db.SaveChanges();
                return RedirectToAction("Viewdishes");
            }
            ViewBag.AllChefs = db.Chefs.OrderByDescending (d => d.CreatedAt).ToList();
            return View("Newdish");
        }



        // NOTE pre installed things

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
