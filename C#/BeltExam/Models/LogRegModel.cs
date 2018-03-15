using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltExam.Models
{
    public class User: BaseEntity {
        
        [Key]
        public int userid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // list of activities created by a user
        // [InverseProperty("Activity")]
        public List<Playit> activitiesIcreated { get; set; }

        //list of activities user is attending
        //[InverseProperty("User")]
        public List<UserActivities> myactivities { get; set; }

        public User(){
            myactivities= new List<UserActivities>();
            activitiesIcreated= new List<Playit>();
        }

    }
}