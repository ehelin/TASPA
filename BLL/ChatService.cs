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
	/// </summary>
	public class ChatServiceImplementationOne : IChatService
	{
		private static int lastUsedInded = 0;                   // record last index to help with creating interesting responses
		//private static List<string> alreadyUsedResponses;       // remember responses to at least for this session, we do not send same response

		private int MAX_COUNTER = 1000;

		private const string CHATTER = "Chat User";
		private const string CHATBOT_NAME = "Taspa";

		private readonly List<string> alphabet; 
		private readonly Random random;

		public ChatServiceImplementationOne()
		{
			this.alphabet = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
			this.random = new Random();
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
				//if (!ChatServiceImplementationOne.alreadyUsedResponses.Any(x => x == response)) { break; }

				recordedChatDialog = GetRecordedChatDialog(dataPath);	// re-read in saved dialog for fresh evaluations of generated dialog
				ctr++;
			}

			// TODO - some sort of phrase generator? The loop counter with previously recorded messages are not sufficient to guarantee new responses
			//ChatServiceImplementationOne.alreadyUsedResponses.Add(response);

			lastUsedInded++;

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
				response = GetResponseFromRecordedChatDialog(recordedChatDialog, dataPath);
			}
			// if no recorded messages, return sent message
			else
			{
				response = chatMessage;
			}

			// only record new messages and responses (used or not used)
			if (!recordedChatDialog.Any(x => x == chatMessage)) { RecordChatDialog(dataPath, chatMessage); }
			if (!recordedChatDialog.Any(x => x == response)) { RecordChatDialog(dataPath, response); }

			return response;
		}

		private string GetResponseFromRecordedChatDialog(string[] recordedChatDialog, string dataPath)
		{
			// if only one recorded message, return sent it
			if (recordedChatDialog.Length == 1 && !ChatDialogExists(recordedChatDialog[0], dataPath)) { return recordedChatDialog[0]; }
			else
			{
				// if first call and multiple messages, return second recorded message
				if (ChatServiceImplementationOne.lastUsedInded == 0 && !ChatDialogExists(recordedChatDialog[1], dataPath)) { return recordedChatDialog[1]; }

				// loop thru previously recorded messages and attempt to generate new response
				var response = "";
				var recordedChatDialogCtr = 1;
				foreach (var chatDialog in recordedChatDialog)
				{
					//===============================================================================================
					// multiple messages, last used exceeds list of responses, return last recorded entry
					var lastEntry = recordedChatDialog[recordedChatDialog.Length - 1];
					if (lastUsedInded > recordedChatDialog.Length && !ChatDialogExists(lastEntry, dataPath) && !string.IsNullOrEmpty(response)) { return lastEntry; }

					//===============================================================================================
					//find response if current previously recorded message has spaces (reversing or not based on current loop counter)
					response = GetResponseFromRecordedDialogWithSpaces(chatDialog, recordedChatDialogCtr % 2 == 0 ? true : false, dataPath);
					if (!string.IsNullOrEmpty(response)) { return response; }  // Exit if we get a response

					//===============================================================================================
					//find response if if current previously recorded message has starts with the first letter of the alphabet in a loop
					var randomAlpabet = this.alphabet[random.Next(0, this.alphabet.Count())];
					response = recordedChatDialog.Where(x => x.ToLower().StartsWith(randomAlpabet.ToLower())).FirstOrDefault();
					if (!string.IsNullOrEmpty(response) && !ChatDialogExists(response, dataPath)) { return response; }

					// TODO - add more text manipulations to create new responses

					recordedChatDialogCtr++;
				}
			}

			return "Hmm...not sure how to respond";  // default 'we have no response'
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