using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quoteDojo.Models;
using quoteDojo.Connectors;

namespace quoteDojo.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();  
        }

        [HttpPost]
        [Route("add/quote")]
        public IActionResult AddQuote(string addedby, string quote)
        {
            System.Console.WriteLine("youre going the right direction");
            string query= $"INSERT INTO dBquoteDojo.quotes (addedby, quote, created_at) VALUES ('{addedby}', '{quote}', Now());";
            DbConnector.Execute(query);
            return RedirectToAction("Quotes");  
        }

        [HttpPost]
        [Route("skip")]
        public IActionResult Skip()
        {
            return RedirectToAction("Quotes");  
        }

        [HttpGet]
        [Route("quote")]
        public IActionResult Quotes()
        {
            string query= "SELECT * From dBquoteDojo.quotes ORDER BY created_at DESC;";
            var allquotes= DbConnector.Query(query);
            ViewBag.allquotes= allquotes;

            return View("about");
            }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
