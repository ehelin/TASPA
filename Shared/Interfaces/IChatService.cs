using Shared.Dto;
using Shared.Dto.Chat;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IChatService
	{
        ChatResponse GetMessageResponse(string dataPath, string chatMessage, bool includeSentimentAnalysis);
		Task<ChatResponse> GetMessageResponseAsync(string chatMessage);
		void ClearChatSession();
        ChatResponseType GetCurrentResponseType();
	}
}
