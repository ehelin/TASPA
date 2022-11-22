using System;
using System.Collections.Generic;
using Shared.Dto;
using Shared.Interfaces;

namespace BLL
{
    public class TaspaService : ITaspaService
    {
        public ITaspaData taspaDataService;

        public TaspaService(ITaspaData taspaDataService)
        {
            this.taspaDataService = taspaDataService;
        }

        public List<NavigationLink> GetNavigationLinks()
        {
            var navigationLinks = this.taspaDataService.GetNavigationLinks();

            return navigationLinks;
        }


        public List<string> GetVocabularyLists()
        {
            var vocabularyLists = this.taspaDataService.GetVocabularyLists();

            return vocabularyLists;
        }

        public List<string> GetVocabularyList(string listName)
        {
            // TODO - make phraseListName comparison strings constants
            if (listName == "Phrases") { return this.taspaDataService.GetVocabularyList_Phrases(); }
            else if (listName == "TheBody") { return this.taspaDataService.GetVocabularyList_GetBodyParts(); }
            else if (listName == "HouseTerms") { return this.taspaDataService.GetVocabularyList_HouseTerms(); }
            else if (listName == "Clothing") { return this.taspaDataService.GetVocabularyList_GetClothing(); }
            else if (listName == "Colors") { return this.taspaDataService.GetVocabularyList_GetColors(); }
            else if (listName == "FamilyMembers") { return this.taspaDataService.GetVocabularyList_GetFamilyMembers(); }
            else if (listName == "Fruits") { return this.taspaDataService.GetVocabularyList_GetFruits(); }

            //
            
            //else if (listName == "D") { return this.taspaDataService.GetDPhraseList(); }
            //else if (listName == "E") { return this.taspaDataService.GetEPhraseList(); }
            //else if (listName == "F") { return this.taspaDataService.GetFPhraseList(); }
            //else if (listName == "G") { return this.taspaDataService.GetGPhraseList(); }
            //else if (listName == "H") { return this.taspaDataService.GetHPhraseList(); }
            //else if (listName == "I") { return this.taspaDataService.GetIPhraseList(); }
            //else if (listName == "J") { return this.taspaDataService.GetJPhraseList(); }
            //else if (listName == "K") { return this.taspaDataService.GetKPhraseList(); }
            //else if (listName == "L") { return this.taspaDataService.GetLPhraseList(); }
            //else if (listName == "M") { return this.taspaDataService.GetMPhraseList(); }
            //else if (listName == "N") { return this.taspaDataService.GetNPhraseList(); }
            //else if (listName == "O") { return this.taspaDataService.GetOPhraseList(); }
            //else if (listName == "P") { return this.taspaDataService.GetPPhraseList(); }
            //else if (listName == "Q") { return this.taspaDataService.GetQPhraseList(); }
            //else if (listName == "R") { return this.taspaDataService.GetRPhraseList(); }
            //else if (listName == "S") { return this.taspaDataService.GetSPhraseList(); }
            //else if (listName == "T") { return this.taspaDataService.GetTPhraseList(); }
            //else if (listName == "U") { return this.taspaDataService.GetUPhraseList(); }
            //else if (listName == "V") { return this.taspaDataService.GetVPhraseList(); }
            //else if (listName == "W") { return this.taspaDataService.GetWPhraseList(); }
            //else if (listName == "X") { return this.taspaDataService.GetXPhraseList(); }
            //else if (listName == "Y") { return this.taspaDataService.GetYPhraseList(); }
            //else if (listName == "Z") { return this.taspaDataService.GetZPhraseList(); }
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
            if (verbListName == "Full") { return GetFullVerbList(); }
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

        private List<string> GetFullPhraseList()
        {
            var fullVerbList = new List<string>();

            //fullVerbList.AddRange(this.taspaDataService.GetAVocabularyList());
            //fullVerbList.AddRange(this.taspaDataService.GetBPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetCPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetDPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetEPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetFPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetGPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetHPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetIPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetJPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetLPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetMPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetNPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetOPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetPPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetQPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetRPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetSPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetTPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetUPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetVPhraseList());
            //fullVerbList.AddRange(this.taspaDataService.GetZPhraseList());

            return fullVerbList;
        }

        private List<string> GetFullVerbList()
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
    }
}