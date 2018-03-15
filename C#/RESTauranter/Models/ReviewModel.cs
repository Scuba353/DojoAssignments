using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class Review: BaseEntity {
        
        [Key]
        public int reviewid { get; set; }
        [Display(Name = "Reviewer Name")]
        public string reviewerName { get; set; }
        [Display(Name = "Restaurant Name")]
        public string restaurantName { get; set; }
        [MinLength(10)]
        [Display(Name = "Review")]
        public string review { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Date Visited")]
        public string datevisited { get; set; }

        [Display(Name = "Rating")]
        [Range(1,5)]
        public int rating { get; set; }

    }
}