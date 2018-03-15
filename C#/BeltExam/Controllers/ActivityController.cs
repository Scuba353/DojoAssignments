using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeltExam.Controllers
{
    public class ActivityController : Controller
    {
        private BeltExamContext _context;

        public ActivityController(BeltExamContext context){
            _context= context;
        }

        [HttpGet]
        [Route("allactivities")]
        public IActionResult Allactivities()
        {
            List<Playit> allgames= _context.Activities.Include(x => x.Coordinator).Include(p => p.Participants).ToList();
            ViewBag.allofthegames= allgames;
            ViewBag.user= (int)HttpContext.Session.GetInt32("userid");
            System.Console.WriteLine(ViewBag.user);

            return View("activitypage");
        }
        
        //DELETE if logged user == coordinator
        [HttpGet]
        [Route("deleteevent/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            List<UserActivities> Coordinator = _context.User_Activity_Join.Where(c =>c.activityid ==id).ToList();
            foreach( var c in Coordinator)
            {
                _context.User_Activity_Join.Remove(c);
            }

             Playit remove = _context.Activities.SingleOrDefault(b => b.activityid == id);
            _context.Activities.Remove(remove);
            _context.SaveChanges();  

            return RedirectToAction("Allactivities");
        }

        //LEAVE if user_activity relationship exist- Remove row from join table
            
        [HttpGet]
        [Route("leaveevent/{id}")]
        public IActionResult LeaveEvent(int id)
        {
            int Uid= (int)HttpContext.Session.GetInt32("userid");
            UserActivities leave =_context.User_Activity_Join.SingleOrDefault(j =>(j.userid ==Uid && j.activityid ==id));
            _context.User_Activity_Join.Remove(leave);
            _context.SaveChanges(); 

            return RedirectToAction("Allactivities");
        }

         //JOIN if no relationship exist in join table- Add row of userid-activityid
        [HttpGet]
        [Route("joinevent/{id}")]
        public IActionResult JoinEvent(int id)
        {
            UserActivities NewJoin = new UserActivities
            {
                userid = (int)HttpContext.Session.GetInt32("userid"),
                activityid = id,
              
            };
            _context.User_Activity_Join.Add(NewJoin);
            _context.SaveChanges(); 

            return RedirectToAction("Allactivities");
        }

        [HttpPost]
        [Route("addactivity")]
        public IActionResult AddActivity()
        {
            return View("create");
        }

        [HttpPost]
        [Route("createactivity")]
        public IActionResult CreateActivity(Playit model, string span)
        {
            if(ModelState.IsValid)
                {
                    Playit NewActivity = new Playit
                    {
                        activity = model.activity,
                        date = model.date,
                        time = model.time,
                        duration = model.duration + span, 
                        description= model.description,
                        userid= (int)HttpContext.Session.GetInt32("userid")
                    };
                    _context.Activities.Add(NewActivity);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("activityid", NewActivity.activityid);
                    int id= (int)HttpContext.Session.GetInt32("activityid");
                    return RedirectToAction("activitydescription", new {id= id});
                }
            return View("create", model);
        }

        [HttpGet]
        [Route("activitydescription/{id}")]
        public IActionResult activitydescription(int id)
        {
            int actid= id;
            var game= _context.Activities.Include(c => c.Coordinator).Include(p => p.Participants).ThenInclude(u => u.User).SingleOrDefault(x => x.activityid == actid);
            ViewBag.game= game;
            return View("description");
        
        }
    }
}







    
