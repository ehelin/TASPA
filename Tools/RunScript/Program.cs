////-------------------------------------------------------------------------
////Script 1
//// TODO - get paths dyanmically
//var listStructuredFilePath = "C:\\EricDocuments\\Spanish\\OldListToConvertToTaspa2.txt";
//var jsonPath = "C:\\EricDocuments\\Spanish\\output";
//var fileName = "JsonDirectoryBllList.txt";
//BLL.Utilities.CreateVocabularyList(listStructuredFilePath, jsonPath);

////-------------------------------------------------------------------------
////Script 2
//using BLL;
//using DAL;
//using Shared.Interfaces;

//// TODO - get paths dyanmically
//var outPath = "C:\\EricDocuments\\Taspa2\\DAL";
//var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\";

//var fileName = "SearchList.cs";

//ITaspaData dataService = new TaspaData();
//ITaspaService businessService = new TaspaService(dataService);
//Utilities.CreateSearchLists(businessService, jsonPath, outPath, fileName);

////-------------------------------------------------------------------------
////Script 3
//using BLL;
//using DAL;
//using Shared.Interfaces;

//ISentenceService sentenceService = new SentenceServiceOne();

//var ctr = 1;
//while(ctr < 10000)
//{
//	var sentence = sentenceService.GenerateSentence();

//	Console.WriteLine(sentence);

//	ctr++;
//}

////-------------------------------------------------------------------------
////Script 4
//// TODO - get paths dyanmically
//var sourceVerbJsonWConjucations = "C:\\EricDocuments\\Personal\\Spanish_07272022\\Spanish\\wwwroot\\Json\\Spanish";
//var destinationVerbJsonWConjucations = "C:\\EricDocuments\\Personal\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\verbs";
//BLL.Utilities.AddPresentTenseConjucationsToExistingVerbList(sourceVerbJsonWConjucations, destinationVerbJsonWConjucations);

//-------------------------------------------------------------------------
//Script 5
var destinationVerbPath = "C:\\EricDocuments\\Personal\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\verbs";
BLL.Utilities.AddNewVerbs(destinationVerbPath);


