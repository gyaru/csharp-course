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
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Cities.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateCityViewModel model = new CreateCityViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCityViewModel createCity)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index), "City");
            City city = new City
            {
                CityName = createCity.CityName
            };
            _context.Cities.Add(city);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "City");
        }
        
        public ActionResult Delete(int id)
        {
            City? cityToDelete = _context.Cities.FirstOrDefault(x => x.CityId == id);
            _context.Cities.Remove(cityToDelete);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "City");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            City city = _context.Cities.FirstOrDefault(x => x.CityId == id);

            if (city == null)
            {
                return RedirectToAction("Index");
            }

            CreateCityViewModel editCity = new CreateCityViewModel
            {
                CityName = city.CityName
            };

            return View(editCity);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateCityViewModel cityToEdit)
        {
            City city = _context.Cities.FirstOrDefault(x => x.CityId == id);
            if (!ModelState.IsValid) return View(cityToEdit);
            city.CityName = cityToEdit.CityName;

            _context.Entry(city).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}