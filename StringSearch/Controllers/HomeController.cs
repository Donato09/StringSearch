using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StringSearch.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using StringSearch.Models;

namespace StringSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringManipulationService _stringManipulationService;

        public HomeController(ILogger<HomeController> logger, IStringManipulationService stringManipulationService)
        {
            _logger = logger;
            _stringManipulationService = stringManipulationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MaxWord(string inputSentence)
        {
            //assume string will not be empty.
            Sentence sentence = new Sentence
            {
                SentencePhrase = inputSentence,

                WordsList = _stringManipulationService.GetWordsList(inputSentence),
            };

            sentence.WordMax = _stringManipulationService.GetMaxWord(sentence.WordsList);

            return PartialView("_MaxWordPartial", sentence);
        }

        public IActionResult Privacy()
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
