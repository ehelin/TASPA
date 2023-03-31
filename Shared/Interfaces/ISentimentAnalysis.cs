using System.Collections.Generic;
using Shared.Dto.Chat;
using Shared.Dto.Sentence;

namespace Shared.Interfaces
{
	public interface ISentimentAnalysis
	{
        public SentimentResult GetChatConversationRanking(List<string> sentences);

		public SentimentResult GetChatSentenceRanking(string chatSentence);
	}
}
