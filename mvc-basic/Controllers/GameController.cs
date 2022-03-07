using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using mvc_basic.Models;

namespace mvc_basic.Controllers
{
    public class GameController : Controller
    {
        public IActionResult GuessingGame()
        {
            const int guesses = 0;
            int random = GameModel.RandomNumber();
            // save to session
            HttpContext.Session.SetInt32("Guesses", guesses);
            HttpContext.Session.SetInt32("RandomNumber", random);
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int guess)
        {
            // get number from session
            int? random = HttpContext.Session.GetInt32("RandomNumber");
            // generate if null
            if (random == null)
            {
                HttpContext.Session.SetInt32("RandomNum", GameModel.RandomNumber());
            }

            // is it correct?
            bool result = GameModel.CompareGuess(guess, random);

            if (!result)
            {
                // get amount
                int? counter = HttpContext.Session.GetInt32("Guesses");
                // increase after each guess
                counter++;
                int updatedValue = counter.GetValueOrDefault();
                HttpContext.Session.SetInt32("Guesses", updatedValue);
                ViewBag.Guesses = updatedValue;
                // uh oh!
                ViewBag.Message = "That's not the correct number.";
            }
            else
            {
                ViewBag.Message = $"Correct guess!\nThe number was: {random}";
                // clearing session to generate a new one
                HttpContext.Session.Clear();
            }

            return View();
        }
    }
}