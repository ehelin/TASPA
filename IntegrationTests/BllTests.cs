using System;
using System.IO;
using BLL;
using DAL;
using Newtonsoft.Json;
using Shared.Dto;
using Shared.Interfaces;
using Xunit;

namespace IntegrationTests
{
    public class BllTests
    {
        private readonly ITaspaService bllService;

        public BllTests()
        {
            ITaspaData dataLayer = new TaspaData();
            this.bllService = new TaspaService(dataLayer);
        }

        [Fact]
        public void VerifyAllVerbsHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\verbs\\";

            var verbs = this.bllService.GetVerbList("Full");
            foreach (var verb in verbs)
            {           
                var jsonFileName = string.Format("{0}.{1}", verb, "json");
                var jsonFilePath = string.Format("{0}{1}", jsonPath, jsonFileName);

                var file = File.ReadAllText(jsonFilePath);
                Assert.NotNull(file);

                var jsonFile = JsonConvert.DeserializeObject<Verb>(file);
                Assert.Equal(verb, jsonFile.Name);
            }
        }
    }
}