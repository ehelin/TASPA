using System;
using System.Collections.Generic;
using System.IO;
using BLL;
using DAL;
using System.Linq;
using Newtonsoft.Json;
using Shared.Dto;
using Shared.Interfaces;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace IntegrationTests
{
    public class BllTests
    {
        private readonly ITaspaService bllService;
        private readonly string parentJsonPath;

        public BllTests()
        {
            ITaspaData dataLayer = new TaspaData();
            this.bllService = new TaspaService(dataLayer);

            // TODO - get path dyanmically
            this.parentJsonPath = "C:\\EricDocuments\\Personal\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\";
        }

        #region Search 

        // NOTE: Sanity test...needs to be expanded
        [Theory]
        [InlineData("abrazar", true)]                   //expected Spanish to be found
        [InlineData("to lose weight", true)]            //expected English to be found
        [InlineData("blah", false)]                     //expected Spanish not to be found
        [InlineData("blah2", false)]                    //expected English not to be found
        public void ExpectedSearchResult(string spanishTerm, bool expectedToBeFound)
        {
            var matches = this.bllService.Search(spanishTerm);
            Assert.Equal(expectedToBeFound, matches.Count > 0);
        }

        [Fact]
        public void VerifyAllSearchTermsVerbsHaveCorrespondingJsonFile()
        {
            var listToSearch = this.bllService.GetSearchList();

            // TODO - update the test to verify the jsonpath as well

            var spanishTerms = listToSearch.Select(x => x.Name).ToList();
            VerifyTerms(spanishTerms, this.parentJsonPath);

            var englishTerms = listToSearch.Select(x => x.EnglishMeaning).ToList();
            VerifyTerms(englishTerms, this.parentJsonPath);
        }

        private void VerifyTerms(List<string> terms, string jsonPath)
        {            
            var ctr = 1;
            foreach (var spanishTerm in terms)
            {
                var matches = new List<Base>();

                GetTermJasonFile(spanishTerm, jsonPath, matches);

                Assert.True(matches.Count == 1);
                System.Diagnostics.Debug.WriteLine("Ctr: " + ctr.ToString());
                ctr++;
            }
        }

        #endregion

        #region Shared        

        private static void GetTermJasonFile(string term, string jsonPath, List<Base> termJsonMatch)
        {
            if (termJsonMatch.Count > 0)
            {
                return;
            }

            var files = Directory.GetFiles(jsonPath);

            foreach (var file in files)
            {
                if (!file.Contains(".json")) { continue; }

                Assert.NotNull(file);
                    
                var fileContents = File.ReadAllText(file);
                var jsonFile = JsonConvert.DeserializeObject<Verb>(fileContents);

                if (jsonFile.Name == term || jsonFile.EnglishMeaning == term)
                {
                    termJsonMatch.Add(jsonFile);
                    return;
                }
            }

            var subJsonPaths = Directory.GetDirectories(jsonPath);
            foreach (var subJsonPath in subJsonPaths)
            {
                GetTermJasonFile(term, subJsonPath, termJsonMatch);
            }
        }

        #endregion

        #region Verbs 

        [Fact]
        public void VerifyAllVerbsHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}",this.parentJsonPath,"verbs\\");
            var verbs = this.bllService.GetVerbList("Full");

            RunComparisons(verbs, jsonPath);
        }

        #endregion

        #region Vocabulary

        [Fact]
        public void VerifyAllBodyHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}",this.parentJsonPath, "vocabulary\\bodyparts\\");
            var vocabularyListItems = this.bllService.GetVocabularyList("bodyparts");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllPhrasesHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}",this.parentJsonPath,"vocabulary\\phrases\\");
            var vocabularyListItems = this.bllService.GetVocabularyList("phrases");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllHouseTermsHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}",this.parentJsonPath,"vocabulary\\houseterms\\");
            var vocabularyListItems = this.bllService.GetVocabularyList("houseterms");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllClothingTermsHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}",this.parentJsonPath,"vocabulary\\clothing\\");
            var vocabularyListItems = this.bllService.GetVocabularyList("clothing");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllColorsTermsHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}",this.parentJsonPath,"vocabulary\\colors\\");
            var vocabularyListItems = this.bllService.GetVocabularyList("colors");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllFamilyMemberTermsHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}",this.parentJsonPath,"vocabulary\\familymembers\\");
            var vocabularyListItems = this.bllService.GetVocabularyList("familymembers");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllFruitsTermsHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}",this.parentJsonPath,"vocabulary\\fruits\\");
            var vocabularyListItems = this.bllService.GetVocabularyList("fruits");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllTermsFromMeetupGroupHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}",this.parentJsonPath,"vocabulary\\listfrommeetup\\");
            var vocabularyListItems = this.bllService.GetVocabularyList("listfrommeetup");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllPrepositionsTermsHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}",this.parentJsonPath,"vocabulary\\prepositions\\");
            var vocabularyListItems = this.bllService.GetVocabularyList("prepositions");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllQuestionTermsHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}",this.parentJsonPath,"vocabulary\\questions\\");
            var vocabularyListItems = this.bllService.GetVocabularyList("questions");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllShopTermsHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}",this.parentJsonPath,"vocabulary\\shops\\");
            var vocabularyListItems = this.bllService.GetVocabularyList("shops");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllTimeTermsHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}",this.parentJsonPath,"vocabulary\\timewords\\");
            var vocabularyListItems = this.bllService.GetVocabularyList("timewords");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllVegetableTermsHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}",this.parentJsonPath,"vocabulary\\vegetables\\");
            var vocabularyListItems = this.bllService.GetVocabularyList("vegetables");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        private void RunComparisons(List<string> vocabularyListItems, string jsonPath)
        {
            foreach (var vocabularyListItem in vocabularyListItems)
            {
                var jsonFileName = string.Format("{0}.{1}", vocabularyListItem, "json");
                var jsonFilePath = string.Format("{0}{1}", jsonPath, jsonFileName);

                var file = File.ReadAllText(jsonFilePath);
                Assert.NotNull(file);

                var jsonFile = JsonConvert.DeserializeObject<Verb>(file);
                Assert.Equal(vocabularyListItem.Replace("_", " "), jsonFile.Name);
            }
        }

        #endregion
    }
}