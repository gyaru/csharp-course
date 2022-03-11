using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_identity.Models
{
    public class Person
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public List<PersonLanguage> Languages { get; set; }
        public string PhoneNumber { get; set; }
        [Required] [ForeignKey("City")] public int CurrentCityId { get; set; }
        public City City { get; set; }
        public DateTime Edited { get; set; }
        public DateTime Created { get; set; }
    }
}