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

        public List<string> GetFullVerbList()
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

            return fullVerbList;
        }
    }
}