////Script 1
//// TODO - get paths dyanmically
//var listStructuredFilePath = "C:\\EricDocuments\\Spanish\\OldListToConvertToTaspa2.txt";
//var jsonPath = "C:\\EricDocuments\\Spanish\\output";
//var fileName = "JsonDirectoryBllList.txt";
//BLL.Utilities.CreateVocabularyList(listStructuredFilePath, jsonPath);

//Script 2
using BLL;
using DAL;
using Shared.Interfaces;

// TODO - get paths dyanmically
var outPath = "C:\\EricDocuments\\Taspa2\\DAL";
var jsonPath = "C:\\EricDocuments\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\";

var fileName = "SearchList.cs";

ITaspaData dataService = new TaspaData();
ITaspaService businessService = new TaspaService(dataService);
Utilities.CreateSearchLists(businessService, jsonPath, outPath, fileName);