using System;
using System.ComponentModel.DataAnnotations;

namespace formSubmission.Models
{
    public abstract class BaseEntity {}

    public class User : BaseEntity
    {
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
        [Range(0, 200)]
        public int Age { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(4)]
        public string Password { get; set; }
    }
}