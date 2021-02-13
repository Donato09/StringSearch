using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StringSearch.Models;
using StringSearch.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentenceController : ControllerBase
    {

        private readonly ILogger<SentenceController> _logger;
        private readonly IStringManipulationService _stringManipulationService;

        public SentenceController(ILogger<SentenceController> logger, IStringManipulationService stringManipulationService)
        {
            _logger = logger;
            _stringManipulationService = stringManipulationService;
        }

        [HttpGet]
        public IActionResult GetMaxWord(string string_sentence)
        {
            Sentence sentence = new Sentence
            {
                SentencePhrase = string_sentence,

                WordsList = _stringManipulationService.GetWordsList(string_sentence),
            };

            sentence.WordMax = _stringManipulationService.GetMaxWord(sentence.WordsList);

            return Ok(sentence);
        }
    }
}
