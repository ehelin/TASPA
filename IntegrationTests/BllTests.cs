using System;
using System.Collections.Generic;
using System.IO;
using BLL;
using DAL;
using Newtonsoft.Json;
using Shared.Dto;
using Shared.Interfaces;
using Xunit;

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