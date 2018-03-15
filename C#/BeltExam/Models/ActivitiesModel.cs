using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltExam.Models
{
    public class Playit: BaseEntity {
        
        [Key]
        public int activityid { get; set; }
        [MinLength(2)]
        public string activity { get; set; }
        
        [FutureDate(ErrorMessage="Date should be in the future.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM}")]
        public DateTime date { get; set; }

        [DataType(DataType.Time)]
        public string time { get; set; }
        public string duration { get; set; }
        
        [MinLength(2)]
        public string description { get; set; }
        public int userid { get; set; }
       
       [ForeignKey ("userid")]
        public User Coordinator { get; set; }

        [InverseProperty("Activity")]
        public List<UserActivities> Participants { get; set; }

        public Playit(){
            Participants= new List<UserActivities>();
        }

    }
}