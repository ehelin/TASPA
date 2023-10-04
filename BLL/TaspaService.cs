using System;
using System.Collections.Generic;
using Shared;
using Shared.Dto;
using Shared.Interfaces;

namespace BLL
{
    public class TaspaService : ITaspaService
    {
        public ITaspaData taspaDataService;

        private readonly string lastVerbListUsedSubPath;
        private readonly string lastVocabularyListUsedSubPath;
        private const string LAST_VERB_LIST_USED_SUB_PATH = "data\\lastverblistused.txt";
        private const string LAST_VOCABULARY_LIST_USED_SUB_PATH = "data\\lastvocabularylistused.txt";

        public TaspaService(ITaspaData taspaDataService)
        {
            this.taspaDataService = taspaDataService;
        }

        #region Last Used Verb List

        public string GetLastVerbListUsed(string rootPath)
        {
            var path = GetLastItemUsedPath(rootPath, LAST_VERB_LIST_USED_SUB_PATH);
            var lastUsedVerbList = System.IO.File.ReadAllLines(path);

            if (lastUsedVerbList != null && lastUsedVerbList.Length == 1)
            {
                return string.Format("Last Verb List Used: {0}", lastUsedVerbList[0]);
            }

            return null;
        }
        public void SaveLastVerbListUsed(string rootPath, string verbListName)
        {
            var lastVerbListUsedSubPath = GetLastItemUsedPath(rootPath, LAST_VERB_LIST_USED_SUB_PATH);

            // save verb list for UI reference
            System.IO.File.WriteAllText(lastVerbListUsedSubPath, String.Empty);
            System.IO.File.WriteAllText(lastVerbListUsedSubPath, verbListName);
        }

        #endregion

        #region Last Used Vocabulary List

        public string GetLastVocabularyListUsed(string rootPath)
        {
            var lastVocabularyListUsedSubPath = string.Format("{0}\\{1}", rootPath, LAST_VOCABULARY_LIST_USED_SUB_PATH);
            var lastUsedVocabularyList = System.IO.File.ReadAllLines(lastVocabularyListUsedSubPath);

            if (lastUsedVocabularyList != null && lastUsedVocabularyList.Length == 1)
            {
                return string.Format("Last Vocabulary List Used: {0}", lastUsedVocabularyList[0]);
            }

            return null;
        }

        public void SaveLastVocabularyListUsed(string rootPath, string verbListName)
        {
            var lastVocabularyListUsedSubPath = GetLastItemUsedPath(rootPath, LAST_VOCABULARY_LIST_USED_SUB_PATH);

            // save verb list for UI reference
            System.IO.File.WriteAllText(lastVocabularyListUsedSubPath, String.Empty);
            System.IO.File.WriteAllText(lastVocabularyListUsedSubPath, verbListName);
        }

        #endregion

        // TODO - fix any broken tests
        public List<NavigationLink> GetNavigationLinks(Client client)
        {
            List<NavigationLink> navigationLinks = null;

            if (client == Client.VueJs)
            {
                navigationLinks = this.taspaDataService.GetVueJsNavigationLinks();
            }
            else
            {
                navigationLinks = this.taspaDataService.GetNavigationLinks();
            }

            return navigationLinks;
        }

        public List<VocabularyRadioButton> GetVocabularyRadioButtons()
        {
            var vocabularyRadioButtons = this.taspaDataService.GetVocabularyRadioButtons();

            return vocabularyRadioButtons;
        }

        public List<SearchTerm> GetSearchList()
        {
            return this.taspaDataService.GetSearchList();
        }

        // TODO - evaluate for speed...
        public List<SearchTerm> Search(string searchTerm)
        {
            var listOfTermsToSearch = this.taspaDataService.GetSearchList();
            var matches = new List<SearchTerm>();

            foreach (var listTermToSearch in listOfTermsToSearch)
            {
                if (listTermToSearch.Name.Contains(searchTerm) || listTermToSearch.EnglishMeaning.Contains(searchTerm))
                {
                    matches.Add(listTermToSearch);
                }
            }

            return matches;
        }

        public List<string> GetListsToSearch()
        {
            var listsToSearch = new List<string>();
            
            listsToSearch.AddRange(GetVerbList("Full"));
            listsToSearch.AddRange(GetVocabularyList("Full"));

            return listsToSearch;
        }

