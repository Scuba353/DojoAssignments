using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Dojodachi.Controllers
{
    public class DojodachiController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            Dojodachi player= new Dojodachi();

                HttpContext.Session.SetInt32("fullness", player.fullness);
                int? full = HttpContext.Session.GetInt32("fullness");
                ViewBag.fullness = full;
                TempData["fullness"]= full;

                HttpContext.Session.SetInt32("happiness", player.happiness);
                int? happy = HttpContext.Session.GetInt32("happiness");
                ViewBag.happiness = happy;
                TempData["happiness"]= happy;

                HttpContext.Session.SetInt32("energy", player.energy);
                int? zippy = HttpContext.Session.GetInt32("energy");
                ViewBag.energy = zippy; 
                TempData["energy"]= zippy;   
            
                HttpContext.Session.SetInt32("meals", player.meals);
                int? foods = HttpContext.Session.GetInt32("meals");
                ViewBag.meals = foods;
                TempData["meals"]= foods;
           
            return View("index");
        }
    
        [HttpPost]
        [Route("feed")]
        public IActionResult Feed()
        {
            int currenergy= (int)(HttpContext.Session.GetInt32("energy"));
            TempData["energy"]= currenergy;
            int currhappiness= (int)(HttpContext.Session.GetInt32("happiness"));
            TempData["happiness"]= currhappiness;

            int doihavefood= (int)(HttpContext.Session.GetInt32("meals"));
            if(doihavefood == 0){
                TempData["noFood"] = "You starve, you have no food!";
            }
            else{
                int yum = (int)(HttpContext.Session.GetInt32("meals")-1);
                HttpContext.Session.SetInt32("meals", yum);
                TempData["meals"]= yum;

                if(HttpContext.Session.GetInt32("fullness") != null){
                    Random rand = new Random();
                    if(rand.Next(1,100)<=25){
                        int full = (int)(HttpContext.Session.GetInt32("fullness")-1);
                        HttpContext.Session.SetInt32("fullness", full);
                        TempData["fullness"]= full;
                    }
                    else{
                        int full= (int)(HttpContext.Session.GetInt32("fullness") + rand.Next(5, 10));
                        HttpContext.Session.SetInt32("fullness",full );
                        TempData["fullness"]= full;
                    }
                }  
                else{
                    HttpContext.Session.SetInt32("fullness", 0 );
                }
            }
            return RedirectToAction("result");
        } 

        [HttpPost]
        [Route("play")]
        public IActionResult Play(){
            int currmeals= (int)(HttpContext.Session.GetInt32("meals"));
            TempData["meals"]= currmeals;
            int currfullness= (int)(HttpContext.Session.GetInt32("fullness"));
            TempData["fullness"]= currfullness;

            int doihaveenergy= (int)(HttpContext.Session.GetInt32("energy"));
            if(doihaveenergy == 0){
                TempData["noEnergy"] = "You are lazy, you have no energy!";
            }

            else{
                int zapp = (int)(HttpContext.Session.GetInt32("energy")-5);
                HttpContext.Session.SetInt32("energy", zapp);
                TempData["energy"]= zapp;

                if(HttpContext.Session.GetInt32("happiness") != null){
                    Random rand = new Random();
                    if(rand.Next(1,100)<=25){
                        int happs = (int)(HttpContext.Session.GetInt32("happiness")-1);
                        HttpContext.Session.SetInt32("happiness", happs);
                        TempData["happiness"]= happs;
                    }
                    else{
                        int happs= (int)(HttpContext.Session.GetInt32("happiness") + rand.Next(5, 10));
                        HttpContext.Session.SetInt32("happiness",happs );
                        TempData["happiness"]= happs;
                    }
                }  
                else{
                    HttpContext.Session.SetInt32("happiness", 0 );
                }
            }

            return RedirectToAction("result");
        } 

        [HttpPost]
        [Route("work")]
        public IActionResult Work(){
            int currfullness= (int)(HttpContext.Session.GetInt32("fullness"));
            TempData["fullness"]= currfullness;
            int currhappiness= (int)(HttpContext.Session.GetInt32("happiness"));
            TempData["happiness"]= currhappiness; 

            int doihaveenergy= (int)(HttpContext.Session.GetInt32("energy"));
            if(doihaveenergy == 0){
                TempData["noEnergy"] = "You are lazy, you have no energy!";
            }

            else{
                int zapp = (int)(HttpContext.Session.GetInt32("energy")-5);
                HttpContext.Session.SetInt32("energy", zapp);
                TempData["energy"]= zapp;
            
                if(HttpContext.Session.GetInt32("meals") != null){
                    Random rand = new Random();
                        int foods= (int)(HttpContext.Session.GetInt32("meals") + rand.Next(1, 3));
                        HttpContext.Session.SetInt32("meals",foods );
                        TempData["meals"]= foods;
                    }
                else{
                    HttpContext.Session.SetInt32("meals", 0 );
                }
            }
            return RedirectToAction("result");
        } 
        
        [HttpPost]
        [Route("sleep")]
        public IActionResult Sleep(){
            int currmeals= (int)(HttpContext.Session.GetInt32("meals"));
            TempData["meals"]= currmeals;

            int zapp = (int)(HttpContext.Session.GetInt32("energy")+15);
            HttpContext.Session.SetInt32("energy", zapp);
            TempData["energy"]= zapp;

            int foods = (int)(HttpContext.Session.GetInt32("fullness")-5);
            HttpContext.Session.SetInt32("fullness", foods);
            TempData["fullness"]= foods;   

            int smiles = (int)(HttpContext.Session.GetInt32("happiness")-5);
            HttpContext.Session.SetInt32("happiness", smiles);
            TempData["happiness"]= smiles;      

            return RedirectToAction("result");

        }

        [HttpGet]
        [Route("result")]
        public IActionResult Result()
        {
            if((int)(TempData["fullness"])<=0 && (int)(TempData["happiness"])<=0){
                TempData["loser"]= "You killed your dude";
                ViewBag.loser= TempData["loser"];
            }
            if((int)(TempData["fullness"])>100 && (int)(TempData["happiness"])>100 && (int)(TempData["energy"])>100){
                TempData["winner"]= "You are a good Dojogochi parent";
                ViewBag.winner= TempData["winner"];
            }
            ViewBag.noEnergy= TempData["noEnergy"];
            ViewBag.noFood= TempData["noFood"];

            ViewBag.energy= TempData["energy"];
            ViewBag.meals= TempData["meals"];
            ViewBag.fullness= TempData["fullness"];
            ViewBag.happiness= TempData["happiness"];
            
        return View("result");
        }

    }
}