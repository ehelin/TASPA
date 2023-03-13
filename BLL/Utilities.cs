using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        #region Add Present Tense Conjugations To Existing Verb Lists

        public static void AddPresentTenseConjucationsToExistingVerbList(string sourceJsonVerbsWithConjugations, string destinationJsonVerbsWithOutConjugations)
        {
            AddConjucationToExistingVerbList(sourceJsonVerbsWithConjugations, destinationJsonVerbsWithOutConjugations);
        }

        private static void AddConjucationToExistingVerbList(string sourceJsonVerbsWithConjugations, string destinationJsonVerbsWithOutConjugations)
        {
            var sourceFilePaths = Directory.GetFiles(sourceJsonVerbsWithConjugations);
            var destinationFilePaths = Directory.GetFiles(destinationJsonVerbsWithOutConjugations);

            var filesUpdatedCtr = 0;
            var filesNotUpdateCtr = 0;
            foreach (var destinationFilePath in destinationFilePaths)
            {
                string destinationFileContents = GetFileContents(destinationFilePath);
                string sourceFileContents = GetSourceFileContents(destinationFilePath, sourceFilePaths);

                if (!string.IsNullOrEmpty(sourceFileContents))
                {
                    var destinationFile = JsonConvert.DeserializeObject<Verb>(sourceFileContents);
                    var sourceFile = JsonConvert.DeserializeObject<Verb>(sourceFileContents);

                    destinationFile = Apply(sourceFile, destinationFile);
                    var destinationFileContentsUpdated = JsonConvert.SerializeObject(destinationFile);

                    File.WriteAllText(destinationFilePath, destinationFileContentsUpdated);
                    filesUpdatedCtr++;
                }
                else
                {
                    Console.WriteLine(string.Format("Unable to update {0}", destinationFilePath));
                    filesNotUpdateCtr++;
                }
            }

            Console.WriteLine(string.Format("{0} Files updated", filesUpdatedCtr));
            Console.WriteLine(string.Format("{0} Files Not updated", filesNotUpdateCtr));
        }

        private static Verb Apply(Verb legacyVerb, Verb verb)
        {
            verb.PresentParticiple = legacyVerb.PresentParticiple;
            verb.PastParticiple = legacyVerb.PastParticiple;
            verb.Subjunctive = legacyVerb.Subjunctive;
            verb.Indicative = verb.Indicative;

            return verb;
        }

        private static string GetFileContents(string path)
        {
            string fileContents = null;
            using (var reader = File.OpenText(path))
            {
                fileContents = reader.ReadToEnd();
            }

            if (string.IsNullOrEmpty(fileContents))
            {
                throw new Exception(string.Format("fileContents is null for path {0}", path));
            }

            return fileContents;
        }

        private static string GetSourceFileContents(string destinationFilePath, string[] sourceFilePaths)
        {
            string sourceFileContents = null;
            var destinationFileName = new FileInfo(destinationFilePath)?.Name;
            if (!string.IsNullOrEmpty(destinationFileName))
            {
                string sourceFilePath = sourceFilePaths.Where(x => x.Contains(destinationFileName)).FirstOrDefault();
                if (!string.IsNullOrEmpty(sourceFilePath))
                {
                    sourceFileContents = GetFileContents(sourceFilePath);
                }
            }

            return sourceFileContents;
        }

        #endregion

        #region Add New Verbs

        public static void AddNewVerbs(string destinationPath)
        {
            var newVerbs = GetNewVerbs();
            AddNewVerbsToList(newVerbs, destinationPath);
        }

        private static void AddNewVerbsToList(List<Tuple<string, string>> newVerbs, string destinationPath)
        {
            // TODO - implement to add new verbs to file system and verb list inside verb class

            //var sourceFilePaths = Directory.GetFiles(sourceJsonVerbsWithConjugations);
            //var destinationFilePaths = Directory.GetFiles(destinationJsonVerbsWithOutConjugations);

            //var filesUpdatedCtr = 0;
            //var filesNotUpdateCtr = 0;
            //foreach (var destinationFilePath in destinationFilePaths)
            //{
            //    string destinationFileContents = GetFileContents(destinationFilePath);
            //    string sourceFileContents = GetSourceFileContents(destinationFilePath, sourceFilePaths);

            //    if (!string.IsNullOrEmpty(sourceFileContents))
            //    {
            //        var destinationFile = JsonConvert.DeserializeObject<Verb>(sourceFileContents);
            //        var sourceFile = JsonConvert.DeserializeObject<Verb>(sourceFileContents);

            //        destinationFile = Apply(sourceFile, destinationFile);
            //        var destinationFileContentsUpdated = JsonConvert.SerializeObject(destinationFile);

            //        File.WriteAllText(destinationFilePath, destinationFileContentsUpdated);
            //        filesUpdatedCtr++;
            //    }
            //    else
            //    {
            //        Console.WriteLine(string.Format("Unable to update {0}", destinationFilePath));
            //        filesNotUpdateCtr++;
            //    }
            //}

            //Console.WriteLine(string.Format("{0} Files updated", filesUpdatedCtr));
            //Console.WriteLine(string.Format("{0} Files Not updated", filesNotUpdateCtr));
        }

        private static List<Tuple<string, string>> GetNewVerbs()
        {
            var newVerbs = new List<Tuple<string, string>>();

            newVerbs.Add(new Tuple<string, string>("anular", "to cancel"));
            newVerbs.Add(new Tuple<string, string>("devorar", "to devour"));
            newVerbs.Add(new Tuple<string, string>("ladrar", "to bark"));
            newVerbs.Add(new Tuple<string, string>("aflojar", "to loosen up"));
            newVerbs.Add(new Tuple<string, string>("soltar", "to release"));
            newVerbs.Add(new Tuple<string, string>("abortar", "to abort"));
            newVerbs.Add(new Tuple<string, string>("trepar", "to climb"));
            newVerbs.Add(new Tuple<string, string>("chingar", "to fuck"));
            newVerbs.Add(new Tuple<string, string>("asumir", "to assume"));
            newVerbs.Add(new Tuple<string, string>("trapear", "to mop"));
            newVerbs.Add(new Tuple<string, string>("follar", "to fuck"));
            newVerbs.Add(new Tuple<string, string>("follando", "fucking"));
            newVerbs.Add(new Tuple<string, string>("silbar", "to whistle"));
            newVerbs.Add(new Tuple<string, string>("coincidir", "to coincide"));
            newVerbs.Add(new Tuple<string, string>("evitar", "to avoid"));
            newVerbs.Add(new Tuple<string, string>("reprimir", "to suppress"));
            newVerbs.Add(new Tuple<string, string>("tragar", "ro swallow"));
            newVerbs.Add(new Tuple<string, string>("rastrear", "to track"));
            newVerbs.Add(new Tuple<string, string>("burlar", "to evade"));
            newVerbs.Add(new Tuple<string, string>("violar", "to rape"));
            newVerbs.Add(new Tuple<string, string>("castigar", "to punish"));
            newVerbs.Add(new Tuple<string, string>("brindar", "to toast"));
            newVerbs.Add(new Tuple<string, string>("apegar", "to attach"));
            newVerbs.Add(new Tuple<string, string>("desempolvar", "to dust off"));
            newVerbs.Add(new Tuple<string, string>("impedir", "to prevent"));
            newVerbs.Add(new Tuple<string, string>("encargar", "to place an order"));
            newVerbs.Add(new Tuple<string, string>("alimentar", "to food"));
            newVerbs.Add(new Tuple<string, string>("descargar", "to download"));
            newVerbs.Add(new Tuple<string, string>("distinguir", "to distinguish"));
            newVerbs.Add(new Tuple<string, string>("apostar", "to bet"));
            newVerbs.Add(new Tuple<string, string>("nombrar", "to name"));
            newVerbs.Add(new Tuple<string, string>("guiar", "to guide"));
            newVerbs.Add(new Tuple<string, string>("disparar", "to shoot"));
            newVerbs.Add(new Tuple<string, string>("despachar", "to dispense(as a pharmacist in a store, gas at a gas pump)"));
            newVerbs.Add(new Tuple<string, string>("malestar", "discomfort"));
            newVerbs.Add(new Tuple<string, string>("dañar", "to damage"));
            newVerbs.Add(new Tuple<string, string>("calificar", "to qualify"));
            newVerbs.Add(new Tuple<string, string>("echar de reversa", "to backup a car"));
            newVerbs.Add(new Tuple<string, string>("aferrar", "to grasp"));
            newVerbs.Add(new Tuple<string, string>("mantener", "to hold(keep)"));
            newVerbs.Add(new Tuple<string, string>("mezclar", "to mix"));
            newVerbs.Add(new Tuple<string, string>("desvelar", "to reveal"));
            newVerbs.Add(new Tuple<string, string>("burlar", "to outwit"));
            newVerbs.Add(new Tuple<string, string>("agregar", "to add"));
            newVerbs.Add(new Tuple<string, string>("masticar", "to chew on"));
            newVerbs.Add(new Tuple<string, string>("aniquilar", "to annihilate"));
            newVerbs.Add(new Tuple<string, string>("baldear", "to wash down"));
            newVerbs.Add(new Tuple<string, string>("viñedos", "vineyards"));
            newVerbs.Add(new Tuple<string, string>("escoltar", "to escort"));
            newVerbs.Add(new Tuple<string, string>("encargar", "to place an order"));
            newVerbs.Add(new Tuple<string, string>("entregar", "to deliver"));
            newVerbs.Add(new Tuple<string, string>("estirar", "to stretch"));
            newVerbs.Add(new Tuple<string, string>("blindar", "to blind"));
            newVerbs.Add(new Tuple<string, string>("soltar", "to release"));
            newVerbs.Add(new Tuple<string, string>("vencer", "overcome"));
            newVerbs.Add(new Tuple<string, string>("acuchillar", "to stab, to slash"));
            newVerbs.Add(new Tuple<string, string>("envolver(un regalo)", "to wrap(a gift)"));
            newVerbs.Add(new Tuple<string, string>("gruñir", "to snarl"));
            newVerbs.Add(new Tuple<string, string>("redactar", "to write"));
            newVerbs.Add(new Tuple<string, string>("rechazar", "to decline"));
            newVerbs.Add(new Tuple<string, string>("reprobar", "to fail"));
            newVerbs.Add(new Tuple<string, string>("fusilar", "to shoot(firing squad)"));
            newVerbs.Add(new Tuple<string, string>("apresar", "to capture"));

            return newVerbs;
        }

        #endregion
    }
}
