using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace mvc_identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        // for admins we want firstname + lastname
        // for "people" we want just one name table
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required] public string BirthDate { get; set; }
    }
}