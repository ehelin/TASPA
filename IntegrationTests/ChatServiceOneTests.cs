using System;
using BLL;
using Shared.Interfaces;
using Xunit;

namespace IntegrationTests
{
	[CollectionDefinition("ChatServiceOneTests", DisableParallelization = true)]
	public class ChatServiceOneTests
	{
		private readonly string webRoot;
		private readonly IChatService chatService;

		public ChatServiceOneTests()
		{
			// TODO - obtain dynamically
			this.webRoot = "C:\\EricDocuments\\Personal\\Taspa2\\TASPA\\wwwroot";

			ISentenceService sentenceService = new SentenceServiceOne();
			this.chatService = new ChatServiceOne(sentenceService, true);
		}

		[Fact]
		public void ChatUserNameIsRequested()
		{
			var ctr = 1;
			var msg = "Hello!";
			bool chatUserNameRequested = false;

			while (ctr < ChatServiceOne.MAX_COUNTER)
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

			while (ctr < ChatServiceOne.MAX_COUNTER)
			//while (ctr < 100)  // Don't get to large with this test's iteration
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
			bool chatUserNameRequested = false;
			bool chatUserNameUsed = false;

			while (ctr < ChatServiceOne.MAX_COUNTER)
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
				else if (response.IndexOf(chatUserName) != -1)
				{
					chatUserNameUsageCounter++;
				}
				System.Diagnostics.Debug.WriteLine(response);

				System.Threading.Thread.Sleep(1000);
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

			while (ctr < ChatServiceOne.MAX_COUNTER)
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
	}
}