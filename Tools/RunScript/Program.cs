////Script 1
//// TODO - get paths dyanmically
//var listStructuredFilePath = "C:\\EricDocuments\\Spanish\\OldListToConvertToTaspa2.txt";
//var jsonPath = "C:\\EricDocuments\\Spanish\\output";
//BLL.Utilities.CreateVocabularyList(listStructuredFilePath, jsonPath);

//Script 2
using BLL;
using DAL;
using Shared.Interfaces;

ITaspaData dataService = new TaspaData();
ITaspaService businessService = new TaspaService(dataService);
Utilities.CreateSearchLists(businessService);