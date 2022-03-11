using mvc_identity.Models;
using mvc_identity.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using mvc_identity.Data;

namespace mvc_identity.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Languages.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateLanguageViewModel model = new CreateLanguageViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLanguageViewModel createLanguage)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index), "Language");
            Language language = new Language()
            {
                LanguageName = createLanguage.LanguageName
            };
            _context.Languages.Add(language);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Language");
        }
        
        public ActionResult Delete(int id)
        {
            Language? languageToDelete = _context.Languages.FirstOrDefault(x => x.LanguageId == id);
            if (languageToDelete == null) return RedirectToAction(nameof(Index), "Language");
            _context.Languages.Remove(languageToDelete);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Language");
        }
    }
}
