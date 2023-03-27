using System.Collections.Generic;
using Shared.Dto.Sentence;

namespace Shared.Interfaces
{
	public interface ISentimentAnalysis
	{
        public string GetChatRanking(string chatDocument);
		public string GetChatMessageRanking(string chatMessage);
	}
}
