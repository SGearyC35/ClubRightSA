using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
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
            int? val = HttpContext.Session.GetInt32("ButtonVal");
            ViewBag.ButtonVal = val ?? 0;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ButtonCounterPage()
        {
            int? val = HttpContext.Session.GetInt32("ButtonVal");
            ViewBag.ButtonVal = val ?? 0;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public JsonResult IncrementButton()
        {
            int currentVal = HttpContext.Session.GetInt32("ButtonVal") ?? 0;
            currentVal++;
            HttpContext.Session.SetInt32("ButtonVal", currentVal);

            return Json(new { value = currentVal });
        }

        [HttpPost]
        public JsonResult ChangeText(string textToChange, int butID)
        {
            if (String.IsNullOrWhiteSpace(textToChange))
            {
                return Json(new { value = "No Text Entered" });
            }

            var RetVal = "";
            if (butID == 0)
            {
                //Reverse Literally

                var reversedChars = textToChange.ToCharArray().Reverse();

                RetVal = new string(reversedChars.ToArray());

            }
            else
            {
                //Reverse Words

                if (textToChange.Count(a => a == ' ') == 0)
                {
                    RetVal = textToChange;
                } else
                {
                    var SplitWords = textToChange.Split(' ').Reverse();
                    RetVal = string.Join(" ", SplitWords);
                }
            }

            return Json(new { value = RetVal });
        }

    }
}
