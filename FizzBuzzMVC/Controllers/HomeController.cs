using FizzBuzzMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FizzBuzzMVC.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FBPage()
        {
            FizzBuzz fizzBuzz = new FizzBuzz()
            {
                FizzValue = 3,
                BuzzValue = 5
            };
            

            return View(fizzBuzz);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult FBPage(FizzBuzz fizzBuzz)
        {
            List<string> fbItems = new List<string>();

            bool fizz;
            bool buzz;
            int startValue = 1;
            int endValue = 100;
            

            for (int i = startValue; i <= endValue; i++)
            {
                fizz = (i % fizzBuzz.FizzValue == 0);
                buzz = (i % fizzBuzz.BuzzValue == 0);

                if (fizz && buzz)
                {
                    fbItems.Add("FizzBuzz");
                }
                else if (fizz)
                {
                    fbItems.Add("Fizz");
                }
                else if(buzz)
                {
                    fbItems.Add("Buzz");
                }
                else
                {
                    fbItems.Add(i.ToString());
                }
            }

            fizzBuzz.Results = fbItems;

            return View(fizzBuzz);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}