using StringSearch.Models;
using StringSearch.Services.Abstract;
using System;
using Xunit;
using Moq;
using StringSearch.Services.Concrete;

namespace StringSearch.Tests
{
    public class StringManipulationServiceTest
    {
        //random sentences generator --> https://randomwordgenerator.com/sentence.php
        private static readonly string stringInput = "Too many prisons have become early coffins.";
        public Sentence sentenceInput;

        StringManipulationService _stringManipulationService = new StringManipulationService();

        [Fact]
        public void CheckStringTest()
        {
            sentenceInput = new Sentence
            {
                SentencePhrase = stringInput
            };

            Assert.True(sentenceInput.SentencePhrase.Length > 0);
        }

        [Fact]
        public void CheckWorldListTest()
        {
            sentenceInput = new Sentence
            {
                SentencePhrase = stringInput
            };

            sentenceInput.WordsList = _stringManipulationService.GetWordsList(sentenceInput.SentencePhrase);

            Assert.NotNull(stringInput);
            Assert.True(sentenceInput.WordsList.Count == 7);
        }

        [Fact]
        public void GetMaxWordTest()
        {
            sentenceInput = new Sentence
            {
                SentencePhrase = stringInput
            };

            sentenceInput.WordsList = _stringManipulationService.GetWordsList(sentenceInput.SentencePhrase);

            sentenceInput.WordMax = _stringManipulationService.GetMaxWord(sentenceInput.WordsList);

            Assert.NotNull(sentenceInput.WordMax);
            Assert.Equal("coffins.", sentenceInput.WordMax.ToLower());
        }
    }
}

