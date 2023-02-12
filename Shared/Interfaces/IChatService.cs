using Shared.Dto.Chat;

namespace Shared.Interfaces
{
    public interface IChatService
	{
        public string GetMessageResponse(string dataPath, string chatMessage);
		public ChatResponseType GetCurrentResponseType();
	}
}
