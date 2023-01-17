using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Shared.Interfaces;

namespace BLL
{
	/// <summary>
	/// A chat bot implementation that uses previously recorded messages/responses and text manipulation to create responses. It is intended as a rudimentary first step
	/// on how a chat bot works and lead to more complex implementations on my personal educational journey.
	/// 
	/// Text Manipulations
	/// 1) Previously recorded dialog w/spaces...straight or reversed depending on loop counter mod calculation
	/// 2) Using alphabet array, getting a random letter and pulling a previously recorded message that starts with it
	/// 3) Using sentence generator
	/// 4) Securing the chat user's name and using it in some generated responses
	/// 
	/// Implementation One.
	/// 
	/// </summary>
	public class ChatServiceOne : IChatService
	{
		public const int MAX_COUNTER = 1000;
		public const int MAX_USER_CHAT_NAME_RANDOM_INDEX = 10;  // reset after each user name response to (lastUsedIndex+1) + MAX_USER_CHAT_NAME_RANDOM_INDEX 
		public const string REQUEST_CHAT_USER_MESSAGE = "What is your name?";
		public const string CHATTER = "Chat User";
		public const string CHATBOT_NAME = "Taspa";
		public const string TEST_CHATBOT_USER = "FredTheChatUser";

		private static int lastUsedIndex = 0;                   // record last index to help with creating interesting responses
		private static List<string> alreadyUsedResponses;       // remember responses to at least for this session, we do not send same response

		// objects used to secure the chat user's name and use it in some generated responses
		private static Random chatUserNameRandom;
		private static List<int> rangeForChatUserNamePrompts;
		private static string chatUserName;
		private static int chatUserNamePromptIndex;                        // range (lastUsedIndex) when a chat user name prompt will occur
		private static Random useChatUserNameIndexRandom;
		private static int useChatUserNameIndex;

		// TODO - call this method from webapp app each time system is deployed
		public static void Initialize()
		{
			rangeForChatUserNamePrompts = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, };
			chatUserNameRandom = new Random();
			chatUserNamePromptIndex = rangeForChatUserNamePrompts[chatUserNameRandom.Next(0, rangeForChatUserNamePrompts.Count())];

			useChatUserNameIndexRandom = new Random();

			alreadyUsedResponses = new List<string>();
		}

		private readonly Random alphabetRandom;
		private readonly List<string> alphabet;
		private readonly ISentenceService sentenceService;
		private readonly bool isTest;

		public ChatServiceOne(ISentenceService sentenceService, bool isTest = false)
		{
			this.alphabet = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
			this.alphabetRandom = new Random();
			
			this.isTest = isTest;

			this.sentenceService = sentenceService;
		}

		public string GetMessageResponse(string webRoot, string chatMessage)
		{
			var response = "";
			var dataPath = string.Format("{0}\\{1}", webRoot, "chat\\data.txt");
			var recordedChatDialog = GetRecordedChatDialog(dataPath);

			var ctr = 1;
			while(ctr < MAX_COUNTER)
			{
				response = GetResponse(recordedChatDialog, chatMessage, dataPath);

				// Do not re-use anything already used in this session...if new, use this response
				if (!ChatServiceOne.alreadyUsedResponses.Any(x => x == response)) { break; }
				else { response = ""; }

				recordedChatDialog = GetRecordedChatDialog(dataPath);	// re-read in saved dialog for fresh evaluations of generated dialog
				ctr++;
			}

			if (string.IsNullOrEmpty(response)) 
			{ 
				throw new Exception("Cannot have a empty response"); 
			}

			ChatServiceOne.alreadyUsedResponses.Add(response);  // remember every phrase so no duplicates this session.
			lastUsedIndex++;

			response = AddChatterChatBoxNames(chatMessage, response);

			return response;
		}

		#region private methods

		#region response generation methods

