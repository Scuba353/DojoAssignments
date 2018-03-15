
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

 
namespace RandCodeGen.Controllers
{
    public class RandomController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            HttpContext.Session.SetString("Random", RandNum.GetRandomAlphaNumeric());
            string LocalVariable = HttpContext.Session.GetString("Random");
            ViewBag.num = LocalVariable;

            if(HttpContext.Session.GetInt32("counter")== null){
                HttpContext.Session.SetInt32("counter", 1);
                int? count= HttpContext.Session.GetInt32("counter");
                ViewBag.count= count;
                return View();
            }
            else{
                HttpContext.Session.SetInt32("counter", (int)(HttpContext.Session.GetInt32("counter")+1));
                int? count= HttpContext.Session.GetInt32("counter");
                ViewBag.count= count;
            }
            return View();
        }

        // public IActionResult Counter(){
        //     HttpContext.Session.SetInt32("counter", (int)(HttpContext.Session.GetInt32("counter")+1));

        //     return Redirect("index");
        // }
    
    }
}