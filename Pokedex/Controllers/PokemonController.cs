using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (DBPokedexContext db = new DBPokedexContext())
            {
                var pokemon = db.Pokemon.Include(region => region.RegionFkNavigation).Include(type => type.TypeFkNavigation).ToList();

                foreach (var item in pokemon)
                {
                    switch (item.RegionFkNavigation.Name)
                    {
                        case "katto":
                            item.RegionFkNavigation.color = "table-danger";
                            break;
                        case "johto":
                            item.RegionFkNavigation.color = "table-primary";
                            break;
                        case "hoenn":
                            item.RegionFkNavigation.color = "table-warning";
                            break;
                        case "orre":
                            item.RegionFkNavigation.color = "table-success";
                            break;
                        case "sinnoh":
                            item.RegionFkNavigation.color = "table-info";
                            break;
                        default:
                            item.RegionFkNavigation.color = "table-dark";
                            break;
                    }
                }

                return View(pokemon);
            }          
        }

        [HttpGet]
        public IActionResult Create()
        {
            /*cargar Regiones*/

            using (DBPokedexContext db = new DBPokedexContext())
            {
                ViewBag.Regiones = db.Region.ToList();
            }

            /*cargar Tipos */

            using (DBPokedexContext db = new DBPokedexContext())
            {
                ViewBag.Tipos = db.Type.ToList();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                using (DBPokedexContext db = new DBPokedexContext())
                {
                    pokemon.Name = pokemon.Name.ToLower();
                    db.Pokemon.Add(pokemon);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Pokemon");
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
            using (DBPokedexContext db = new DBPokedexContext())
            {

                var pokemon = db.Pokemon.Find(id);

                /*Cargar regiones*/
                ViewBag.Regiones = db.Region.ToList();

                var currentRegion = db.Region.Where(a => a.Id == pokemon.RegionFk).FirstOrDefault();
                ViewBag.CurrentRegionNameId = currentRegion.Id;
                ViewBag.CurrentRegionName = currentRegion.Name;

                /*Cargar tipos*/
                ViewBag.Tipos = db.Type.ToList();

                var currentType = db.Type.Where(a => a.Id == pokemon.TypeFk).FirstOrDefault();
                ViewBag.CurrentTypeNameId = currentType.Id;
                ViewBag.CurrentTypeName = currentType.Name;

                /*Cargar poderes*/
                ViewBag.CurrentPowers = pokemon.Powers;

                /*Cargar nombre*/
                ViewBag.CurrentName = pokemon.Name;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                using (DBPokedexContext db = new DBPokedexContext())
                {
                    Pokemon pokemon1 = db.Pokemon.Find(pokemon.Id);
                    pokemon1.Name = pokemon.Name.ToLower();
                    pokemon1.RegionFk = pokemon.RegionFk;
                    pokemon1.TypeFk = pokemon.TypeFk;
                    pokemon1.Powers = pokemon.Powers;
                    db.SaveChanges();

                    return RedirectToAction("Index", "Pokemon");
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
                return View(db.Pokemon.Where(a => a.Id == id).Include(region => region.RegionFkNavigation
                ).Include(type => type.TypeFkNavigation).FirstOrDefault());
            }
        }

        [HttpPost]
        public IActionResult Delete(Pokemon pokemon)
        {
            using (DBPokedexContext db = new DBPokedexContext())
            {
                db.Pokemon.Remove(pokemon);
                db.SaveChanges();

                return RedirectToAction("Index", "Pokemon");
            }
        }
    }
}