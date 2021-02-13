using System;
using System.Collections.Generic;

namespace StringSearch.Models
{
    public class Sentence
    {
        public Sentence()
        {
        }

        public string SentencePhrase { get; set; }

        public List<string> WordsList { get; set; }

        public string WordMax { get; set; }
    }
}
