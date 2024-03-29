﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Shared.Dto.Chat;
using Shared.Dto.Sentence;
using Shared.Dto.SentimentAnalysis;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using static System.Formats.Asn1.AsnWriter;

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
        private readonly List<string> conversation;

        public SentimentAnalysis(ISentimentAnalysisData sentimentAnalysisData)
		{
            this.sentimentAnalysisData = sentimentAnalysisData;
            this.conversation = new List<string>();
        }

        public void ClearConversation()
        {
            conversation.Clear();
        }

        public SentimentAnalysisResult GetChatSentenceRanking(string sentence)
        {
            var result = GetSentenceRanking(sentence);
            conversation.Add(sentence);
            result.Conversation = GetChatConversationRanking();

            return result;
        }

        #region Private Methods

        private SentimentResult GetChatConversationRanking()
        {
            var positiveScore = 0;
            var neutralScore = 0;
            var negativeScore = 0;

            foreach (var sentence in conversation)
            {
                var sentimentResult = GetSentenceRanking(sentence);

                if (sentimentResult.Message == SentimentResult.Positive)
                {
                    positiveScore++;
                }
                else if (sentimentResult.Message == SentimentResult.Neutral)
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

        private SentimentAnalysisResult GetSentenceRanking(string sentence)
        {
            var result = new SentimentAnalysisResult();
            var words = sentence.Split(' ');
            var score = 0;
            foreach (var word in words)
            {
                var negativeWords = this.sentimentAnalysisData.NegativeWords.Where(x => x.Word == word).ToList();
                var positiveWords = this.sentimentAnalysisData.PositiveWords.Where(x => x.Word == word).ToList();

                if (positiveWords.Any(x => x.Word == word))
                {
                    score++;
                }
                else if (negativeWords.Any(x => x.Word == word))
                {
                    score--;
                }
            }

            result.Message = GetAnalysisResult(score);

            return result;
        }

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