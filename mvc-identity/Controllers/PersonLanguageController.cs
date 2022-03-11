using mvc_identity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using mvc_identity.Data;

namespace mvc_identity.Controllers
{
    public class PersonLanguageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonLanguageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.PersonLanguages
                .Include(p => p.Person).Where(p => p.PersonId == p.Person.Id)
                .Include(l => l.Language).Where(l => l.LanguageId == l.Language.LanguageId)
                .ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["LanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageName");
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(PersonLanguage personLanguage)
        {
            _context.PersonLanguages.Add(personLanguage);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "PersonLanguage");
        }

        public ActionResult Delete(int id)
        {
            PersonLanguage? languageToDelete = _context.PersonLanguages.FirstOrDefault(pl => pl.PersonId == id);
            _context.PersonLanguages.Remove(languageToDelete);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "PersonLanguage");
        }
    }
}