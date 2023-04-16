using Shared.Dto.SentimentAnalysis;

namespace Shared.Interfaces
{
	public interface ISentimentAnalysis
	{
        public SentimentAnalysisResult GetChatSentenceRanking(string sentence);
        public void ClearConversation();
    }
}
