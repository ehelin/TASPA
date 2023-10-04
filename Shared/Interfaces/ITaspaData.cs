using System.Collections.Generic;
using Shared.Dto;

namespace Shared.Interfaces
{
    public interface ITaspaData
    {
        public List<NavigationLink> GetNavigationLinks();
        public List<NavigationLink> GetVueJsNavigationLinks();
        public List<VocabularyRadioButton> GetVocabularyRadioButtons();
        public List<SearchTerm> GetSearchList();

        public List<string> GetVocabularyList_Phrases();
        public List<string> GetVocabularyList_GetBodyParts();
        public List<string> GetVocabularyList_HouseTerms();
        public List<string> GetVocabularyList_GetClothing();
        public List<string> GetVocabularyList_GetColors();
        public List<string> GetVocabularyList_GetFamilyMembers();
        public List<string> GetVocabularyList_GetFruits();
        public List<string> GetVocabularyList_GetMeetupList();
        public List<string> GetVocabularyList_GetPrepositions();
        public List<string> GetVocabularyList_GetQuestions();
        public List<string> GetVocabularyList_GetShops();
        public List<string> GetVocabularyList_GetTimeWords();
        public List<string> GetVocabularyList_GetVegetables();

        public List<string> GetVerbLists();
        public List<string> GetAVerbList();
        public List<string> GetBVerbList();
        public List<string> GetCVerbList();
        public List<string> GetDVerbList();
        public List<string> GetEVerbList();
        public List<string> GetFVerbList();
        public List<string> GetGVerbList();
        public List<string> GetHVerbList();
        public List<string> GetIVerbList();
        public List<string> GetJVerbList();
        public List<string> GetLVerbList();
        public List<string> GetMVerbList();
        public List<string> GetNVerbList();
        public List<string> GetOVerbList();
        public List<string> GetPVerbList();
        public List<string> GetQVerbList();
        public List<string> GetRVerbList();
        public List<string> GetSVerbList();
        public List<string> GetTVerbList();
        public List<string> GetUVerbList();
        public List<string> GetVVerbList();
        public List<string> GetZVerbList();
    }
}
