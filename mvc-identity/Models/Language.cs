using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc_identity.Models
{
    public class Language
    {
        [Key] public int LanguageId { get; set; }
        
        [Display(Name = "Name")]
        [Required]
        [StringLength(80, MinimumLength = 1)]
        public string LanguageName { get; set; } = null!;

        public List<PersonLanguage> People { get; } = null!;
    }
}