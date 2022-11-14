using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BLL
{
    public class Utilities
    {
        public static void CreateVocabularyList(string listStructuredFilePath, string outputJsonPath)
        {
            GetVocabularyListsToBeConvertedToJsonFilesVerbList(listStructuredFilePath);
        }

        private static void GetVocabularyListsToBeConvertedToJsonFilesVerbList(string listStructuredFilePath)
        {
            string fileContents = null;

            using (var reader = File.OpenText(listStructuredFilePath))
            {
                fileContents = reader.ReadToEnd();
            }

            var fileContentsByLines = fileContents.Split("\r\n");
            var rawVocabularyLists = CreateRawVocabularyLists(fileContentsByLines);
            var finalCodeVocabularyLists = CreateCodeVocabularyLists(rawVocabularyLists);
            
            // TODO - write out the code lists to a file
            // TODO - create json files for each vocabulary
        }

        
        private static List<List<string>> CreateCodeVocabularyLists(List<List<string>> rawVocabularyLists)
        {
            var finalCodeVocabularyLists = new List<List<string>>();            
            var finalCodeVocabularyList = new List<string>();

            foreach (var rawVocabularyList in rawVocabularyLists)
            {
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

        private static List<List<string>> CreateRawVocabularyLists(string[] fileContentsByLines)
        {
            var vocabularyLists = new List<List<string>>();
            var vocabularyList = new List<string>();
          
            for (var ctr=0; ctr <fileContentsByLines.Length; ctr++)
            {
                var line = fileContentsByLines[ctr];

                // new list
                if (line.IndexOf("function") != -1)        
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
                }
                else 
                {
                    var commaPos = line.IndexOf(",");
                    var editedLine = line.Substring(commaPos+1, (line.Length-(commaPos+1)));

                    editedLine = editedLine.Replace(";\";", "");
                    editedLine = editedLine.Replace(";';\"", "");

                    vocabularyList.Add(editedLine);
                }
           }

            return vocabularyLists;
        }

        private static void OutputJsonDirectoryToFile(string jsonPath)
        {
            var files = Directory.GetFiles(jsonPath);
            using StreamWriter fileWriter = new(jsonPath + "\\JsonDirectoryBllList.txt");

            foreach (string fle in files)
            {
                var fi = new FileInfo(fle);
                fileWriter.WriteLine("list.Add(\"" + fi.Name + "\");");
            }
            fileWriter.Flush();
            fileWriter.Close();
            fileWriter.Dispose();
        }
    }
}
