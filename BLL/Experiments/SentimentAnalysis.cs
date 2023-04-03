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

        public SentimentResult GetChatConversationRanking(List<string> sentences)
        {
            var positiveScore = 0;
            var neutralScore = 0;
            var negativeScore = 0;

            foreach (var sentence in sentences)
            {
                var sentimentResult = GetChatSentenceRanking(sentence);

                if (sentimentResult == SentimentResult.Positive)
                {
                    positiveScore++;
                }
                else if (sentimentResult == SentimentResult.Neutral)
                {
                    neutralScore++;
                }
                else
                {
                    negativeScore++;
                }
            }

            var results = GetAnalysisResult(positiveScore, neutralScore, negativeScore);

            return results;
        }

        public SentimentResult GetChatSentenceRanking(string sentence)
        {
            var words = sentence.Split(' ');
            var score = 0;
            foreach (var word in words)
            {
                var negativeWords = this.sentimentAnalysisData.NegativeWords.Where(x => x.Word== word).ToList();
                var positiveWords = this.sentimentAnalysisData.PositiveWords.Where(x => x.Word == word).ToList();

                // negative word only
                if (negativeWords.Count() > 0 && positiveWords.Count() == 0)
                {
                    score--;
                }
                // positive word only
                else if (positiveWords.Count() > 0 && negativeWords.Count() == 0)
                {
                    score++;
                }
                // both lists contain word...use class to determine which to use 
                // MN - Mostly Negative
                // NMP - Not Mostly Positive
                // MP - Mostly Positive
                // NMN - Not Mostly Negative
                else if (positiveWords.Count() > 0 && negativeWords.Count() > 0)
                {
                    if ((negativeWords[0].Class == "MN" || negativeWords[0].Class == "NMP")
                        && (positiveWords[0].Class == "MN" || positiveWords[0].Class == "NMP"))
                    {
                        score--;
                    }
                    else
                    {
                        score++;
                    }
                }
            }

            var results = GetAnalysisResult(score);

            return results;
        }

        #region Private Methods

        private SentimentResult GetAnalysisResult(int score)
        {
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

        private SentimentResult GetAnalysisResult(int positiveScore, int neutralScore, int negativeScore)
        {
            if (positiveScore == 0 && neutralScore == 0 && negativeScore == 0)
            {
                return SentimentResult.Neutral;
            }

            string highestScoreVariable = new[]
            {
                Tuple.Create(positiveScore, "positiveScore"),
                Tuple.Create(neutralScore, "neutralScore"),
                Tuple.Create(negativeScore, "negativeScore")
            }.Max().Item2;

            if (highestScoreVariable == "positiveScore")
            {
                return SentimentResult.Positive;
            }
            else if (highestScoreVariable == "neutralScore")
            {
                return SentimentResult.Neutral;
            }
            else
            {
                return SentimentResult.Negative;
            }
        }

        #endregion
    }
}