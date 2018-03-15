using System.ComponentModel.DataAnnotations;

namespace weddingPlanner.Models
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
        [MinLength(4)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}