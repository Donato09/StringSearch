using StringSearch.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace StringSearch.Services.Concrete
{
    public class StringManipulationService : IStringManipulationService
    {

        public List<string> GetWordsList(string stringToSplit)
        {
            List<string> wordList = new List<string>();

            wordList.AddRange(stringToSplit.Split(' ').ToList());

            return wordList;
        }

        public string GetMaxWord(List<string> WordsList)
        {

            int maxLength = WordsList.Max(str => str == null ? 0 : str.Length);

            var longestStrings = WordsList
                .Where(str => (str == null ? 0 : str.Length) == maxLength);

            return longestStrings.FirstOrDefault();
        }
    }
}
