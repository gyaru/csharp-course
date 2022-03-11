using mvc_identity.Models;
using mvc_identity.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using mvc_identity.Data;

namespace mvc_identity.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.People.Include(c => c.City).Where(c => c.CurrentCityId == c.City.CityId).ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreatePersonViewModel model = new CreatePersonViewModel();
            model.Cities = _context.Cities.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePersonViewModel createPerson)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person()
                {
                    Name = createPerson.Name,
                    CurrentCityId = createPerson.CurrentCityId,
                    PhoneNumber = createPerson.PhoneNumber
                };
                _context.People.Add(person);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            return View("Details", _context.People.Find(id));
        }

        public async Task<IActionResult> Search(string text)
        {
            var persons = from p in _context.People
                select p;
            persons = persons.Include(c => c.City).Where(c => c.CurrentCityId == c.City.CityId);
            if (!string.IsNullOrEmpty(text))
            {
                persons = persons.Where(s => s.Name!.Contains(text));
            }

            return View("Index", await persons.ToListAsync());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            // TODO: this could be null
            Person person = _context.People.FirstOrDefault(x => x.Id == id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            CreatePersonViewModel editPerson = new CreatePersonViewModel
            {
                Name = person.Name,
                CurrentCityId = person.CurrentCityId,
                PhoneNumber = person.PhoneNumber,
                Cities = _context.Cities.ToList()
            };
            ViewBag.Id = id;
            return View(editPerson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreatePersonViewModel personToEdit)
        {
            // TODO: this could be null
            Person person = _context.People.FirstOrDefault(x => x.Id == id);
            if (ModelState.IsValid)
            {
                // TODO: this could be null
                person.Name = personToEdit.Name;
                person.CurrentCityId = personToEdit.CurrentCityId;
                person.PhoneNumber = personToEdit.PhoneNumber;

                _context.Entry(person).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            personToEdit.Cities = _context.Cities.ToList();
            ViewBag.Id = id;
            return View(personToEdit);
        }

        public ActionResult Delete(int id)
        {
            Person? personToDelete = _context.People.FirstOrDefault(x => x.Id == id);
            _context.People.Remove(personToDelete);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "People");
        }
    }
}