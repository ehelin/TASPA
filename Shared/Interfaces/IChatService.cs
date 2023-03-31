using Shared.Dto.Chat;

namespace Shared.Interfaces
{
    public interface IChatService
	{
        public string GetMessageResponse(string dataPath, string chatMessage, bool includeSentimentAnalysis);
        public void ClearChatSession();
        public ChatResponseType GetCurrentResponseType();
	}
}
