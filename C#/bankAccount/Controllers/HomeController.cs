using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bankAccount.Models;
using Microsoft.AspNetCore.Http;

namespace bankAccount.Controllers
{
    public class HomeController : Controller
    {
        private BankContext _context;

        public HomeController(BankContext context){
            _context= context;
        }

        [HttpGet]
        [Route("")]
        //display registration page
        public IActionResult Registration()
        {
            return View("registration");
        }

        [HttpGet]
        [Route("loginpage")]
        //display login page
        public IActionResult Login()
        {

            return View("login");
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
                return View("registration", model);
            }
            else{
                ViewBag.userexist= "This email is already being used.";
                return View("registration", model);
            } 
            //redirect to account page in new controller on success      
        }

        [HttpPost]
        [Route("login")]
        //process login
        public IActionResult LoginUser(LogRegView model)
        {
            User ReturnedValue = _context.Users.SingleOrDefault(user => user.Email == model.Email);
            if(ReturnedValue == null){
                ViewBag.emaildoesnotexist="The email used does not exist, please register as a new user.";
                return View("login", model);
            }
            else{
                if(ReturnedValue.Password == model.Password){
                    HttpContext.Session.SetString("username", ReturnedValue.FirstName);
                    int id= ReturnedValue.userid;
                    return RedirectToAction("acctinfo", "AcctInfo", new {id= id});
                }
                else{
                    ViewBag.invalidpassword= "The password you entered does not match the email.";
                    return View("login", model);
                }
            }  
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
