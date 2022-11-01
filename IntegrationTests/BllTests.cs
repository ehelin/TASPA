using System;
using System.IO;
using BLL;
using DAL;
using Newtonsoft.Json;
using System.IO;
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

        private void OutputJsonDirectoryToFile(string jsonPath)
        {
            var files = Directory.GetFiles(jsonPath);
            using StreamWriter fileWriter = new(jsonPath + "\\JsonDirectoryBllList.txt");

            foreach (string fle in files)
            {
                var fi = new FileInfo(fle);
                fileWriter.WriteLine("list.Add(\"" + fi.Name + "\")");
            }
            fileWriter.Flush();
            fileWriter.Close();
            fileWriter.Dispose();
        }

        [Fact]
        public void VerifyAllPhrasesHaveCorrespondingJsonFile()
        {
            // TODO - get path dyanmically
            var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\phrases\\";
          
            var phrases = this.bllService.GetVocabularyList("Phrases");
            foreach (var phrase in phrases)
            {           
                var jsonFileName = string.Format("{0}.{1}", phrase, "json");
                var jsonFilePath = string.Format("{0}{1}", jsonPath, jsonFileName);

                var file = File.ReadAllText(jsonFilePath);
                Assert.NotNull(file);

                var jsonFile = JsonConvert.DeserializeObject<Verb>(file);
                Assert.Equal(phrase.Replace("_"," "), jsonFile.Name);
            }
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