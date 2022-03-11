using System.ComponentModel.DataAnnotations;

namespace mvc_identity.Models.ViewModels
{
    public class CreateCityViewModel
    {
        [Required]
        [StringLength(69, MinimumLength = 1)]
        [Display(Name = "Name")]

        public string CityName { get; set; }
    }
}