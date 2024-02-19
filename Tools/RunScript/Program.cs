////-------------------------------------------------------------------------
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

////-------------------------------------------------------------------------
////Script 7 (mostly from ChatGPT)
//using System.Diagnostics;

//Main();

//void Main()
//{
//	// Replace "python.exe" with the actual path to your Python interpreter
//	string pythonPath = "C:\\Users\\erich\\AppData\\Local\\Programs\\Python\\Python310\\python.exe";
//	string scriptPath = "C:\\EricDocuments\\Personal\\Taspa2\\AiModelRunner\\chat.py";

//	using (Process process = new Process())
//	{
//		#region

//		process.StartInfo.FileName = pythonPath;
//		process.StartInfo.Arguments = scriptPath;
//		process.StartInfo.UseShellExecute = false;
//		process.StartInfo.RedirectStandardInput = true;
//		process.StartInfo.RedirectStandardOutput = true;
//		process.StartInfo.CreateNoWindow = true;

//		#endregion

//		process.Start();

//		using (StreamWriter sw = process.StandardInput)
//		{
//			using (StreamReader sr = process.StandardOutput)
//			{
//				// Send multiple requests
//				for (int i = 0; i < 5; i++)
//				{
//					// Send input to the Python script
//					//sw.WriteLine($"Request {i}");
//					sw.WriteLine("How do you feel?");

//					// Receive and process the response
//					string response = sr.ReadLine();
//					Console.WriteLine($"Response {i}: {response}");
//				}

//				// Optionally, you can send a termination signal
//				sw.WriteLine("exit");
//			}
//		}

//		process.WaitForExit();
//	}
//}

//-------------------------------------------------------------------------
//Script 8
using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;

class Program
{
	private static string message = string.Empty;
	private static string response = string.Empty;
	private static bool exit = false;

	static void Main()
	{
		// Start a new thread for the background process
		Thread backgroundThread = new Thread(BackgroundProcessThreadMethod);
		backgroundThread.Start();

		// Start a new thread for the API server
		Thread apiThread = new Thread(ApiServerThreadMethod);
		apiThread.Start();

		// Continue with the main thread or perform other tasks

		// Wait for the background process and API server threads to finish (which won't happen in this case)
		backgroundThread.Join();
		apiThread.Join();

		Console.WriteLine("Main thread exiting.");
	}

	static void BackgroundProcessThreadMethod()
	{
		// Replace "python.exe" with the actual path to your Python interpreter
		string pythonPath = "C:\\Users\\erich\\AppData\\Local\\Programs\\Python\\Python310\\python.exe";
		string scriptPath = "C:\\EricDocuments\\Personal\\Taspa2\\AiModelRunner\\chatLlama2.py";

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

			Console.WriteLine($"Python Wrapper Script: starting!");

			using (StreamWriter sw = process.StandardInput)
			{
				using (StreamReader sr = process.StandardOutput)
				{
					while (!exit)
					{
						if (exit)
						{
							sw.WriteLine("exit");
						}
						if (!string.IsNullOrEmpty(message))
						{
							Console.WriteLine($"Python Wrapper Script: Received message - {message}");
							sw.WriteLine(message);

							while (string.IsNullOrEmpty(response))
							{
								// Receive and process the response
								response = sr.ReadLine();

								Thread.Sleep(500);
							}
							
							message = string.Empty;
							Console.WriteLine($"Python Wrapper Script: Received response - {response}");
						}
						Thread.Sleep(500);
					}
				}
			}

			process.WaitForExit();
		}
	}

	static void ApiServerThreadMethod()
	{
		// Define the base URL for the API server
		string apiUrl = "http://localhost:8080/";
		HttpListener listener = new HttpListener();

		try
		{
			// Add the URL prefixes to the listener
			listener.Prefixes.Add(apiUrl);

			listener.Start();

			Console.WriteLine("API server started. Listening for requests...");

			while (true)
			{
				// Wait for an incoming request
				HttpListenerContext context = listener.GetContext();
				ThreadPool.QueueUserWorkItem(HandleRequest, context);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"An error occurred: {ex.Message}");
		}
		finally
		{
			// Stop the listener in case of any exceptions
			listener.Stop();
		}
	}

	static void HandleRequest(object state)
	{
		HttpListenerContext context = (HttpListenerContext)state;

		// Read the request
		string requestMethod = context.Request.HttpMethod;
		string requestUrl = context.Request.Url.ToString();
		Console.WriteLine($"HandleRequest: Received {requestMethod} request for {requestUrl}");

		// Extract GET parameters from the URL
		string paramName = "message"; // Change this to your parameter name
		string paramValue = context.Request.QueryString[paramName];

		// Process the request and send input to the background process
		string requestData = new StreamReader(context.Request.InputStream).ReadToEnd();
		Console.WriteLine($"HandleRequest: Request data: {requestData}");
		Console.WriteLine($"GET Parameter '{paramName}': {paramValue}");

		// Replace this with your logic to send input to the background process
		// For simplicity, we're just printing the received data and parameter here
		Console.WriteLine($"HandleRequest: Sending input to the background process: {requestData}");

		message = paramValue;

		while (string.IsNullOrEmpty(response)) { }

		Console.WriteLine($"HandleRequest: Received response: {response}");

		// Prepare the response
		//string responseString = $"API Response: Request received! Parameter '{paramName}' value: {paramValue}";
		byte[] buffer = Encoding.UTF8.GetBytes(response);

		response = string.Empty;

		// Send the response
		context.Response.ContentLength64 = buffer.Length;
		context.Response.OutputStream.Write(buffer, 0, buffer.Length);
		context.Response.Close();

		Console.WriteLine($"HandleRequest: Response sent!");
	}
}
