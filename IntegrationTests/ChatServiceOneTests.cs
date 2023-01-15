using BLL;
using Shared.Interfaces;
using Xunit;

namespace IntegrationTests
{
	public class ChatServiceOneTests
	{
        private readonly IChatService chatService;
		private readonly string webRoot;

		public ChatServiceOneTests()
		{
			ISentenceService sentenceService = new SentenceServiceOne();
			this.chatService = new ChatServiceOne(sentenceService);

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
				var response = this.chatService.GetMessageResponse(this.webRoot, msg);

				if (response.IndexOf(ChatServiceOne.REQUEST_CHAT_USER_MESSAGE) != -1)
				{
					chatUserNameRequested = true;
					break;
				}

				ctr++;
			}

			Assert.True(chatUserNameRequested);
		}

		// TODO - test that verifies the chat user's name is used inside some chat responses after it is set.
		// TODO - test that verifies chat user's name is never requested more than once
	}
}