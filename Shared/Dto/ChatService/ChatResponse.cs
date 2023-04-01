using Shared.Dto.Chat;

namespace Shared.Dto
{
    public class ChatResponse
    {
        public string Response { get; set; }
        public SentimentResult SentimentChatResult { get; set; }
        public SentimentResult SentimentConversationResult { get; set; }
    }
}