		private string GetResponse(string[] recordedChatDialog, string chatMessage, string dataPath)
		{
			string response = string.Empty;

			// if previously recorded messages, create a response from them
			if (recordedChatDialog != null && recordedChatDialog.Length > 0)
			{
				response = GetChatServiceResponse(recordedChatDialog, dataPath, chatMessage);
			}
			// if no recorded messages, return sent message
			else
			{
				response = chatMessage;
			}

			// only record new messages and responses (used or not used)
			if (!this.isTest && chatMessage.IndexOf(TEST_CHATBOT_USER) == -1 && !recordedChatDialog.Any(x => x == chatMessage)) 
			{ 
				RecordChatDialog(dataPath, chatMessage); 
			}
			if (!this.isTest && response.IndexOf(TEST_CHATBOT_USER) == -1 && !recordedChatDialog.Any(x => x == response)) 
			{ 
				RecordChatDialog(dataPath, response); 
			}

			return response;
		}

		private string GetChatServiceResponse(string[] recordedChatDialog, string dataPath, string chatMessage)
		{
			var response = "";

			//---------------------------------------------------------------------------------------------------------------
			// chat user name request/response types (on an interval, request user name and once set, periodically use it)
			// at the right index, request chat user name
			if (ChatServiceOne.lastUsedIndex == ChatServiceOne.chatUserNamePromptIndex && string.IsNullOrEmpty(ChatServiceOne.chatUserName)) 
			{
				response = ChatServiceOne.REQUEST_CHAT_USER_MESSAGE;
			}
			// set chat user name if returned after requested
			else if (string.IsNullOrEmpty(ChatServiceOne.chatUserName) 
				&& ChatServiceOne.alreadyUsedResponses.Count() > 0 
					&& ChatServiceOne.alreadyUsedResponses.Last() == ChatServiceOne.REQUEST_CHAT_USER_MESSAGE)
			{
				ChatServiceOne.chatUserName = chatMessage;
				response = "Well hello there!";  // One of only a few hard coded messages

				//set usage index (sometime in the next 20 iterations
				useChatUserNameIndex = useChatUserNameIndexRandom.Next(ChatServiceOne.lastUsedIndex+1, (ChatServiceOne.lastUsedIndex + 1) + MAX_USER_CHAT_NAME_RANDOM_INDEX);
			}
			// once chat user name is set, use chat user name in some responses at various intervals
			else if (!string.IsNullOrEmpty(ChatServiceOne.chatUserName) 
				&& ChatServiceOne.alreadyUsedResponses.Count() > 0 
					&& ChatServiceOne.alreadyUsedResponses.Last() != ChatServiceOne.REQUEST_CHAT_USER_MESSAGE
						&& ChatServiceOne.lastUsedIndex == ChatServiceOne.useChatUserNameIndex)
			{
				ChatServiceOne.chatUserName = chatMessage;
				var generatedResponse = this.sentenceService.GenerateSentence();
				response = string.Format("{0}, {1}{2}", ChatServiceOne.chatUserName, generatedResponse, "?");

				//set usage index (sometime in the next 20 iterations
				useChatUserNameIndex = useChatUserNameIndexRandom.Next(ChatServiceOne.lastUsedIndex + 1, (ChatServiceOne.lastUsedIndex + 1) + MAX_USER_CHAT_NAME_RANDOM_INDEX);
				var test = 1;
			}

			//--------------------------------------------------------------------------------------------------------------
			//  see if we can get a response from previously recorded conversation messages
			if (string.IsNullOrEmpty(response))
			{
				response = GetResponseFromRecordedChatDialog(recordedChatDialog, dataPath);

				// do not re-use a response
				if (ChatServiceOne.alreadyUsedResponses.Any(x => x == response)) { response = ""; }
			}

			//---------------------------------------------------------------------------------------------------------------
			// if no response from previously recorded or user based messages, generate a sentence since we are out of chat service options
			if (string.IsNullOrEmpty(response))
			{
				response = this.sentenceService.GenerateSentence();

				// do not re-use a response
				if (ChatServiceOne.alreadyUsedResponses.Any(x => x == response)) { response = ""; }
			}

			return response;
		}

