using System.ComponentModel.DataAnnotations;

namespace mvc_identity.Models
{
    public class Country
    {
        [Key] public int CountryId { get; set; }
        [Required] public string CountryName { get; set; }
    }
}