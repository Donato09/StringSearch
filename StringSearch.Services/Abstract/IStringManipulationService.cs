using System.Collections.Generic;

namespace StringSearch.Services.Abstract
{
    public interface IStringManipulationService
    {
        List<string> GetWordsList(string stringToSplit);

        string GetMaxWord(List<string> words);
    }
}
