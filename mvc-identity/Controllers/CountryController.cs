using mvc_identity.Models;
using mvc_identity.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using mvc_identity.Data;

namespace mvc_identity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Countries.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateCountryViewModel model = new CreateCountryViewModel();
           
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCountryViewModel createCountry)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");
            Country country = new Country
            {
                CountryName = createCountry.CountryName
            };
            _context.Countries.Add(country);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Country country = _context.Countries.FirstOrDefault(x => x.CountryId == id);

            if (country == null)
            {
                return RedirectToAction("Index");
            }

            CreateCountryViewModel editCountry = new CreateCountryViewModel
            {
                CountryName = country.CountryName                          
            };
         
            return View(editCountry);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateCountryViewModel countryToEdit)
        {
            Country country = _context.Countries.FirstOrDefault(x => x.CountryId == id);
            if (!ModelState.IsValid) return View(countryToEdit);
            country.CountryName = countryToEdit.CountryName;
            _context.Entry(country).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public ActionResult Delete(int id)
        {
            Country? countryToDelete = _context.Countries.FirstOrDefault(x => x.CountryId == id);
            _context.Countries.Remove(countryToDelete);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Country");
        }
    }
}


