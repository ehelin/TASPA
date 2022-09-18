using System.Collections.Generic;
using Shared.Dto;

namespace Shared.Interfaces
{
    public interface ITaspaService
    {
        public List<NavigationLink> GetNavigationLinks();
        public List<string> GetVerbLists();
        public List<string> GetVerbList(string verbListName);
    }
}
