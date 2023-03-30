using System.Collections.Generic;
using Shared.Dto.Chat;
using Shared.Dto.Sentence;

namespace Shared.Interfaces
{
	public interface ISentimentAnalysis
	{
        public SentimentResult GetChatConversationRanking(string chatConversation);

		public SentimentResult GetChatSentenceRanking(string chatSentence);
	}
}
