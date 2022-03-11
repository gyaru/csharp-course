using System.ComponentModel.DataAnnotations;

namespace mvc_identity.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        [Required]
        [StringLength(69, MinimumLength = 1)]
        [Display(Name = "Name")]

        public string CountryName { get; set; }
    }
}