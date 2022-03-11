using mvc_identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace mvc_identity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult AddUserToRole()
        {
            ViewData["Roles"] = new SelectList(_roleManager.Roles, "Name", "Name");
            ViewData["Users"] = new SelectList(_userManager.Users, "Id", "UserName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(string role, string user)
        {
            ApplicationUser? applicationUser = await _userManager.FindByIdAsync(user);

            IdentityResult result = await _userManager.AddToRoleAsync(applicationUser, role);
            if (result.Succeeded)
                return RedirectToAction("Index");

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!ModelState.IsValid) return View();
            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
            if (result.Succeeded)
                return RedirectToAction("Index");
            return View();
        }
    }
}