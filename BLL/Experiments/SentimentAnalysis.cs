using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Shared.Dto.Chat;
using Shared.Dto.Sentence;
using Shared.Interfaces;

namespace BLL.Experiments
{
    /// <summary>
    /// An educational experiment sentiment analysis implementation that ranks chat message and overall document.
    /// 
    /// Uses data/research from https://github.com/citiususc/VERY-NEG-and-VERY-POS-Lexicons which is based 
	/// on work by: 
	///		Almatarneh S, Gamallo P (2018) A lexicon based method to search for extreme opinions. 
	///		PLoS ONE 13(5): e0197816. https://doi.org/10.1371/journal.pone.0197816
    ///		
    /// </summary>
    public class SentimentAnalysis : ISentimentAnalysis
    {
        private readonly ISentimentAnalysisData sentimentAnalysisData;

        public SentimentAnalysis(ISentimentAnalysisData sentimentAnalysisData)
		{
            this.sentimentAnalysisData = sentimentAnalysisData;
        }

        public SentimentResult GetChatRanking(string chatDocument)
        {
            throw new NotImplementedException();
        }

        public SentimentResult GetChatMessageRanking(string message)
        {
            var words = message.Split(' ');
            var score = 0;
            foreach (var word in words)
            {
                if (this.sentimentAnalysisData.NegativeWords.Contains(word))
                {
                    score--;
                }
                else if (this.sentimentAnalysisData.PositiveWords.Contains(word))
                {
                    score++;
                }
            }

            if (score > 0)
            {
                return SentimentResult.Positive;
            }
            else if (score < 0)
            {
                return SentimentResult.Negative;
            }
            else 
            {
                return SentimentResult.Neutral;
            }
        }
    }
}