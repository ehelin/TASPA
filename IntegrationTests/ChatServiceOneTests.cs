using System;
using BLL;
using Shared.Interfaces;
using Xunit;
using Shared.Dto.Chat;
using System.Collections.Generic;

namespace IntegrationTests
{
	[CollectionDefinition("ChatServiceOneTests", DisableParallelization = true)]
	public class ChatServiceOneTests
	{
		private readonly string webRoot;
		private readonly IChatService chatService;
		private int maxCounter = 1000;

		public ChatServiceOneTests()
		{
			// TODO - obtain dynamically
			this.webRoot = "C:\\EricDocuments\\Personal\\Taspa2\\TASPA\\wwwroot";

			ISentenceService sentenceService = new SentenceServiceOne();
			this.chatService = new ChatServiceOne(sentenceService, true);
		}

		#region Chat User Name Based Tests

		[Fact]
		public void ChatUserNameIsRequested()
		{
			var ctr = 1;
			var msg = "Hello!";
			bool chatUserNameRequested = false;

			while (ctr < maxCounter)
			{
				var response = chatService.GetMessageResponse(this.webRoot, msg);

				if (response.IndexOf(ChatServiceOne.REQUEST_CHAT_USER_MESSAGE) != -1)
				{
					chatUserNameRequested = true;
					break;
				}

				ctr++;
			}

			Assert.True(chatUserNameRequested);
		}

		[Fact]
		public void ChatUserNameIsUsedAfterRequested()
		{
			var ctr = 1;
			var responsePrefix = string.Format("{0}: ", ChatServiceOne.CHATBOT_NAME);
			var msg = "Hello";
			var chatUserNameUsageCounter = 1;
			var chatUserName = ChatServiceOne.TEST_CHATBOT_USER;
			var expectedGoodResponseCount = 5;
			bool chatUserNameRequested = false;
			bool chatUserNameUsed = false;

			while (ctr < maxCounter)
			{
				//get answer portion of the response
				var response = chatService.GetMessageResponse(this.webRoot, msg);
				var responseAsArray = response.Split(new[] { "\r\n" }, StringSplitOptions.None); ;
				response = responseAsArray[1].Replace(responsePrefix, "");

				if (response.IndexOf(ChatServiceOne.REQUEST_CHAT_USER_MESSAGE) != -1)
				{
					chatUserNameRequested = true;
					msg = chatUserName;
				}
				else if (response.IndexOf(chatUserName) != -1 && chatUserNameUsageCounter < expectedGoodResponseCount)
				{
					chatUserNameUsageCounter++;
				}
				else if (chatUserNameUsageCounter >= expectedGoodResponseCount && chatUserNameUsageCounter == expectedGoodResponseCount)
				{
					chatUserNameUsed = true;
					break;
				}

				System.Threading.Thread.Sleep(100);
				ctr++;
			}

			Assert.True(chatUserNameRequested);
			Assert.True(chatUserNameUsed);
		}

		[Fact]
		public void ChatUserNameResponsePrintouts()
		{
			var ctr = 1;
			var responsePrefix = string.Format("{0}: ", ChatServiceOne.CHATBOT_NAME);
			var msg = "Hello";
			var chatUserNameUsageCounter = 1;
			var chatUserName = ChatServiceOne.TEST_CHATBOT_USER;

			while (ctr < maxCounter)
			{
				//get answer portion of the response
				var response = chatService.GetMessageResponse(this.webRoot, msg);
				var responseAsArray = response.Split(new[] { "\r\n" }, StringSplitOptions.None); ;
				response = responseAsArray[1].Replace(responsePrefix, "");

				if (response.IndexOf(ChatServiceOne.REQUEST_CHAT_USER_MESSAGE) != -1)
				{
					msg = chatUserName;
				}
				else if (response.IndexOf(chatUserName) != -1)
				{
					chatUserNameUsageCounter++;
					//System.Diagnostics.Debug.WriteLine(response + " --- " + ctr.ToString());
				}

				ctr++;
			}

			Assert.True(chatUserNameUsageCounter > 100);
		}

		[Fact]
		public void ChatUserNameIsNeverRequestedAfterGiven()
		{
			var ctr = 1;
			var responsePrefix = string.Format("{0}: ", ChatServiceOne.CHATBOT_NAME);
			var msg = "Hello";
			var chatUserName = ChatServiceOne.TEST_CHATBOT_USER;
			bool chatUserNameRequested = false;
			bool chatUserNeverRequestedAfterSubmission = false;

			while (ctr < maxCounter)
			{
				//get answer portion of the response
				var response = chatService.GetMessageResponse(this.webRoot, msg);
				var responseAsArray = response.Split(new[] { "\r\n" }, StringSplitOptions.None); ;
				response = responseAsArray[1].Replace(responsePrefix, "");

				if (!chatUserNameRequested && response.IndexOf(ChatServiceOne.REQUEST_CHAT_USER_MESSAGE) != -1)
				{
					chatUserNameRequested = true;
					msg = chatUserName;
				}
				else if (chatUserNameRequested && response.IndexOf(ChatServiceOne.REQUEST_CHAT_USER_MESSAGE) != -1)
				{
					chatUserNeverRequestedAfterSubmission = true;
					break;
				}

				ctr++;
			}

			Assert.True(chatUserNameRequested);
			Assert.False(chatUserNeverRequestedAfterSubmission);
		}

		#endregion

		#region Chat Response Types

		[Fact]
		public void ChaResponseTypeChanges()
		{
			var ctr = 1;
			var responsePrefix = string.Format("{0}: ", ChatServiceOne.CHATBOT_NAME);
			var msg = "Hello";
			var chatUserName = ChatServiceOne.TEST_CHATBOT_USER;

			var enumCounts = new Dictionary<ChatResponseType, int>();
			var enumValues = Enum.GetValues<ChatResponseType>();
			foreach(var enumValue in enumValues)
			{
				enumCounts.Add(enumValue, 0);
			}

			while (ctr < maxCounter)
			{           
				//get answer portion of the response
				var response = chatService.GetMessageResponse(this.webRoot, msg);
				var responseAsArray = response.Split(new[] { "\r\n" }, StringSplitOptions.None); ;
				response = responseAsArray[1].Replace(responsePrefix, "");

				if (response.IndexOf(ChatServiceOne.REQUEST_CHAT_USER_MESSAGE) != -1)
				{
					msg = chatUserName;
				}

				// track count of returned response type
				enumCounts[chatService.GetCurrentResponseType()] = enumCounts[chatService.GetCurrentResponseType()] + 1;

				ctr++;
			}

			// verify each enumeration value occurred at least one
			foreach (var enumValue in enumValues)
			{
				Assert.True(enumCounts[enumValue] > 0);
			}
		}

		#endregion
	}
}