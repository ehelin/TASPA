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

        //TODO - get path dyanmically
        //var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\phrases\\";
            
        //var files = Directory.GetFiles(jsonPath);
        //using StreamWriter fileWriter = new(jsonPath + "\\WriteLines2.txt");

        //foreach (string fle in files)
        //{
        //    var fi = new FileInfo(fle);
        //    fileWriter.WriteLine("list.Add(\"" + fi.Name + "\")");
        //}
        //fileWriter.Flush();
        //fileWriter.Close();
        //fileWriter.Dispose();

        [Fact]
        public async void VerifyAllPhrasesHaveCorrespondingJsonFile()
        {
            var currentPhrase = "";
            try 
            {
                var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\phrases\\";
          
                var phrases = this.bllService.GetVocabularyList("Phrases");
                foreach (var phrase in phrases)
                {           
                    var jsonFileName = string.Format("{0}.{1}", phrase, "json");
                    var jsonFilePath = string.Format("{0}{1}", jsonPath, jsonFileName);

                    var file = File.ReadAllText(jsonFilePath);
                    Assert.NotNull(file);

                    var jsonFile = JsonConvert.DeserializeObject<Verb>(file);
                    currentPhrase = phrase;
                    Assert.Equal(phrase.Replace("_"," "), jsonFile.Name);
                }
            } 
            catch(Exception ex)
            {
                var test = 1;
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