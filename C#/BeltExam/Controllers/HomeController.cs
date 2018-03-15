using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;
using Microsoft.AspNetCore.Http;


namespace BeltExam.Controllers
{
    public class HomeController : Controller
    {
        private BeltExamContext _context;

        public HomeController(BeltExamContext context){
            _context= context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(LogRegView model)
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
                    HttpContext.Session.SetInt32("userid", NewUser.userid);
                    return RedirectToAction("allactivities", "Activity");
                }
                return View("index", model);
            }
            else{   
                ViewBag.userexist= "This email is already being used.";
                return View("index", model);
            } 
        }


        [HttpPost]
        [Route("login")]
                public IActionResult LoginUser(string Email, string Password)
        {
            var ReturnedValue = _context.Users.SingleOrDefault(user => user.Email == Email);
            if(ReturnedValue == null){
                ViewBag.emaildoesnotexist="The email used does not exist, please register as a new user.";
                return View("index");
            }
            else{
                if(ReturnedValue.Password == Password){
                    HttpContext.Session.SetString("username", ReturnedValue.FirstName);
                    HttpContext.Session.SetInt32("userid", ReturnedValue.userid);
                    int id= ReturnedValue.userid;
                    return RedirectToAction("allactivities", "Activity", new {id= id});
                }
                else{
                    ViewBag.invalidpassword= "The password you entered does not match the email.";
                    return View("index");
                }
            }
        }   
        
    }
}
