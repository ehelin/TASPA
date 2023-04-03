using Shared.Dto.Chat;

namespace Shared.Dto
{
    public class ChatResponse
    {
        public string response { get; set; }
        public string sentimentConversationResult { get; set; }
        public string sentimentChatResult { get; set; }
    }
}
