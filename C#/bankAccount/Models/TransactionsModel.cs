using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankAccount.Models
{
    public class Transaction: BaseEntity {
        
        [Key]
        public int transactionid { get; set; }
    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string transactionDate { get; set; }

        public double amount { get; set; }

        //FK to the user table- one to many relationship (one user can have many transactions)
        
        public int userid { get; set; }
        public User User { get; set; }

    }
}