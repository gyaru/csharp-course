using Microsoft.AspNetCore.Mvc;
using mvc_identity.Data;

namespace mvc_identity.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
