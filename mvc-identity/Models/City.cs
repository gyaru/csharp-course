using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_identity.Models
{
    public class City
    {
        [Key] public int CityId { get; set; }
        [Required] public string CityName { get; set; }
        
        [NotMapped]
        public List<Person> People { get; set; }
    }
}