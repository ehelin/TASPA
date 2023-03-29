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
        [InlineData("This is a horrible ugly mean message", SentimentResult.Negative)]
        public void GetChatMessageRanking(string message, SentimentResult expectedResult)
        {
            var result = sentimentAnalysis.GetChatMessageRanking(message);

            Assert.Equal(result, expectedResult);
        }
	}
}