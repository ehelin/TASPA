using System.Collections.Generic;
using Shared.Dto;

namespace Shared.Interfaces
{
    public interface ITaspaService
    {
        public List<NavigationLink> GetNavigationLinks();

        public List<VocabularyRadioButton> GetVocabularyRadioButtons();

        public List<string> GetListsToSearch();

        public List<string> GetVocabularyList(string vocabularyListName);

        public List<string> GetVerbLists();
        public List<string> GetVerbList(string verbListName);
    }
}
