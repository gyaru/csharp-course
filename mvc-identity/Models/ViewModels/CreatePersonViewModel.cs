using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc_identity.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(69, MinimumLength = 1)]
        [Display(Name = "Name")]

        public string Name { get; set; }

        [Required] [Display(Name = "City")] public int CurrentCityId { get; set; }
        
        [Display(Name = "Country")] public int CurrentCountryId { get; set; }

        public string PhoneNumber { get; set; }

        public List<City> Cities { get; set; }

        public List<PersonLanguage> Languages { get; set; }
    }
}