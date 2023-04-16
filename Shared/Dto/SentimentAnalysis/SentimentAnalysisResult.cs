using Shared.Dto.Chat;

namespace Shared.Dto.SentimentAnalysis
{
    public class SentimentAnalysisResult
    {
        public SentimentResult Message { get; set; }
        public SentimentResult Conversation { get; set; }
    }
}
