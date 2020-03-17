using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class TypeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (DBPokedexContext db = new DBPokedexContext())
            {
                return View(db.Type.ToList());
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pokedex.Models.Type type)
        {
            if (ModelState.IsValid)
            {
                using (DBPokedexContext db = new DBPokedexContext())
                {
                    db.Add(type);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Type");
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
        public IActionResult Edit(Pokedex.Models.Type type)
        {
            if (ModelState.IsValid)
            {
                using (DBPokedexContext db = new DBPokedexContext())
                {
                    Pokedex.Models.Type Type2 = db.Type.Find(type.Id);
                    Type2.Name = type.Name;
                    db.SaveChanges();

                    return RedirectToAction("Index", "Type");
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
                return View(db.Type.Find(id));
            }
        }

        [HttpPost]
        public IActionResult Delete(Pokedex.Models.Type type)
        {
            using (DBPokedexContext db = new DBPokedexContext())
            {
                db.Type.Remove(type);
                db.SaveChanges();

                return RedirectToAction("Index", "Type");
            }
        }
    }
}