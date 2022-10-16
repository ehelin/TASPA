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
            //else if (verbListName == "Z") { return this.taspaDataService.GetZVerbList(); }
            else
            {
                throw new Exception(string.Format("Unknown verb list name: {0}", verbListName));
            }
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