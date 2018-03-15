using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bankAccount.Models;
using bankAccount.Controllers;
using Microsoft.AspNetCore.Http;

namespace bankAccount.Controllers
{
    public class AcctInfoController : Controller
    {
        private BankContext _context;

        public AcctInfoController(BankContext context){
            _context= context;
        }

        [HttpGet]
        [Route("acctinfo/{id}")]
        //process login
        public IActionResult AcctInfo(int id)
        {
            System.Console.WriteLine(id);
            HttpContext.Session.SetInt32("id", id);
            TempData["username"]= HttpContext.Session.GetString("username");
            List<Transaction> alltransactions= _context.Transaction.Where(user => user.userid == id).ToList();
            //Could also use "allDAdollars" and  Pull from user and include the instanciated list

            var b= alltransactions.Sum(x=>x.amount);
            TempData["sum"]= b;

            return View("acctinfo", alltransactions);
        }

        [HttpPost]
        [Route("depositwithdraw")]
        public IActionResult DespositWithdraw(double amount){

            Transaction NewTransaction = new Transaction
            {
                amount = amount,
                userid= (int)HttpContext.Session.GetInt32("id"),
            };
            int id= (int)HttpContext.Session.GetInt32("id");
            _context.Transaction.Add(NewTransaction);
            _context.SaveChanges();
            return RedirectToAction("acctinfo", "AcctInfo", new {id= id});
            }
        }


    }
