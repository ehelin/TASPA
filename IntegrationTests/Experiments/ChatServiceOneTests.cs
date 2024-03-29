using System;
using BLL;
using BLL.Experiments;
using Shared.Interfaces;
using Xunit;
using Shared.Dto.Chat;
using System.Collections.Generic;
using DAL;

namespace IntegrationTests.Experiments
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

			ISentenceService sentenceService = new SentenceService();
            ISentimentAnalysisData sentimentAnalysisData = new SentimentAnalysisData();
            ISentimentAnalysis sentimentAnalysis = new SentimentAnalysis(sentimentAnalysisData);

            this.chatService = new ChatServiceOne(sentenceService, sentimentAnalysis, true);
		}

		#region Chat User Name Based Tests

		[Fact]
		public void ChatUserNameIsRequested()
		{
			var ctr = 1;
			var msg = "Hello!";
			bool chatUserNameRequested = false;
			var includeSentimentAnalysis = false;  // TODO add test for this

			while (ctr < maxCounter)
			{
				var response = chatService.GetMessageResponse(this.webRoot, msg, includeSentimentAnalysis);

				if (response.response.IndexOf(ChatServiceOne.REQUEST_CHAT_USER_MESSAGE) != -1)
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
            var includeSentimentAnalysis = false;  // TODO add test for this

            while (ctr < maxCounter)
			{
				//get answer portion of the response
				var response = chatService.GetMessageResponse(this.webRoot, msg, includeSentimentAnalysis);
				var responseAsArray = response.response.Split(new[] { "\r\n" }, StringSplitOptions.None); ;
				response.response = responseAsArray[1].Replace(responsePrefix, "");

				if (response.response.IndexOf(ChatServiceOne.REQUEST_CHAT_USER_MESSAGE) != -1)
				{
					chatUserNameRequested = true;
					msg = chatUserName;
				}
				else if (response.response.IndexOf(chatUserName) != -1 && chatUserNameUsageCounter < expectedGoodResponseCount)
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
            var includeSentimentAnalysis = false;  // TODO add test for this

            while (ctr < maxCounter)
			{
				//get answer portion of the response
				var response = chatService.GetMessageResponse(this.webRoot, msg, includeSentimentAnalysis);
				var responseAsArray = response.response.Split(new[] { "\r\n" }, StringSplitOptions.None); ;
				response.response = responseAsArray[1].Replace(responsePrefix, "");

				if (response.response.IndexOf(ChatServiceOne.REQUEST_CHAT_USER_MESSAGE) != -1)
				{
					msg = chatUserName;
				}
				else if (response.response.IndexOf(chatUserName) != -1)
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
            var includeSentimentAnalysis = false;  // TODO add test for this

            while (ctr < maxCounter)
			{
				//get answer portion of the response
				var response = chatService.GetMessageResponse(this.webRoot, msg, includeSentimentAnalysis);
				var responseAsArray = response.response.Split(new[] { "\r\n" }, StringSplitOptions.None); ;
				response.response = responseAsArray[1].Replace(responsePrefix, "");

				if (!chatUserNameRequested && response.response.IndexOf(ChatServiceOne.REQUEST_CHAT_USER_MESSAGE) != -1)
				{
					chatUserNameRequested = true;
					msg = chatUserName;
				}
				else if (chatUserNameRequested && response.response.IndexOf(ChatServiceOne.REQUEST_CHAT_USER_MESSAGE) != -1)
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
            var includeSentimentAnalysis = false;  // TODO add test for this

            var enumCounts = new Dictionary<ChatResponseType, int>();
			var enumValues = Enum.GetValues<ChatResponseType>();
			foreach(var enumValue in enumValues)
			{
				enumCounts.Add(enumValue, 0);
			}

			while (ctr < maxCounter)
			{           
				//get answer portion of the response
				var response = chatService.GetMessageResponse(this.webRoot, msg, includeSentimentAnalysis);
				var responseAsArray = response.response.Split(new[] { "\r\n" }, StringSplitOptions.None); ;
				response.response = responseAsArray[1].Replace(responsePrefix, "");

				if (response.response.IndexOf(ChatServiceOne.REQUEST_CHAT_USER_MESSAGE) != -1)
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