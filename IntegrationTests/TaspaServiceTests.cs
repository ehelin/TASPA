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
using sharedDto = Shared.Dto;
using sharedIfc = Shared.Interfaces;

namespace IntegrationTests
{
    public class TaspaServiceTests
	{
        private readonly ITaspaService bllService;
        private readonly string parentJsonPath;
        private readonly string rootJsonPath;

        public TaspaServiceTests()
        {
            ITaspaData dataLayer = new TaspaData();
            this.bllService = new TaspaService(dataLayer);

            // TODO - get paths dyanmically
            this.parentJsonPath = "C:\\EricDocuments\\Personal\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\";
            this.rootJsonPath = "C:\\EricDocuments\\Personal\\Taspa2\\TASPA\\wwwroot\\";
        }

        #region Service

        [Fact]
        public void SaveGetLastVerbListUsedTest()
        {
            var expectedLastUsedVerbList = "lastUsedVerbList";
            this.bllService.SaveLastVerbListUsed(rootJsonPath, expectedLastUsedVerbList);
            var actualLastUsedVerb = this.bllService.GetLastVerbListUsed(rootJsonPath);

            Assert.Contains(expectedLastUsedVerbList, actualLastUsedVerb);
        }

        [Fact]
        public void SaveGetLastVocabularyListUsedTest()
        {
            var expectedLastUsedVocabularyList = "lastUsedVocabularyList";
            this.bllService.SaveLastVocabularyListUsed(rootJsonPath, expectedLastUsedVocabularyList);
            var actualLastUsedVocabularyList = this.bllService.GetLastVocabularyListUsed(rootJsonPath);

            Assert.Contains(expectedLastUsedVocabularyList, actualLastUsedVocabularyList);
        }

        [Fact]
        public void GetNavigationLinksTest()
        {
            var navigationLinks = this.bllService.GetNavigationLinks();

            Assert.NotNull(navigationLinks);
            Assert.True(navigationLinks.Count() > 0);
            Assert.True(navigationLinks.Any(x => x.LinkText == "Home"));
            Assert.True(navigationLinks.Any(x => x.LinkAction == "/Index"));
        }

        [Fact]
        public void GetVocabularyRadioButtonsTest()
        {
            var vocabularyRadioButtons = this.bllService.GetVocabularyRadioButtons();

            Assert.NotNull(vocabularyRadioButtons);
            Assert.True(vocabularyRadioButtons.Count() > 0);
            Assert.True(vocabularyRadioButtons.Any(x => x.LinkText == "Body"));
            Assert.True(vocabularyRadioButtons.Any(x => x.Value == "bodyparts"));
        }

        [Fact]
        public void GetSearchListTest()
        {
            var searchList = this.bllService.GetSearchList();

            Assert.NotNull(searchList);
            Assert.True(searchList.Count() > 0);
            Assert.True(searchList.Any(x => x.Name == "acostar"));
            Assert.True(searchList.Any(x => x.EnglishMeaning == "to lay down, go to bed"));
        }

        // NOTE: Sanity test...needs to be expanded
        [Theory]
        [InlineData("abrazar", true)]                   //expected Spanish to be found
        [InlineData("to lose weight", true)]            //expected English to be found
        [InlineData("blah", false)]                     //expected Spanish not to be found
        [InlineData("blah2", false)]                    //expected English not to be found
        public void ExpectedSearchResultTest(string spanishTerm, bool expectedToBeFound)
        {
            var matches = this.bllService.Search(spanishTerm);
            Assert.Equal(expectedToBeFound, matches.Count > 0);
        }

