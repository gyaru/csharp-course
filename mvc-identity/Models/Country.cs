using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_identity.Models
{
    public class Country
    {
        [Key] public int CountryId { get; set; }
        [Required] public string CountryName { get; set; }
        
        [NotMapped]
        public List<Person> People { get; set; }
    }
}