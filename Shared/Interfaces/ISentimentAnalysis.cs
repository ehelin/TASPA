using System.Collections.Generic;
using Shared.Dto.Chat;
using Shared.Dto.Sentence;

namespace Shared.Interfaces
{
	public interface ISentimentAnalysis
	{
        public SentimentResult GetChatRanking(string chatDocument);

		public SentimentResult GetChatMessageRanking(string chatMessage);
	}
}
