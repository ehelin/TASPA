using System;
using System.Collections.Generic;
using BLL;
using Shared.Interfaces;
using Xunit;

namespace IntegrationTests
{
	[CollectionDefinition("ChatServiceOneTests", DisableParallelization = true)]
	public class SentenceServiceOneTests
	{
		private readonly ISentenceService sentenceService;

		public SentenceServiceOneTests()
		{
			ISentenceService sentenceService = new SentenceServiceOne();
			this.sentenceService = new SentenceServiceOne();
		}

		// Tests to write
		// 1) one or two to validate pronouns are being used

		[Fact]
		public void GenerateSentence()
		{
			var ctr = 1;
			var sentence = "";
			while (ctr < 10000)
			{
				sentence = sentenceService.GenerateSentence();

				System.Diagnostics.Debug.WriteLine(sentence + " --- " + ctr.ToString());

				System.Threading.Thread.Sleep(3000);

				ctr++;
			}

			// TODO - find something valid to test
			//Assert.True(!string.IsNullOrEmpty(sentence));
		}
	}
}