using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using formSubmission.Models;

namespace formSubmission.Controllers
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
        [Route("postdata")]
        public IActionResult Submit(string FirstName, string LastName, int Age, string Email, string Password)
        {
            User NewUser = new User
            {
                FirstName = FirstName,
                LastName= LastName,
                Age= Age,
                Email = Email,
                Password = Password
            };
            TryValidateModel(NewUser);
            ViewBag.errors = ModelState.Values;
            ViewBag.success= ("Yay it worked");
            ViewBag.fail= ("You messed up, Try again");
            return View("about");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
