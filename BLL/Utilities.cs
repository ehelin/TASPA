using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Shared.Dto;
using Shared.Interfaces;

namespace BLL
{
    public class Utilities
    {
        #region Create Vocabulary Lists

        public static void CreateVocabularyList(string listStructuredFilePath, string outputJsonPath, string fileName)
        {
            GetVocabularyListsToBeConvertedToJsonFilesVerbList(listStructuredFilePath, outputJsonPath, fileName);
        }

        private static void GetVocabularyListsToBeConvertedToJsonFilesVerbList(string listStructuredFilePath, 
            string outputJsonPath, 
            string fileName)
        {
            string fileContents = null;

            using (var reader = File.OpenText(listStructuredFilePath))
            {
                fileContents = reader.ReadToEnd();
            }

            var fileContentsByLines = fileContents.Split("\r\n");
            var rawVocabularyLists = CreateRawVocabularyLists(fileContentsByLines);
            var finalCodeVocabularyLists = CreateCodeVocabularyLists(rawVocabularyLists);

            WriteFinalVocabularyListToFile(outputJsonPath, fileName, finalCodeVocabularyLists);
            var ctr = 1;
            foreach (var vocabularyList in rawVocabularyLists)
            {
                var jsonPath = string.Format("{0}\\list{1}", outputJsonPath, ctr.ToString());
                WriteFinalVocabularyListToJsonFiles(jsonPath, vocabularyList);
                ctr++;
            }
        }
        
        private static void WriteFinalVocabularyListToJsonFiles(string jsonPath, List<string> vocabularyList)
        {
            if (!Directory.Exists(jsonPath))
            {
                Directory.CreateDirectory(jsonPath);
            }

            var jsonPathDirectoryFiles = Directory.GetFiles(jsonPath);
            foreach (var file in jsonPathDirectoryFiles)
            {
                File.Delete(file);
            }

            foreach (var line in vocabularyList) 
            {
                if (line.Contains("public List<string>") 
                    || line.Contains("var list = new List<string>();")
                    || string.IsNullOrEmpty(line)
                    || line.Contains("return list;")
                    || line.Contains("}")
                    )
                {
                    continue;
                }

                var englishWord = line.Substring(0, line.IndexOf(",")).Trim();            
                var spanishWord = line.Substring(line.IndexOf(",") + 1).Trim();
                var jsonContents = $"{{\"Name\":\"" + spanishWord + "\",\"EnglishMeaning\":\"" + englishWord + "\"}";

                spanishWord = spanishWord.Replace(" ", "_");
                using StreamWriter fileWriter = new(jsonPath + "\\" + spanishWord + ".json", false);
                    
                fileWriter.WriteLine(jsonContents);
                    
                fileWriter.Flush();
                fileWriter.Close();
                fileWriter.Dispose();
            }         
        }

        private static List<List<string>> CreateRawVocabularyLists(string[] fileContentsByLines)
        {
            var vocabularyLists = new List<List<string>>();
            var vocabularyList = new List<string>();

            bool isMeetupList = false;
            for (var ctr=0; ctr <fileContentsByLines.Length; ctr++)
            {
                var line = fileContentsByLines[ctr];

                // new list
                if (line.IndexOf("public List<string>") != -1)        
                {
                    if (ctr == 0)
                    {
                        vocabularyList.Add(line);
                    }
                    else
                    {
                        vocabularyLists.Add(vocabularyList);
                        vocabularyList = new List<string>();
                        vocabularyList.Add(line);
                    }
                    if (isMeetupList == false & line.IndexOf("GetMeetupList()") != -1)
                    {
                        isMeetupList = true;
                    }
                    else
                    {
                        isMeetupList = false;
                    }
                }
                else 
                {
                    var commaPos = line.IndexOf(",");
                    var editedLine = line.Substring(commaPos+1, (line.Length-(commaPos+1)));
                    editedLine = editedLine.Replace(";\";", "");
                    editedLine = editedLine.Replace(";';\"", "");

                    //if meetup list, flip words
                    if (isMeetupList)
                    {
                        var firstHalf = editedLine.Substring(0, editedLine.IndexOf(",")).Trim();
                        var secondHalf = editedLine.Substring(editedLine.IndexOf(",") + 1).Trim();
                        editedLine = string.Format("{0},{1}", secondHalf, firstHalf);
                    }

                    vocabularyList.Add(editedLine);
                }
           }

            return vocabularyLists;
        }
        
        private static List<List<string>> CreateCodeVocabularyLists(List<List<string>> rawVocabularyLists)
        {
            var finalCodeVocabularyLists = new List<List<string>>();   

            foreach (var rawVocabularyList in rawVocabularyLists)
            {                         
                var finalCodeVocabularyList = new List<string>();
                var ctr = 0;
                foreach (var line in rawVocabularyList) 
                {
                    if (ctr == 0)
                    {
                        finalCodeVocabularyList.Add(line);
                        finalCodeVocabularyList.Add("var list = new List<string>();");
                        finalCodeVocabularyList.Add("");
                    }
                    else 
                    {
                        var commaPos = line.IndexOf(",");
                        var spanishWord = line.Substring(commaPos + 1, line.Length - (commaPos + 1));
                        var codeSpanishLine = "list.Add(\"" + spanishWord + "\");";
                        codeSpanishLine = codeSpanishLine.Replace("\\", "");
                        codeSpanishLine = codeSpanishLine.Trim();
                        codeSpanishLine = codeSpanishLine.Replace(" ", "_");
                        finalCodeVocabularyList.Add(codeSpanishLine);
                    }

                    ctr++;
                }
                
                finalCodeVocabularyList.Add("");
                finalCodeVocabularyList.Add("return list;");
                finalCodeVocabularyList.Add("}");

                finalCodeVocabularyLists.Add(finalCodeVocabularyList);
            }

            return finalCodeVocabularyLists;
        }
          
