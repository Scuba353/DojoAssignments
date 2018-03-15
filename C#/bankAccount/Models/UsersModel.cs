using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bankAccount.Models
{
    public class User: BaseEntity {
        
        [Key]
        public int userid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Transaction> allDAdollars { get; set; }
 
        public User()
        {
            allDAdollars = new List<Transaction>();
        }
    }
}