using System.IO;
using Shared.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace DAL
{
	public class ChatDataImplementationOne : IChatData
	{
		private static int lastUsedInded = 0;       // record last index to help with creating interesting responses
		private static List<string> alreadyUsedResponses = 0;       // record last index to help with creating interesting responses

		public ChatDataImplementationOne()
		{
			if (ChatDataImplementationOne.alreadyUsedResponses == null)
			{
				ChatDataImplementationOne.alreadyUsedResponses = new List<string>();
			}
		}

		public string GetMessageResponse(string webRoot, string chatMessage)
		{
			var response = "";
			var dataPath = string.Format("{0}\\{1}", webRoot, "chat\\data.txt");
			var previouslyRecordedChatMessages = System.IO.File.ReadAllLines(dataPath);

			// if previously recorded messages, create a response from them
			if (previouslyRecordedChatMessages != null && previouslyRecordedChatMessages.Length > 0)
			{
				response = GetResponseFromPreviouslyRecordedChatMessage(previouslyRecordedChatMessages);
			}
			// if no recorded messages, return sent message
			else
			{
				response = chatMessage;
			}

			// only record new messages
			if (!previouslyRecordedChatMessages.Any(x => x == chatMessage))
			{
				RecordChatMessage(dataPath, chatMessage);
			}

			ChatDataImplementationOne.alreadyUsedResponses.Add(response);

			lastUsedInded++;

			return response;
		}

		private string GetResponseFromPreviouslyRecordedChatMessage(string[] previouslyRecordedChatMessages)
		{
			// if only one recorded message, return sent it
			if (previouslyRecordedChatMessages.Length == 1)
			{
				return previouslyRecordedChatMessages[0];      
			}
			else
			{
				// if first call and multiple messages, return second recorded message
				if (ChatDataImplementationOne.lastUsedInded == 0)
				{
					return previouslyRecordedChatMessages[1];	
				}

				foreach (var previouslyRecordedChatMessage in previouslyRecordedChatMessages)
				{ 
					// multiple messages, last used exceeds list of responses, return last recorded entry
					if (lastUsedInded > previouslyRecordedChatMessages.Length)
					{
						return previouslyRecordedChatMessages[previouslyRecordedChatMessages.Length - 1];   
					}

					// entry with spaces, return it reversed
					if (previouslyRecordedChatMessage.IndexOf(" ") != -1)
					{
						var previouslyRecordedChatMessageArray = previouslyRecordedChatMessage.Split(" ");
						var stack = new Stack();
						foreach(var previouslyRecordedChatMsg in previouslyRecordedChatMessageArray)
						{
							stack.Push(previouslyRecordedChatMsg);
						}
						var sb = new StringBuilder();

						var enumerator = stack.GetEnumerator();
						while (enumerator.MoveNext())
						{
							sb.Append(enumerator.Current.ToString() + " ");
						}
						var response = sb.ToString().Trim();
						if (!ChatDataImplementationOne.alreadyUsedResponses.Any(x => x == response))
						{
							return response;
						}
					}
				}
			}

			return "Hmm...not sure how to respond";  // default 'we have no response'
		}

		private void RecordChatMessage(string dataPath, string chatMessage)
		{
			using (var chatData = new StreamWriter(dataPath, true))
			{
				chatData.WriteLine(chatMessage);
				chatData.Flush();
				chatData.Close();
			}
		}
	}
}