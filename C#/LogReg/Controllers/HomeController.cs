using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogReg.Models;

namespace LogReg.Controllers
{
    public class HomeController : Controller
    {
        private LogRegContext _context;

        public HomeController(LogRegContext context){
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
                    return RedirectToAction("About");
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
        public IActionResult Login(LogRegView model){
            User ReturnedValue = _context.Users.SingleOrDefault(user => user.Email == model.Email);
            if(ReturnedValue == null){
                ViewBag.emaildoesnotexist="The email used does not exist, please register as a new user.";
                return View("index", model);
            }
            else{
                if(ReturnedValue.Password == model.Password){
                    return RedirectToAction("About");
                }
                else{
                    ViewBag.invalidpassword= "The password you entered does not match the email.";
                    return View("index");
                }
            }  
        }
        

        [HttpGet]
        [Route("success")]
        public IActionResult About()
        {
            return View();
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
