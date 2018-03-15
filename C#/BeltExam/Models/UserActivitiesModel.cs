using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltExam.Models
{
    public class UserActivities: BaseEntity {
        
        [Key]
        public int useractivityid { get; set; }
        public int userid { get; set; }
        
        [ForeignKey("userid")]
        public User User { get; set; }
        public int activityid { get; set; }
        
        [ForeignKey("activityid")]
        public Playit Activity { get; set; }
        

    }
}