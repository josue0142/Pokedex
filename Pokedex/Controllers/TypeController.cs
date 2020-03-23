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
                var type = db.Type.ToList();

                foreach (var item in type)
                {
                    switch (item.Name)
                    {
                        case "normal":
                            item.color = "#ffb74d";
                            break;
                        case "fuego":
                            item.color = "#ff6d00";
                            break;
                        case "agua":
                            item.color = "#01579b";
                            break;
                        case "planta":
                            item.color = "#00b887";
                            break;
                        case "electrico":
                            item.color = "#ffea00";
                            break;
                        case "hielo":
                            item.color = "#00e5ff";
                            break;
                        case "lucha":
                            item.color = "#d32f2f";
                            break;
                        case "veneno":
                            item.color = "#6200ea";
                            break;
                        case "tierra":
                            item.color = "#6d4c41";
                            break;
                        case "volador":
                            item.color = "#bbdefb";
                            break;
                        case "psiquico":
                            item.color = "#7e57c2";
                            break;
                        case "insecto":
                            item.color = "#9e9d24";
                            break;
                        case "bicho":
                            item.color = "#9e9d24";
                            break;
                        case "roca":
                            item.color = "grey";
                            break;
                        case "fantasma":
                            item.color = "#5e35b1";
                            break;
                        case "dragon":
                            item.color = "#2e7d32";
                            break;
                        case "siniestro":
                            item.color = "#558b2f";
                            break;
                        case "acero":
                            item.color = "#e0e0e0";
                            break;
                        case "hada":
                            item.color = "#f48fb1";
                            break;
                        default:
                            item.color = "table-dark";
                            break;
                    }
                }

                return View(type);
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
                    type.Name = type.Name.ToLower();
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
                    Type2.Name = type.Name.ToLower();
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