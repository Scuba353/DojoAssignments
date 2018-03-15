using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingPlanner.Models
{
    public class Wedding: BaseEntity {
        
        [Key]
        public int weddingid { get; set; }
        public string wedder1 { get; set; }
        public string wedder2 { get; set; }
        public string date { get; set; }
        public string address { get; set; }
        public int userid { get; set; }

       [InverseProperty("userid")]
        public User creator { get; set; }

        public List<User> guests { get; set; }
 
        public User()
        {
            guests = new List<User>();
        }
    }
}