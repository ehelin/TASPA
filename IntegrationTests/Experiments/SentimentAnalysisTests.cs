using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Experiments;
using BLL;
using Shared.Dto.Sentence;
using Shared.Interfaces;
using Xunit;
using Shared.Dto.Chat;
using DAL;
using Shared.Dto.SentimentAnalysis;

namespace IntegrationTests.Experiments
{
	[CollectionDefinition("ChatServiceOneTests", DisableParallelization = true)]
	public class SentimentAnalysisTests
    {
		private readonly ISentimentAnalysis sentimentAnalysis;
		private int maxCounter = 1000;

		public SentimentAnalysisTests()
		{
            ISentimentAnalysisData sentimentAnalysisData = new SentimentAnalysisData();
            sentimentAnalysis = new SentimentAnalysis(sentimentAnalysisData);
        }

        [Theory]
        [InlineData("This is an abundance achievement of action", SentimentResult.Positive)]
        [InlineData("This is a message", SentimentResult.Neutral)]
        [InlineData("abandoned abyss of abuse", SentimentResult.Negative)]
        public void GetChatSentenceRanking(string message, SentimentResult expectedResult)
        {
            var result = sentimentAnalysis.GetChatSentenceRanking(message);

            Assert.Equal(result.Message, expectedResult);
        }

        [Theory]
        [InlineData("This is an abundance achievement of action. This is an abundance achievement of action. This is an abundance achievement of action.", SentimentResult.Positive)]
        [InlineData("This is a message. A message with no adverbs or adjectives. A chat conversation.", SentimentResult.Neutral)]
        [InlineData("This is a horrible ugly mean message. Full of ugly horrible mean vicious things.  A truly bad chat conversation.", SentimentResult.Negative)]
        public void GetChatConversationRanking(string conversation, SentimentResult expectedResult)
        {
            SentimentAnalysisResult result = null;
            var sentences = conversation.Split('.').ToList();

            foreach (var sentence in sentences)
            {
                if (!string.IsNullOrEmpty(sentence))
                {
                    result = sentimentAnalysis.GetChatSentenceRanking(sentence);
                }
            }

            Assert.Equal(result.Conversation, expectedResult);
        }
    }
}