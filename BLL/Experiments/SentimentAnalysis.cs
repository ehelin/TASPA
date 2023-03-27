using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		public int MAX_COUNTER = 100000;
		public int PRONOUN_PREVIOUS_SENTENCE_CHECK_BATCH_SIZE = 10;

		private readonly List<string> positiveWords;					 
		private readonly List<string> negativeWords;

		public SentimentAnalysis()
		{
		}

        public string GetChatRanking(string chatDocument)
        {
            throw new NotImplementedException();
        }

        public string GetChatMessageRanking(string chatMessage)
        {
            throw new NotImplementedException();
        }
    }
}