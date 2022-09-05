using System.Collections.Generic;
using Shared.Dto;

namespace Shared.Interfaces
{
    public interface ITaspaService
    {
        public List<NavigationLink> GetNavigationLinks();
    }
}
