using System.ComponentModel.DataAnnotations;

namespace mvc_identity.Models.ViewModels
{
    public class CreateLanguageViewModel
    {
        [Required]
        [StringLength(69, MinimumLength = 1)]
        [Display(Name = "Name")]

        public string LanguageName { get; set; }
    }
}