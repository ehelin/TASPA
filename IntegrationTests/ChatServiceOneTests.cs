using System;
using BLL;
using Shared.Interfaces;
using Xunit;

namespace IntegrationTests
{
	public class ChatServiceOneTests
	{
		private readonly string webRoot;

		public ChatServiceOneTests()
		{
			// TODO - obtain dynamically
			this.webRoot = "C:\\EricDocuments\\Personal\\Taspa2\\TASPA\\wwwroot";
        }

		[Fact]
		public void ChatUserNameIsRequested()
		{
			var ctr = 1;
			var msg = "Hello!";
			bool chatUserNameRequested = false;

			while (ctr < ChatServiceOne.MAX_COUNTER)
			{
				//creating new instance since this is what happens with website
				ISentenceService sentenceService = new SentenceServiceOne();
				var chatService = new ChatServiceOne(sentenceService);

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
			var msg = "Hello!";
			var chatUserName = "FredTheChatUsers";
			bool chatUserNameRequested = false;
			bool chatUserNameUsed = false;

			while (ctr < ChatServiceOne.MAX_COUNTER)
			{
				//creating new instance since this is what happens with website
				ISentenceService sentenceService = new SentenceServiceOne();
				var chatService = new ChatServiceOne(sentenceService, 100);  // set max index for using chat user name

				var response = chatService.GetMessageResponse(this.webRoot, msg);

				if (response.IndexOf(ChatServiceOne.REQUEST_CHAT_USER_MESSAGE) != -1)
				{
					chatUserNameRequested = true;
					msg = string.Format("{0}{1}", chatUserName, DateTime.UtcNow.Ticks.ToString());
				}
				else if (response.IndexOf(chatUserName) != -1)
				{
					chatUserNameUsed = true;
					break;
				}

				ctr++;
			}

			Assert.True(chatUserNameRequested);
			Assert.True(chatUserNameUsed);
		}

		// TODO - test that verifies the chat user's name is used inside some chat responses after it is set.
		// TODO - test that verifies chat user's name is never requested more than once
	}
}