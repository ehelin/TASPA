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

        public BllTests()
        {
            ITaspaData dataLayer = new TaspaData();
            this.bllService = new TaspaService(dataLayer);
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
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\";
            var listToSearch = this.bllService.GetSearchList();

            var spanishTerms = listToSearch.Select(x => x.Name).ToList();
            VerifyTerms(spanishTerms, jsonPath);

            var englishTerms = listToSearch.Select(x => x.EnglishMeaning).ToList();
            VerifyTerms(englishTerms, jsonPath);
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
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\verbs\\";
            var verbs = this.bllService.GetVerbList("Full");

            RunComparisons(verbs, jsonPath);
        }

        #endregion

        #region Vocabulary

        [Fact]
        public void VerifyAllBodyHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\bodyparts\\";
            var vocabularyListItems = this.bllService.GetVocabularyList("TheBody");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllPhrasesHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\phrases\\";
            var vocabularyListItems = this.bllService.GetVocabularyList("Phrases");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllHouseTermsHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\houseterms\\";
            var vocabularyListItems = this.bllService.GetVocabularyList("HouseTerms");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllClothingTermsHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\clothing\\";
            var vocabularyListItems = this.bllService.GetVocabularyList("Clothing");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllColorsTermsHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\colors\\";
            var vocabularyListItems = this.bllService.GetVocabularyList("Colors");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllFamilyMemberTermsHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\familymembers\\";
            var vocabularyListItems = this.bllService.GetVocabularyList("FamilyMembers");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllFruitsTermsHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\fruits\\";
            var vocabularyListItems = this.bllService.GetVocabularyList("Fruits");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllTermsFromMeetupGroupHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\listfrommeetup\\";
            var vocabularyListItems = this.bllService.GetVocabularyList("MeetupGroupList");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllPrepositionsTermsHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\prepositions\\";
            var vocabularyListItems = this.bllService.GetVocabularyList("Prepositions");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllQuestionTermsHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\questions\\";
            var vocabularyListItems = this.bllService.GetVocabularyList("Questions");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllShopTermsHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\shops\\";
            var vocabularyListItems = this.bllService.GetVocabularyList("Shops");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllTimeTermsHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\timewords\\";
            var vocabularyListItems = this.bllService.GetVocabularyList("Time");

            RunComparisons(vocabularyListItems, jsonPath);
        }

        [Fact]
        public void VerifyAllVegetableTermsHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\vegetables\\";
            var vocabularyListItems = this.bllService.GetVocabularyList("Vegetables");

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