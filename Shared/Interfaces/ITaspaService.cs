using System.Collections.Generic;
using Shared.Dto;

namespace Shared.Interfaces
{
    public interface ITaspaService
    {
        public List<NavigationLink> GetNavigationLinks(Client client);

        public List<VocabularyRadioButton> GetVocabularyRadioButtons();

        public List<string> GetListsToSearch();
        public List<SearchTerm> Search(string searchTerm);
        public List<SearchTerm> GetSearchList();

        public List<string> GetVocabularyList(string vocabularyListName);

        public List<string> GetVerbLists();
        public List<string> GetVerbList(string verbListName);

        public string GetLastVerbListUsed(string rootPath);
        public void SaveLastVerbListUsed(string rootPath, string verbListName);

        public string GetLastVocabularyListUsed(string rootPath);
        public void SaveLastVocabularyListUsed(string rootPath, string verbListName);
    }
}
