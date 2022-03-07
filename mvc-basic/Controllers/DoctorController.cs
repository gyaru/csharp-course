using Microsoft.AspNetCore.Mvc;
using mvc_basic.Models;

namespace mvc_basic.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult FeverCheck()
        {
            return View();
        }


        [HttpPost]
        public IActionResult FeverCheck(string temp, string unit)
        {
            ViewBag.Message = DoctorModel.FeverCheck(temp, unit);
            return View();
        }
    }
}