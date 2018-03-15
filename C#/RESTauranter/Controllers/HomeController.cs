using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private ReviewContext _context;

        public HomeController(ReviewContext context){
            _context= context;
        }

       [HttpGet]
       [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("writereview")]
        public IActionResult WriteReview(Review model)
        {
            if(ModelState.IsValid)
            {
                Review NewReview = new Review
                {
                    reviewerName = model.reviewerName,
                    restaurantName = model.restaurantName,
                    review = model.review,
                    datevisited = model.datevisited,
                    rating= model.rating
                };
                _context.reviews.Add(NewReview);
                _context.SaveChanges();
                return RedirectToAction("AllReviews");
            }
            return View("index", model); 
        }

       [HttpGet]
       [Route("allreviews")]
        public IActionResult AllReviews()
        {
            ViewBag.allreviews= _context.reviews.ToList();
            return View("About");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
