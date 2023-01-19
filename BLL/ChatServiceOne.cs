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

		private int lastUsedIndex = 0;                   // record last index to help with creating interesting responses
		private List<string> alreadyUsedResponses;       // remember responses to at least for this session, we do not send same response

		// objects used to secure the chat user's name and use it in some generated responses
		private Random chatUserNameRandom;
		private List<int> rangeForChatUserNamePrompts;
		private string chatUserName;
		private int chatUserNamePromptIndex;                        // range (lastUsedIndex) when a chat user name prompt will occur
		private Random useChatUserNameIndexRandom;
		private int useChatUserNameIndex;

		private readonly Random alphabetRandom;
		private readonly List<string> alphabet;

		private readonly Random chatUserNameResponsesRandom;
		private readonly List<string> chatUserNameResponses;

		private readonly ISentenceService sentenceService;

		private readonly bool isTest;

		public ChatServiceOne(ISentenceService sentenceService, bool isTest = false)
		{
			this.alphabet = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
			this.alphabetRandom = new Random();
			
			this.isTest = isTest;

			chatUserNameResponsesRandom = new Random();
			this.chatUserNameResponses = InitializeChatNameUserCannedResponses();

			this.sentenceService = sentenceService;

			rangeForChatUserNamePrompts = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, };
			chatUserNameRandom = new Random();
			chatUserNamePromptIndex = rangeForChatUserNamePrompts[chatUserNameRandom.Next(0, rangeForChatUserNamePrompts.Count())];

			useChatUserNameIndexRandom = new Random();

			alreadyUsedResponses = new List<string>();
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
				if (!this.alreadyUsedResponses.Any(x => x == response)) { break; }
				else { response = ""; }

				recordedChatDialog = GetRecordedChatDialog(dataPath);	// re-read in saved dialog for fresh evaluations of generated dialog
				ctr++;
			}

			if (string.IsNullOrEmpty(response)) 
			{ 
				throw new Exception("Cannot have a empty response"); 
			}

			this.alreadyUsedResponses.Add(response);  // remember every phrase so no duplicates this session.
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
			if (this.lastUsedIndex == this.chatUserNamePromptIndex && string.IsNullOrEmpty(this.chatUserName)) 
			{
				response = ChatServiceOne.REQUEST_CHAT_USER_MESSAGE;
			}
			// set chat user name if returned after requested
			else if (string.IsNullOrEmpty(this.chatUserName) 
				&& this.alreadyUsedResponses.Count() > 0 
					&& this.alreadyUsedResponses.Last() == ChatServiceOne.REQUEST_CHAT_USER_MESSAGE)
			{
				this.chatUserName = chatMessage;
				response = "Well hello there!";  // One of only a few hard coded messages

				//set usage index (sometime in the next 20 iterations
				useChatUserNameIndex = useChatUserNameIndexRandom.Next(this.lastUsedIndex+1, (this.lastUsedIndex + 1) + MAX_USER_CHAT_NAME_RANDOM_INDEX);
			}
			// once chat user name is set, use chat user name in some responses at various intervals
			else if (!string.IsNullOrEmpty(this.chatUserName)											//user name is set
				&& this.alreadyUsedResponses.Count() > 0												//not the first response
					&& this.alreadyUsedResponses.Last() != ChatServiceOne.REQUEST_CHAT_USER_MESSAGE		//chat user name request was not the last request
						&& this.alreadyUsedResponses.Last().IndexOf(this.chatUserName) == -1			//chat user name was not in last request
							&& this.lastUsedIndex == this.useChatUserNameIndex)							//current index matches next expected chat user response index
			{
				this.chatUserName = chatMessage;

				var responseFromList = this.chatUserNameResponses[this.chatUserNameResponsesRandom.Next(0, this.chatUserNameResponses.Count())];
				response = string.Format("{0}, {1}?", this.chatUserName, responseFromList.ToLower());

				//set usage index (sometime in the next 20 iterations
				useChatUserNameIndex = useChatUserNameIndexRandom.Next(this.lastUsedIndex + 1, (this.lastUsedIndex + 1) + MAX_USER_CHAT_NAME_RANDOM_INDEX);
			}
			// skip chat user response since (if we got here)
			else if (this.lastUsedIndex == this.useChatUserNameIndex && !response.StartsWith(this.chatUserName))
			{
				//set usage index (sometime in the next 20 iterations
				useChatUserNameIndex = useChatUserNameIndexRandom.Next(this.lastUsedIndex + 1, (this.lastUsedIndex + 1) + MAX_USER_CHAT_NAME_RANDOM_INDEX);
			}

			//--------------------------------------------------------------------------------------------------------------
			//  see if we can get a response from previously recorded conversation messages
			if (string.IsNullOrEmpty(response))
			{
				response = GetResponseFromRecordedChatDialog(recordedChatDialog, dataPath);

				// do not re-use a response
				if (this.alreadyUsedResponses.Any(x => x == response)) { response = ""; }
			}

			//---------------------------------------------------------------------------------------------------------------
			// if no response from previously recorded or user based messages, generate a sentence since we are out of chat service options
			if (string.IsNullOrEmpty(response))
			{
				response = this.sentenceService.GenerateSentence();

				// do not re-use a response
				if (this.alreadyUsedResponses.Any(x => x == response)) { response = ""; }
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
				if (this.lastUsedIndex == 0 && !ChatDialogExists(recordedChatDialog[1], dataPath)) { return recordedChatDialog[1]; }

				// loop thru previously recorded messages and attempt to generate new response
				var recordedChatDialogCtr = 1;
				foreach (var chatDialog in recordedChatDialog)
				{
					//===============================================================================================
					// multiple messages, last used exceeds list of responses, return last recorded entry
					var lastEntry = recordedChatDialog[recordedChatDialog.Length - 1];
					if (this.lastUsedIndex > recordedChatDialog.Length && !ChatDialogExists(lastEntry, dataPath) && !string.IsNullOrEmpty(response)) { return lastEntry; }

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

		private List<string> InitializeChatNameUserCannedResponses()
		{
			var list = new List<string>();

			list.Add("What are you passionate about");
			list.Add("What city do you live in");
			list.Add("What is on your reading list");
			list.Add("Favorite food");
			list.Add("Favorite color");
			list.Add("Do you have any day dreams");
			list.Add("Do you have pet peeves");
			list.Add("Regrets");
			list.Add("What classes would be on your to take list if you had time");
			list.Add("Is there a fictional character you can relate to");
			list.Add("Favorite city that you have lived in");
			list.Add("Favorite sport");
			list.Add("Do you have a dream job");
			list.Add("What type of restaurant do you like to eat in");
			list.Add("Coffee or tea");
			list.Add("Do you like you coffee with milk");
			list.Add("Do you grind your own coffee beans");
			list.Add("Favorite music");
			list.Add("Do you work late");
			list.Add("Are you a morning or night person");
			list.Add("Any nicknames");
			list.Add("Best concert you have been too");
			list.Add("Favorite group");
			list.Add("Are you a minimalist");
			list.Add("Do you like to shop");
			list.Add("Are you an athlete");
			list.Add("What do you do for exercise");
			list.Add("What type of gifts do you give at Christmas");
			list.Add("What do you do in your off hours");
			list.Add("Do you vacation a lot");
			list.Add("Do you have a daily routine");
			list.Add("Nightly routine");
			list.Add("Have you worked with great people");
			list.Add("Are you in technology");
			list.Add("What do you look for in a great company to work for");
			list.Add("Do you like chat bots");
			list.Add("What motivates you");
			list.Add("Are you rich");
			list.Add("If you were rich, how would you spend your time");
			list.Add("Favorite author");
			list.Add("Do you collect");
			list.Add("Do you speak a language");
			list.Add("Do you run");
			list.Add("Do you bike");
			list.Add("What is your politics");
			list.Add("Are you a Democrat");
			list.Add("Are you a Republican");
			list.Add("Do you follow politics in other countries");
			list.Add("Do you fondu?");
			list.Add("Do you think");
			list.Add("Do you drive");
			list.Add("Do you eat");
			list.Add("Favorite pet");
			list.Add("Favorite pen");
			list.Add("Favorite pencil");
			list.Add("Favorite state");
			list.Add("Favorite country");
			list.Add("Favorite ocean");
			list.Add("Favorite school");
			list.Add("Did you go to college");

			return list;
		}

		#endregion

		#endregion
	}
}