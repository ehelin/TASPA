﻿////-------------------------------------------------------------------------
////Script 1
//// TODO - get paths dyanmically
//var listStructuredFilePath = "C:\\EricDocuments\\Personal\\vocabulary.txt";
//var jsonPath =  "C:\\EricDocuments\\Personal\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\vocabulary\\mexico";
//var fileName = "JsonDirectoryBllList.txt";
//BLL.Utilities.CreateVocabularyList(listStructuredFilePath, jsonPath, fileName);

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

////-------------------------------------------------------------------------
////Script 5
//var destinationVerbPath = "C:\\EricDocuments\\Personal\\Taspa2\\TASPA\\wwwroot\\json\\spanish\\verbs";
//BLL.Utilities.AddNewVerbs(destinationVerbPath);

//-------------------------------------------------------------------------
//Script 6
//var inputOutputPath = "C:\\EricDocuments\\Personal\\blogposts\\AI_2\\SentimentAnalysisFiles";
//BLL.Utilities.CreatePositiveNegativeWordLists(inputOutputPath);

//-------------------------------------------------------------------------
//Script 7
//var eng = IronPython.Hosting.Python.CreateEngine();
//var scope = eng.CreateScope();
////eng.Execute(@"def greetings(name): 
////					return 'Hello ' + name.title() + '!'
////			", scope);
//// 
//eng.Execute(@"import sys
//sys.path.append(r'c:\users\erich\appdata\local\programs\python\python310\lib\site-packages')
//sys.path.append(r'C:\Users\erich\AppData\Local\Programs\Python\Python310\Lib\site-packages\transformers')
//#sys.path.append(r'C:\Users\erich\AppData\Local\Programs\Python\Python310\Lib\site-packages\typing_extensions-4.9.0.dist-info')
//sys.path.append(r'C:\Users\erich\AppData\Local\Programs\Python\Python310\Lib\typing2.py)
//from transformers import AutoModelForCausalLM, AutoTokenizer
//import torch

//tokenizer = AutoTokenizer.from_pretrained('microsoft/DialoGPT-large')
//model = AutoModelForCausalLM.from_pretrained('microsoft/DialoGPT-large')

//# Let's chat for 5 lines
//for step in range(500):
//    # encode the new user input, add the eos_token and return a tensor in Pytorch
//    new_user_input_ids = tokenizer.encode(input('>> User:') + tokenizer.eos_token, return_tensors='pt')

//    # append the new user input tokens to the chat history
//    bot_input_ids = torch.cat([chat_history_ids, new_user_input_ids], dim=-1) if step > 0 else new_user_input_ids

//    # generated a response while limiting the total chat history to 1000 tokens, 
//    chat_history_ids = model.generate(bot_input_ids, max_length=1000, pad_token_id=tokenizer.eos_token_id)

//    # pretty print last ouput tokens from bot
//    print('DialoGPT: {}'.format(tokenizer.decode(chat_history_ids[:, bot_input_ids.shape[-1]:][0], skip_special_tokens=True)))", scope);

//dynamic greetings = scope.GetVariable("greetings");
//System.Console.WriteLine(greetings("world"));
using System.Diagnostics;

Main();

void Main()
{
	// Replace "python.exe" with the actual path to your Python interpreter
	string pythonPath = "C:\\Users\\erich\\AppData\\Local\\Programs\\Python\\Python310\\python.exe";
	string scriptPath = "C:\\EricDocuments\\Personal\\Taspa2\\AiModelRunner\\chat.py";

	using (Process process = new Process())
	{
		#region

		process.StartInfo.FileName = pythonPath;
		process.StartInfo.Arguments = scriptPath;
		process.StartInfo.UseShellExecute = false;
		process.StartInfo.RedirectStandardInput = true;
		process.StartInfo.RedirectStandardOutput = true;
		process.StartInfo.CreateNoWindow = true;

		#endregion

		process.Start();

		using (StreamWriter sw = process.StandardInput)
		{
			using (StreamReader sr = process.StandardOutput)
			{
				// Send multiple requests
				for (int i = 0; i < 5; i++)
				{
					// Send input to the Python script
					//sw.WriteLine($"Request {i}");
					sw.WriteLine("How do you feel?");

					// Receive and process the response
					string response = sr.ReadLine();
					Console.WriteLine($"Response {i}: {response}");
				}

				// Optionally, you can send a termination signal
				sw.WriteLine("exit");
			}
		}

		process.WaitForExit();
	}
}