		private string GetResponseFromRecordedChatDialog(string[] recordedChatDialog, string dataPath)
		{
			var response = "";

			// if only one recorded message, return sent it
			if (recordedChatDialog.Length == 1 && !ChatDialogExists(recordedChatDialog[0], dataPath)) { return recordedChatDialog[0]; }
			else
			{
				// if first call and multiple messages, return second recorded message
				if (ChatServiceOne.lastUsedIndex == 0 && !ChatDialogExists(recordedChatDialog[1], dataPath)) { return recordedChatDialog[1]; }

				// loop thru previously recorded messages and attempt to generate new response
				var recordedChatDialogCtr = 1;
				foreach (var chatDialog in recordedChatDialog)
				{
					//===============================================================================================
					// multiple messages, last used exceeds list of responses, return last recorded entry
					var lastEntry = recordedChatDialog[recordedChatDialog.Length - 1];
					if (ChatServiceOne.lastUsedIndex > recordedChatDialog.Length && !ChatDialogExists(lastEntry, dataPath) && !string.IsNullOrEmpty(response)) { return lastEntry; }

					//===============================================================================================
					//find response if current previously recorded message has spaces (reversing or not based on current loop counter)
					response = GetResponseFromRecordedDialogWithSpaces(chatDialog, recordedChatDialogCtr % 2 == 0 ? true : false, dataPath);
					if (!string.IsNullOrEmpty(response)) { return response; }  // Exit if we get a response

					//===============================================================================================
					//find response if if current previously recorded message has starts with the first letter of the alphabet in a loop
					var randomAlpabet = this.alphabet[alphabetRandom.Next(0, this.alphabet.Count())];
					response = recordedChatDialog.Where(x => x.ToLower().StartsWith(randomAlpabet.ToLower())).FirstOrDefault();
					if (!string.IsNullOrEmpty(response) && !ChatDialogExists(response, dataPath)) { return response; }

					// TODO - add more text manipulations to create new responses

					recordedChatDialogCtr++;
				}
			}

			return response;
		}

		#endregion

		#region response creation helper methods

		private string[] GetRecordedChatDialog(string dataPath)
		{
			var previouslyRecordedChatMessages = System.IO.File.ReadAllLines(dataPath);

			return previouslyRecordedChatMessages;
		}

		private bool ChatDialogExists(string chatDialog, string dataPath)
		{
			var previouslyRecordedChatMessages = GetRecordedChatDialog(dataPath);

			if (previouslyRecordedChatMessages.Any(x => x == chatDialog))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private string AddChatterChatBoxNames(string chatMessage, string response)
		{
			var sb = new StringBuilder();

			sb.AppendLine(string.Format("{0}: {1}", CHATTER, chatMessage));
			sb.AppendLine(string.Format("{0}: {1}", CHATBOT_NAME, response));

			return sb.ToString();
		}

		private string GetResponseFromRecordedDialogWithSpaces(string recordedChatDialog, bool reverse, string dataPath)
		{
			var response = "";

			if (recordedChatDialog.IndexOf(" ") != -1)
			{
				if (reverse)
				{
					var dialog = recordedChatDialog.Split(" ");
					var stack = new Stack();
					foreach (var chatDialog in dialog)
					{
						stack.Push(chatDialog);
					}
					var sb = new StringBuilder();

					var enumerator = stack.GetEnumerator();
					while (enumerator.MoveNext())
					{
						sb.Append(enumerator.Current.ToString() + " ");
					}
					response = sb.ToString().Trim();
				}
				else
				{
					response = recordedChatDialog;
				}
			}

			if (ChatDialogExists(response, dataPath))
			{
				response = "";
			}

			return response;
		}

		private void RecordChatDialog(string dataPath, string chatMessage)
		{
			using (var chatData = new StreamWriter(dataPath, true))
			{
				chatData.WriteLine(chatMessage);
				chatData.Flush();
				chatData.Close();
			}
		}

		#endregion

		#endregion
	}
}