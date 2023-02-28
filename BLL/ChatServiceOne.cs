using System;
using System.Collections;
using Shared.Dto.Chat;
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
		public const int MAX_USER_CHAT_NAME_RANDOM_INDEX = 10;  // reset after each user name response to (lastUsedIndex+1) + MAX_USER_CHAT_NAME_RANDOM_INDEX 
		public const string REQUEST_CHAT_USER_MESSAGE = "What is your name?";
		public const string CHAT_USER_NAME_IS_SET_MESSAGE = "Well hello there!";
		public const string CHATTER = "Chat User";
		public const string CHATBOT_NAME = "Taspa";
		public const string TEST_CHATBOT_USER = "FredTheChatUser";

		private const int MAX_COUNTER = 1000;

		private int lastUsedIndex = 0;                   // record last index to help with creating interesting responses
		private List<string> alreadyUsedResponses;       // remember responses to at least for this session, we do not send same response

		// objects used to secure the chat user's name and use it in some generated responses
		private Random chatUserNameRandom;
		private List<int> rangeForChatUserNamePrompts;
		private string chatUserName;
		private int chatUserNamePromptIndex;                        // range (lastUsedIndex) when a chat user name prompt will occur
		private Random useChatUserNameIndexRandom;
		private int useChatUserNameIndex;

		private Random alphabetRandom;
		private List<string> alphabet;

		private Random chatUserNameResponsesRandom;
		private List<string> chatUserNameResponses;

		private ISentenceService sentenceService;

		private bool isTest;

		private bool chatNameIsSet = false;
	
		// allowed response types...iterate over to vary responses
		private ChatResponseType currentResponseType;
		private int currentResponseTypeIndex;

		public ChatResponseType GetCurrentResponseType() { return this.currentResponseType; }

		public ChatServiceOne(ISentenceService sentenceService, bool isTest = false)
        {
            this.sentenceService = sentenceService;
            this.isTest = isTest;

			Initialize();
        }

		private void Initialize()
        {
            this.alphabet = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            this.alphabetRandom = new Random();

            chatUserNameResponsesRandom = new Random();
            this.chatUserNameResponses = InitializeChatNameUserCannedResponses();

            //set the initial response type (once per season) and then iterate through so one type of answer is used at different intervals
            var currentResponseTypeRandom = new Random();
            ChatResponseType[] chatResponseTypes = Enum.GetValues<ChatResponseType>();
            var randomIndex = currentResponseTypeRandom.Next(0, 2);
            this.currentResponseType = chatResponseTypes[randomIndex];
            this.currentResponseTypeIndex = randomIndex;

            rangeForChatUserNamePrompts = new List<int>() { 1, 2, 3, 4, 5 };
            chatUserNameRandom = new Random();
            chatUserNamePromptIndex = rangeForChatUserNamePrompts[chatUserNameRandom.Next(0, rangeForChatUserNamePrompts.Count())];

            useChatUserNameIndexRandom = new Random();

            alreadyUsedResponses = new List<string>();

			this.chatNameIsSet = false;
			this.chatUserName = null;
        }

		public void ClearChatSession()
		{
			Initialize();
        }

		public string GetMessageResponse(string webRoot, string chatMessage)
		{
			var response = "";
			var dataPath = string.Format("{0}\\{1}", webRoot, "chat\\data.txt");
			var recordedChatDialog = GetRecordedChatDialog(dataPath);
			SetChatResponseType();

			var ctr = 1;
			while(ctr < MAX_COUNTER)
			{
				response = GetResponse(recordedChatDialog, chatMessage, dataPath);

				// Do not re-use anything already used in this session...if new, use this response
				if (!string.IsNullOrEmpty(response) && !this.alreadyUsedResponses.Any(x => x == response)) 
				{ 
					break; 
				}
				else
				{
					SetChatResponseType(); // No response, change the type.
					response = ""; 
				}

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

			response = GetChatServiceResponse(recordedChatDialog, dataPath, chatMessage);

			// only record new messages from chat user
			if (!this.isTest && chatMessage.IndexOf(TEST_CHATBOT_USER) == -1 && !recordedChatDialog.Any(x => x == chatMessage)) 
			{ 
				RecordChatDialog(dataPath, chatMessage); 
			}

			return response;
		}

		private string GetChatServiceResponse(string[] recordedChatDialog, string dataPath, string chatMessage)
		{
			var response = "";

			//--------------------------------------------------------------------------------------------------------------
			// wait for chat user's name to be obtained and then rely on chat response types to determine response category used
			if (string.IsNullOrEmpty(this.chatUserName) || (!string.IsNullOrEmpty(this.chatUserName) && this.currentResponseType == ChatResponseType.ChatUserName))
			{
				response = GetResponseFromChatUserBasedResponses(response, chatMessage);
			}

			//--------------------------------------------------------------------------------------------------------------
			// wait for chat user's name to be obtained and then rely on chat response types to determine response category used
			if ((string.IsNullOrEmpty(response) && string.IsNullOrEmpty(this.chatUserName)) || (!string.IsNullOrEmpty(this.chatUserName) && this.currentResponseType == ChatResponseType.Recorded))
			{
				response = GetResponseFromRecordedChatDialog(recordedChatDialog, dataPath);

				// do not re-use a response
				if (this.alreadyUsedResponses.Any(x => x == response)) { response = ""; }
			}

			//---------------------------------------------------------------------------------------------------------------
			// wait for chat user's name to be obtained and then rely on chat response types to determine response category used
			if ((string.IsNullOrEmpty(response) && string.IsNullOrEmpty(this.chatUserName)) || (!string.IsNullOrEmpty(this.chatUserName) && this.currentResponseType == ChatResponseType.Generated))
			{
				response = this.sentenceService.GenerateSentence();

				// do not re-use a response
				if (this.alreadyUsedResponses.Any(x => x == response)) { response = ""; }
			}

			// NOTE: Special Case...set chat message after detected, but passed this interation of response generation
			// (i.e. don't prematurely start using response type's)
			if (response == ChatServiceOne.CHAT_USER_NAME_IS_SET_MESSAGE && !this.chatNameIsSet)
			{
				this.chatUserName = chatMessage;
				this.chatNameIsSet = true;
			}

			return response;
		}

		private string GetResponseFromChatUserBasedResponses(string response, string chatMessage)
		{
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
				//this.chatUserName = chatMessage;
				response = ChatServiceOne.CHAT_USER_NAME_IS_SET_MESSAGE;

				//set usage index (sometime in the next 20 iterations
				useChatUserNameIndex = useChatUserNameIndexRandom.Next(this.lastUsedIndex + 1, (this.lastUsedIndex + 1) + MAX_USER_CHAT_NAME_RANDOM_INDEX);
			}
			// once chat user name is set, use chat user name in some responses at various intervals
			else if (!string.IsNullOrEmpty(this.chatUserName))         //user name is set
			{
				var responseFromList = this.chatUserNameResponses[this.chatUserNameResponsesRandom.Next(0, this.chatUserNameResponses.Count())];
				responseFromList = string.Format("{0}{1}", responseFromList.Substring(0, 1).ToLower(), responseFromList.Substring(1, responseFromList.Length - 1));
				response = string.Format("{0}, {1}?", this.chatUserName, responseFromList);
			}

			return response;
		}

		private string GetResponseFromRecordedChatDialog(string[] recordedChatDialog, string dataPath)
		{
			var response = "";

			// if only one recorded message, return sent it
			if (recordedChatDialog.Length == 1 && !ChatDialogExists(recordedChatDialog[0], dataPath)) 
			{
				response = recordedChatDialog[0];
				return response;
			}
			else
			{
				// if first call and multiple messages, return second recorded message
				if (!string.IsNullOrEmpty(response) && this.lastUsedIndex == 0 && !ChatDialogExists(recordedChatDialog[1], dataPath)) 
				{
					response = recordedChatDialog[1]; 
					return response;
				}

				// loop thru previously recorded messages and attempt to generate new response
				var recordedChatDialogCtr = 1;
				foreach (var chatDialog in recordedChatDialog)
				{
					//===============================================================================================
					//find response if current previously recorded message has space
					response = GetResponseFromRecordedDialogWithSpaces(chatDialog, dataPath);
					if (!string.IsNullOrEmpty(response) && !ChatDialogExists(response, dataPath)) 
					{
						return response; 
					} 

					//===============================================================================================
					//find response if current previously recorded message starts with the first letter of the alphabet in a loop
					var randomAlpabetStart = this.alphabet[alphabetRandom.Next(0, this.alphabet.Count())];
					response = recordedChatDialog.Where(x => x.ToLower().StartsWith(randomAlpabetStart.ToLower())).FirstOrDefault();
					if (!string.IsNullOrEmpty(response) && !ChatDialogExists(response, dataPath)) 
					{ 
						return response; 
					}

					//===============================================================================================
					//find response if current previously recorded message starts with the first letter of the alphabet in a loop
					var randomAlpabetEnd = this.alphabet[alphabetRandom.Next(0, this.alphabet.Count())];
					response = recordedChatDialog.Where(x => x.ToLower().EndsWith(randomAlpabetEnd.ToLower())).FirstOrDefault();
					if (!string.IsNullOrEmpty(response) && !ChatDialogExists(response, dataPath))
					{
						return response;
					}

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

			var chatUser = !string.IsNullOrEmpty(this.chatUserName) ? this.chatUserName : CHATTER;
			sb.AppendLine(string.Format("{0}: {1}", chatUser, chatMessage));
			sb.AppendLine(string.Format("{0}: {1}", CHATBOT_NAME, response));

			return sb.ToString();
		}

		private string GetResponseFromRecordedDialogWithSpaces(string recordedChatDialog, string dataPath)
		{
			var response = "";

			if (recordedChatDialog.IndexOf(" ") != -1)
			{
				response = recordedChatDialog;
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
			list.Add("Have you done a cruise");
			list.Add("Have you gone abroad");
			list.Add("Have you been to Russia");
			list.Add("Have you been to France");
			list.Add("Have you been to Spain");
			list.Add("Have you been to America");
			list.Add("Have you been to Britain");
			list.Add("Have you been to Germany");
			list.Add("Have you been to Peru");
			list.Add("Have you been to Chile");
			list.Add("Have you been to Africa");
			list.Add("Have you been to Australia");
			list.Add("Have you been to Tasmania");
			list.Add("Have you been to Anartica");
			list.Add("Have you been to Scotland");
			list.Add("Have you been to Portugal");
			list.Add("Have you been to Nigeria");
			list.Add("Do you swim");
			list.Add("Do you know the backstroke");
			list.Add("Where were you born");
			list.Add("Where was your mother born");
			list.Add("Where was your father born");
			list.Add("Do you believe in God");
			list.Add("Are you religous");
			list.Add("Are you a Christian");
			list.Add("Can you count in Spanish");
			list.Add("Can you count in French");
			list.Add("Can you count in Czech");
			list.Add("Can you count in Polish");
			list.Add("Can you count in Russian");
			list.Add("Can you count in Arabic");
			list.Add("Can you count in German");
			list.Add("Do you run");
			list.Add("Do you jump");
			list.Add("Do you sky dive");
			list.Add("Do you fly");
			list.Add("Do you own a house");
			list.Add("Do you work on a house");
			list.Add("Do you have sisters");
			list.Add("Do you have brothers");
			list.Add("Do you have cousins");
			list.Add("Do you have grandparents who are still alive");
			list.Add("Do you create computer programs");
			list.Add("Are you on Facebook");
			list.Add("Do you use Tik Tok");
			list.Add("Are you on Instagram");
			list.Add("Will you travel this year");
			list.Add("Have you heard of the Mayans");
			list.Add("Have you heard of the Inca");
			list.Add("Have you been to Cusco, Peru");
			list.Add("Do you talk with your pets");
			list.Add("Do you have pets");
			list.Add("Do you ever say crazy things");
			list.Add("Have you ever talked with a plant");

			return list;
		}

		#endregion

		#region Misc

		private void SetChatResponseType()
		{
			var enumValues = Enum.GetValues<ChatResponseType>();
			if (this.currentResponseTypeIndex >= enumValues.Count()-1)
			{
				this.currentResponseTypeIndex = 0;
			}
			else
			{
				this.currentResponseTypeIndex++;
			}

			this.currentResponseType = enumValues[this.currentResponseTypeIndex];
		}

        #endregion

        #endregion
    }
}