        private static void OutputJsonDirectoryToFile(string jsonPath)
        {
            var files = Directory.GetFiles(jsonPath);
            using StreamWriter fileWriter = new(jsonPath + "\\JsonDirectoryBllList.txt");

            foreach (string fle in files)
            {
                var fi = new FileInfo(fle);
                fileWriter.WriteLine(fle);
            }
            fileWriter.Flush();
            fileWriter.Close();
            fileWriter.Dispose();
        }

        #endregion

        #region Create Search Spanish English Lists

        public static void CreateSearchLists(ITaspaService businessService, string jsonPath, string outPath, string fileName)
        {
            var spanishEnglishSearchList = new List<Tuple<string, string, string>>();
            var combinedSpanishTermList = businessService.GetListsToSearch();

            foreach (var spanishTerm in combinedSpanishTermList)
            {
                var spanishTermWithSuffix = string.Format("{0}.{1}", spanishTerm, "json");
                var englishTermJsonPath = new List<string>();

                GetEnglishTerm(spanishTermWithSuffix, jsonPath, englishTermJsonPath);
                if (englishTermJsonPath == null || englishTermJsonPath.Count != 1 || string.IsNullOrEmpty(englishTermJsonPath[0]))
                {
                    throw new Exception("No english term found for " + spanishTerm);
                }
                else
                {
                    var file = File.ReadAllText(englishTermJsonPath[0]);
                    var jsonFile = JsonConvert.DeserializeObject<SearchTerm>(file);
                    var start = englishTermJsonPath[0].IndexOf("wwwroot");
                    var relativeJsonPath = englishTermJsonPath[0].Substring(start, englishTermJsonPath[0].Length-start);
                    relativeJsonPath = relativeJsonPath.Replace("\\", "\\\\");                    
                    spanishEnglishSearchList.Add(new Tuple<string, string, string>(jsonFile.Name, jsonFile.EnglishMeaning, relativeJsonPath));
                }
            }

            if (combinedSpanishTermList.Count != spanishEnglishSearchList.Count)
            {
                throw new Exception("Combined spanish list does not match the spanish/english list");
            }

            var listToExport = FormatSearchListToListForExport(spanishEnglishSearchList);
            var listOfListsToExport = new List<List<string>>() { listToExport };

            WriteFinalVocabularyListToFile(outPath, fileName, listOfListsToExport);
        }
        
        private static void WriteFinalVocabularyListToFile(string jsonPath, string fileName, List<List<string>> finalVocabularyLists)
        {
            using StreamWriter fileWriter = new(jsonPath + "\\" + fileName, false);

            foreach (var finalVocabularyList in finalVocabularyLists) 
            { 
                foreach (var line in finalVocabularyList) 
                {             
                    fileWriter.WriteLine(line);
                } 
                
                fileWriter.WriteLine("");
            } 
            
            fileWriter.Flush();
            fileWriter.Close();
            fileWriter.Dispose();
        }

        private static List<string> FormatSearchListToListForExport(List<Tuple<string, string, string>> listToExport)
        {
            var exportedList = new List<string>();
            
            exportedList.Add("using System.Collections.Generic;");            
            exportedList.Add("using Shared.Dto;");            
            exportedList.Add("");            
            exportedList.Add("namespace DAL");
            exportedList.Add("{");
            exportedList.Add("public class SearchList");
            exportedList.Add("{");

            exportedList.Add("//NOTE: List is generated by Bll.Utilities.CreateSearchLists(args)");
            exportedList.Add("public List<SearchTerm> GetSearchList()");
            exportedList.Add("{");
            exportedList.Add("var searchList = new List<SearchTerm>();");
            exportedList.Add("");

            foreach (var listItem in listToExport) 
            {
                exportedList.Add("searchList.Add(new SearchTerm() { Name = \"" + listItem.Item1 + "\", EnglishMeaning = \"" + listItem.Item2 + "\", JsonPath = \"" + listItem.Item3 + "\" });");
            }
            
            exportedList.Add("");
            exportedList.Add("return searchList;");
            exportedList.Add("}");
            exportedList.Add("}");
            exportedList.Add("}");

            return exportedList;
        }

        private static void GetEnglishTerm(string spanishTerm, string jsonPath, List<string> englishTermJsonPath)
        {
            if (englishTermJsonPath.Count > 0)
            {
                return;
            }

            var files = Directory.GetFiles(jsonPath);

            foreach (var file in files)
            {
                if (file.Contains(spanishTerm))
                {
                    englishTermJsonPath.Add(file);
                    return;
                }
            }

            var subJsonPaths = Directory.GetDirectories(jsonPath);
            foreach (var subJsonPath in subJsonPaths)
            {
                GetEnglishTerm(spanishTerm, subJsonPath, englishTermJsonPath);
            }
        }

        #endregion
    }
}
