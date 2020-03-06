using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class RegionController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (DBPokedexContext db = new DBPokedexContext()) 
            {
                return View(db.Region.ToList());
            }              
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Region region)
        {
            if (ModelState.IsValid)
            {
                using (DBPokedexContext db = new DBPokedexContext())
                {
                    db.Region.Add(region);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Region");
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Region region)
        {
            if (ModelState.IsValid)
            {
                using (DBPokedexContext db = new DBPokedexContext())
                {
                    Region region1 = db.Region.Find(region.Id);
                    region1.Name = region.Name;
                    db.SaveChanges();

                    return RedirectToAction("Index", "Region");
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (DBPokedexContext db = new DBPokedexContext())
            {
                return View(db.Region.Find(id));
            }
        }

        [HttpPost]
        public IActionResult Delete(Region region)
        {
            using (DBPokedexContext db = new DBPokedexContext())
            {
                db.Region.Remove(region);
                db.SaveChanges();

                return RedirectToAction("Index", "Region");
            }
        }
    }
}