using System.Collections.Generic;
using Shared.Dto;

namespace Shared.Interfaces
{
    public interface ITaspaData
    {
        public List<NavigationLink> GetNavigationLinks();
    }
}
