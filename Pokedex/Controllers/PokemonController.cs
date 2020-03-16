using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult Index()
        {
            using (DBPokedexContext db = new DBPokedexContext())
            {
                return View(db.Pokemon.ToList());
            }          
        }
    }
}