        [Theory]
        [InlineData("Full", "el_brazo")]
        [InlineData("phrases", "necio")]
        [InlineData("bodyparts", "el_brazo")]
        [InlineData("houseterms", "el_armario")]
        [InlineData("clothing", "el_zapato")]
        [InlineData("colors", "amarillo")]
        [InlineData("familymembers", "abuelo")]
        [InlineData("fruits", "el_cantalupo")]
        [InlineData("listfrommeetup", "campo")]
        [InlineData("prepositions", "durante")]
        [InlineData("questions", "adonde")]
        [InlineData("shops", "panadería")]
        [InlineData("timewords", "junio")]
        [InlineData("vegetables", "el_tomate")]
        public void GetVocabularyListTest(string vocabularyListName, string aListMember)
        {
            var vocabularyList = this.bllService.GetVocabularyList(vocabularyListName);

            Assert.NotNull(vocabularyList);
            Assert.True(vocabularyList.Count() > 0);
            Assert.True(vocabularyList.Any(x => x == aListMember));
        }

        [Fact]
        public void GetVerbListsTest()
        {
            var verbLists = this.bllService.GetVerbLists();

            Assert.NotNull(verbLists);
            Assert.True(verbLists.Count() > 0);
            Assert.True(verbLists.Any(x => x == "Full"));
            Assert.True(verbLists.Any(x => x == "H"));
        }

        [Theory]
        [InlineData("Full", "abrazar")]
        [InlineData("A", "andar")]
        [InlineData("B", "bailar")]
        [InlineData("C", "caber")]
        [InlineData("D", "detener")]
        [InlineData("E", "echar")]
        [InlineData("F", "faltar")]
        [InlineData("G", "gritar")]
        [InlineData("H", "haber")]
        [InlineData("I", "iniciar")]
        [InlineData("J", "jugar")]
        [InlineData("L", "lanzar")]
        [InlineData("M", "mandar")]
        [InlineData("N", "nadar")]
        [InlineData("O", "oir")]
        [InlineData("P", "pasar")]
        [InlineData("Q", "quedar")]
        [InlineData("R", "recibir")]
        [InlineData("S", "saber")]
        [InlineData("T", "tirar")]
        [InlineData("U", "usar")]
        [InlineData("V", "ver")]
        [InlineData("Z", "zarpar")]
        public void GetVerbListTest(string verbListName, string aListMember)
        {
            var verbList = this.bllService.GetVerbList((verbListName));

            Assert.NotNull(verbList);
            Assert.True(verbList.Count() > 0);
            Assert.True(verbList.Any(x => x == aListMember));
        }

        [Fact]
        public void GetVerbListErrorTest()
        {
            var nonExistingVerbList = "nonExistingVerbList";
            var ex = Assert.Throws<Exception>(() => this.bllService.GetVerbList(nonExistingVerbList));

            Assert.Contains("Unknown verb list name", ex.Message);
            Assert.Contains(nonExistingVerbList, ex.Message);
        }

        #endregion

        #region Verifications

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

        [Fact]
        public void VerifyAllVerbsHaveCorrespondingJsonFile()
        {
            var jsonPath = string.Format("{0}{1}", this.parentJsonPath, "verbs\\");
            var verbs = this.bllService.GetVerbList("Full");

            RunComparisons(verbs, jsonPath);
        }

        #endregion

        #region Private

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
                var jsonFile = JsonConvert.DeserializeObject<sharedDto.Verb>(fileContents);

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
            var ctr = 0;
            var errorCtr = 0;
            var jsonName = "";
            foreach (var vocabularyListItem in vocabularyListItems)
            {
                try
                {                    
                    var jsonFileName = string.Format("{0}.{1}", vocabularyListItem, "json");
                    var jsonFilePath = string.Format("{0}{1}", jsonPath, jsonFileName);

                    jsonName = jsonFileName;

                    var file = File.ReadAllText(jsonFilePath);
                    Assert.NotNull(file);

                    var jsonFile = JsonConvert.DeserializeObject<sharedDto.Verb>(file);
                    Assert.Equal(vocabularyListItem.Replace("_", " "), jsonFile.Name);
                }
                catch (Exception ex)
                {
                    errorCtr++;
                    System.Diagnostics.Debug.WriteLine(string.Format("{0} error ctr: {1}", jsonName, errorCtr.ToString()));
                }
                ctr++;
            }
        }

        #endregion
    }
}