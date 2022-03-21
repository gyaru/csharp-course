using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_identity.Data;
using System.Text.Json;
using mvc_identity.Models;
using mvc_identity.Models.ViewModels;

namespace mvc_identity.Controllers
{
    public class ReactController : Controller
    {
        private readonly ApplicationDbContext _context;


        public ReactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult All()
        {
            var data = _context.People.Include(c => c.City).Where(c => c.CurrentCityId == c.City.CityId).Include(c => c.Country).Where(c => c.CurrentCountryId == c.Country.CountryId).ToList();
            return Ok(data);
        }

        [HttpGet]
        public IActionResult Cities()
        {
            var data = _context.Cities.ToList();
            return Ok(data);
        }
        
        [HttpGet]
        public IActionResult Countries()
        {
            var data = _context.Countries.ToList();
            return Ok(data);
        }
        
        [HttpPost]
        public ActionResult Create(CreatePersonViewModel createPerson)
        {
            Person person = new Person()
            {
                Name = createPerson.Name,
                CurrentCityId = createPerson.CurrentCityId,
                CurrentCountryId = createPerson.CurrentCityId,
                PhoneNumber = createPerson.PhoneNumber
            };
            _context.People.Add(person);
            _context.SaveChanges();
            return Ok("Success");
        }
        
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Person? personToDelete = _context.People.FirstOrDefault(x => x.Id == id);
            _context.People.Remove(personToDelete);
            _context.SaveChanges();
            return Ok("Success");
        }
    }
}