        public List<string> GetVocabularyList(string listName)
        {
            // TODO - make phraseListName comparison strings constants
            if (listName == "Full")
            {
                var fullVocabularyList = new List<string>();

                fullVocabularyList.AddRange(this.taspaDataService.GetVocabularyList_Phrases());
                fullVocabularyList.AddRange(this.taspaDataService.GetVocabularyList_GetBodyParts());
                fullVocabularyList.AddRange(this.taspaDataService.GetVocabularyList_HouseTerms());
                fullVocabularyList.AddRange(this.taspaDataService.GetVocabularyList_GetClothing());
                fullVocabularyList.AddRange(this.taspaDataService.GetVocabularyList_GetColors());
                fullVocabularyList.AddRange(this.taspaDataService.GetVocabularyList_GetFamilyMembers());
                fullVocabularyList.AddRange(this.taspaDataService.GetVocabularyList_GetFruits());
                fullVocabularyList.AddRange(this.taspaDataService.GetVocabularyList_GetMeetupList());
                fullVocabularyList.AddRange(this.taspaDataService.GetVocabularyList_GetPrepositions());
                fullVocabularyList.AddRange(this.taspaDataService.GetVocabularyList_GetQuestions());
                fullVocabularyList.AddRange(this.taspaDataService.GetVocabularyList_GetShops());
                fullVocabularyList.AddRange(this.taspaDataService.GetVocabularyList_GetTimeWords());
                fullVocabularyList.AddRange(this.taspaDataService.GetVocabularyList_GetVegetables());

                return fullVocabularyList;
            }
            else if (listName == "phrases") { return this.taspaDataService.GetVocabularyList_Phrases(); }
            else if (listName == "bodyparts") { return this.taspaDataService.GetVocabularyList_GetBodyParts(); }
            else if (listName == "houseterms") { return this.taspaDataService.GetVocabularyList_HouseTerms(); }
            else if (listName == "clothing") { return this.taspaDataService.GetVocabularyList_GetClothing(); }
            else if (listName == "colors") { return this.taspaDataService.GetVocabularyList_GetColors(); }
            else if (listName == "familymembers") { return this.taspaDataService.GetVocabularyList_GetFamilyMembers(); }
            else if (listName == "fruits") { return this.taspaDataService.GetVocabularyList_GetFruits(); }
            else if (listName == "listfrommeetup") { return this.taspaDataService.GetVocabularyList_GetMeetupList(); }
            else if (listName == "prepositions") { return this.taspaDataService.GetVocabularyList_GetPrepositions(); }
            else if (listName == "questions") { return this.taspaDataService.GetVocabularyList_GetQuestions(); }
            else if (listName == "shops") { return this.taspaDataService.GetVocabularyList_GetShops(); }
            else if (listName == "timewords") { return this.taspaDataService.GetVocabularyList_GetTimeWords(); }
            else if (listName == "vegetables") { return this.taspaDataService.GetVocabularyList_GetVegetables(); }

            else
            {
                throw new Exception(string.Format("Unknown vocabulary list name: {0}", listName));
            }
        }

        public List<string> GetVerbLists()
        {
            var verbLists = this.taspaDataService.GetVerbLists();

            return verbLists;
        }

        public List<string> GetVerbList(string verbListName)
        {
            // TODO - make verbListName comparison strings constants
            if (verbListName == "Full")
            {
                var fullVerbList = new List<string>();

                fullVerbList.AddRange(this.taspaDataService.GetAVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetBVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetCVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetDVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetEVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetFVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetGVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetHVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetIVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetJVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetLVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetMVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetNVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetOVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetPVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetQVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetRVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetSVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetTVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetUVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetVVerbList());
                fullVerbList.AddRange(this.taspaDataService.GetZVerbList());

                return fullVerbList;
            }
            else if (verbListName == "A") { return this.taspaDataService.GetAVerbList(); }
            else if (verbListName == "B") { return this.taspaDataService.GetBVerbList(); }
            else if (verbListName == "C") { return this.taspaDataService.GetCVerbList(); }
            else if (verbListName == "D") { return this.taspaDataService.GetDVerbList(); }
            else if (verbListName == "E") { return this.taspaDataService.GetEVerbList(); }
            else if (verbListName == "F") { return this.taspaDataService.GetFVerbList(); }
            else if (verbListName == "G") { return this.taspaDataService.GetGVerbList(); }
            else if (verbListName == "H") { return this.taspaDataService.GetHVerbList(); }
            else if (verbListName == "I") { return this.taspaDataService.GetIVerbList(); }
            else if (verbListName == "J") { return this.taspaDataService.GetJVerbList(); }
            //else if (verbListName == "K") { return this.taspaDataService.GetKVerbList(); }
            else if (verbListName == "L") { return this.taspaDataService.GetLVerbList(); }
            else if (verbListName == "M") { return this.taspaDataService.GetMVerbList(); }
            else if (verbListName == "N") { return this.taspaDataService.GetNVerbList(); }
            else if (verbListName == "O") { return this.taspaDataService.GetOVerbList(); }
            else if (verbListName == "P") { return this.taspaDataService.GetPVerbList(); }
            else if (verbListName == "Q") { return this.taspaDataService.GetQVerbList(); }
            else if (verbListName == "R") { return this.taspaDataService.GetRVerbList(); }
            else if (verbListName == "S") { return this.taspaDataService.GetSVerbList(); }
            else if (verbListName == "T") { return this.taspaDataService.GetTVerbList(); }
            else if (verbListName == "U") { return this.taspaDataService.GetUVerbList(); }
            else if (verbListName == "V") { return this.taspaDataService.GetVVerbList(); }
            //else if (verbListName == "W") { return this.taspaDataService.GetWVerbList(); }
            //else if (verbListName == "X") { return this.taspaDataService.GetXVerbList(); }
            //else if (verbListName == "Y") { return this.taspaDataService.GetYVerbList(); }
            else if (verbListName == "Z") { return this.taspaDataService.GetZVerbList(); }
            else
            {
                throw new Exception(string.Format("Unknown verb list name: {0}", verbListName));
            }
        }

        #region Private Methods

        private string GetLastItemUsedPath(string rootPath, string subPath)
        {
            return string.Format("{0}\\{1}", rootPath, subPath);
        }

        #endregion
    }
}