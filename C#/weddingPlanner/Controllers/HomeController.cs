using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using weddingPlanner.Models;
using Microsoft.AspNetCore.Http;

namespace weddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private weddingContext _context;

        public HomeController(weddingContext context){
            _context= context;
        }

        [HttpGet]
        [Route("")]
        //display registration page
        public IActionResult Index()
        {
            return View("index");
        }



        [HttpPost]
        [Route("register")]
        //process registration
        public IActionResult RegisterNewUser(LogRegView model)
        {
            User ReturnedValue = _context.Users.SingleOrDefault(user => user.Email == model.Email);
            if(ReturnedValue == null){
                if(ModelState.IsValid)
                {
                    User NewUser = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = model.Password
                    };
                    _context.Users.Add(NewUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetString("username", NewUser.FirstName);
                    int id = NewUser.userid;
                    return RedirectToAction("acctinfo", "AcctInfo", new {id= id});
                }
                return View("index", model);
            }
            else{
                ViewBag.userexist= "This email is already being used.";
                return View("index", model);
            } 
            //redirect to account page in new controller on success      
        }

        [HttpPost]
        [Route("login")]
        //process login
        public IActionResult LoginUser(string Email, string Password)
        {
            User ReturnedValue = _context.Users.SingleOrDefault(user => user.Email == Email);
            if(ReturnedValue == null){
                ViewBag.emaildoesnotexist="The email used does not exist, please register as a new user.";
                return View("index");
            }
            else{
                if(ReturnedValue.Password == Password){
                    HttpContext.Session.SetString("username", ReturnedValue.FirstName);
                    int id= ReturnedValue.userid;
                    return RedirectToAction("acctinfo", "AcctInfo", new {id= id});
                }
                else{
                    ViewBag.invalidpassword= "The password you entered does not match the email.";
                    return View("index");
                }
            }  
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
