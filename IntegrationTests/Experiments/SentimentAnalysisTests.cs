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
        [InlineData("This is a nice friendly beautiful positive message", SentimentResult.Positive)]
        [InlineData("This is a message", SentimentResult.Neutral)]
        [InlineData("not bad even never terrible", SentimentResult.Negative)]
        public void GetChatSentenceRanking(string message, SentimentResult expectedResult)
        {
            var result = sentimentAnalysis.GetChatSentenceRanking(message);

            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData("This is a nice friendly beautiful positive message. A nice positive thought that is beautiful. Truely, a positive, nice and friendly conversation.", SentimentResult.Positive)]
        [InlineData("This is a message. A message with no adverbs or adjectives. A chat conversation.", SentimentResult.Neutral)]
        [InlineData("This is a horrible ugly mean message. Full of ugly horrible mean vicious things.  A truly bad chat conversation.", SentimentResult.Negative)]
        public void GetChatConversationRanking(string message, SentimentResult expectedResult)
        {
            var result = sentimentAnalysis.GetChatConversationRanking(message);

            Assert.Equal(result, expectedResult);
        }
    }
}