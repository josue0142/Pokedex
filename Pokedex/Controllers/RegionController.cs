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

                var regions = db.Region.ToList();

                foreach (var item in regions)
                {
                    switch (item.Name)
                    {
                        case "katto":
                            item.color = "table-danger";
                            break;
                        case "johto":
                            item.color = "table-primary";
                            break;
                        case "hoenn":
                            item.color = "table-warning";
                            break;
                        case "orre":
                            item.color = "table-success";
                            break;
                        case "sinnoh":
                            item.color = "table-info";
                            break;
                        default:
                            item.color = "table-dark";
                            break;
                    }
                }

                return View(regions);
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
                    region.Name = region.Name.ToLower();
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
                    region1.Name = region.Name.ToLower();
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