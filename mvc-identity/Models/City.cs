using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc_identity.Models
{
    public class City
    {
        [Key] public int CityId { get; set; }
        [Required] public string CityName { get; set; }
        public List<Person> People { get; set; }
    }
}