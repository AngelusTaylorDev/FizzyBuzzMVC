using FizzyBuzzMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace FizzyBuzzMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Getting the information needed.
        [HttpGet]
        public IActionResult App()
        {
            // Create the model
            FuzzyBuzz model = new();

            //Set Fuzzy default Value
            model.FuzzyValue = 3;

            //Set Buzz default Value
            model.BuzzValue = 5;

            //Return the model to the view
            return View(model);
        }

        // Setting up the post recieved Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult App(FuzzyBuzz fuzzyBuzz)
        {
            // Instancate the Result list of strings
            List<string> fbItems = new();

            // Set the bools for the Fuzzy and Buzz values
            bool fuzzy;
            bool buzz;

            // Loop through the list of numbers from 1 to 100
            for (int i = 1; i <= 100; i++)
            {
                // Check to see if the Fuzzy and Buzz values are Fuzzy, Buzz, or FuzzyBuzz
                fuzzy = (i % fuzzyBuzz.FuzzyValue == 0);
                buzz = (i % fuzzyBuzz.BuzzValue == 0);

                // Conditional loot to set the algo flow
                if (fuzzy == true && buzz == true)
                {
                    fbItems.Add("FuzzyBuzz");
                }
                else if (fuzzy == true)
                {
                    fbItems.Add("Fuzzy");
                }
                else if (buzz == true)
                {
                    fbItems.Add("Buzz");
                }
                else
                {
                    fbItems.Add(i.ToString());
                }
            }
            // set all the numbers and strings in fbItems to the result
            fuzzyBuzz.Result = fbItems;

            return View(fuzzyBuzz);
        }

        public IActionResult TheCode()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
