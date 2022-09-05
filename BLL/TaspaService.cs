using System.Collections.Generic;
using Shared.Interfaces;
using Shared.Dto;

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
    }
}