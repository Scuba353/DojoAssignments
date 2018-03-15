using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pokiInfo.Models;

namespace pokiInfo.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        [Route("{pokeid}")]
        public IActionResult QueryPoke(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
                {
                    PokeInfo = ApiResponse;
                }
            ).Wait();
            System.Console.WriteLine(PokeInfo["name"]);
            System.Console.WriteLine(PokeInfo["height"]);
            System.Console.WriteLine(PokeInfo["weight"]);
            TempData["name"]= PokeInfo["name"];
            TempData["height"]= PokeInfo["height"];
            TempData["weight"]= PokeInfo["weight"];
            ViewBag.name=TempData["name"];
            ViewBag.height=TempData["height"];
            ViewBag.weight=TempData["weight"];
           return View("index");
        }




        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
