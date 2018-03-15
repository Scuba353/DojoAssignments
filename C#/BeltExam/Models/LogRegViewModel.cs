using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BeltExam.Models
{
    public class LogRegView: BaseEntity {
        
        [Required]
        [Display(Name = "First Name")]
        [MinLength(2, ErrorMessage = "Must be at least two characters long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name can only contain letters")]
        public string FirstName { get; set; }
       
        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2, ErrorMessage = "Must be at least two characters long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name can only contain letters")]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage= "Password must contain 1 uppercase letter, 1 lowercase letter, a special character and a number")]
        [MinLength(8)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}