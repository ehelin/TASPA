using System;
using System.Collections.Generic;
using BLL;
using System.Linq;
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

		#region Pronouns

		[Fact]
		public void GenerateSentence_PronounIsUsed()
		{
			var ctr = 1;
			var sentence = "";
			bool matchFound = false;
			var maxCounter = this.sentenceService.GetMaxCounter();
			while (ctr < maxCounter)
			{
				sentence = sentenceService.GenerateSentence();

				var sentenceAsArray = sentence.Split(" ");
				var sentenceLastWord = sentenceAsArray[sentenceAsArray.Length-1];
				if (this.sentenceService.GetPronouns().Any(x => x == sentenceLastWord))
				{
					matchFound = true;
					break;
				}

				ctr++;
			}

			Assert.True(matchFound);
		}

		[Fact]
		public void GenerateSentence_PronounIsUsedMoreThanOnce()
		{
			var ctr = 1;
			var sentence = "";
			var pronounMatchFoundCtr = 0;
			var maxCounter = this.sentenceService.GetMaxCounter();
			while (ctr < maxCounter)
			{
				sentence = sentenceService.GenerateSentence();

				var sentenceAsArray = sentence.Split(" ");
				var sentenceLastWord = sentenceAsArray[sentenceAsArray.Length - 1];
				if (this.sentenceService.GetPronouns().Any(x => x == sentenceLastWord))
				{
					pronounMatchFoundCtr++;
				}

				ctr++;
			}

			Assert.True(pronounMatchFoundCtr > 1);
		}

		[Fact]
		public void GenerateSentence_PronounIsAtNoSoonerThanExpectedInterval()
		{
			var ctr = 1;
			var sentence = "";
			var pronounMatchFoundCtrs = new List<int>();
			var maxCounter = this.sentenceService.GetMaxCounter();
			while (ctr < maxCounter)
			{
				sentence = sentenceService.GenerateSentence();

				var sentenceAsArray = sentence.Split(" ");
				var sentenceLastWord = sentenceAsArray[sentenceAsArray.Length - 1];
				if (this.sentenceService.GetPronouns().Any(x => x == sentenceLastWord))
				{
					pronounMatchFoundCtrs.Add(ctr);
				}

				ctr++;
			}

			var pronounPreviousSentenceCheckBatchSize = this.sentenceService.GetPronounPreviousSentenceCheckBatchSize();
			for (var i=0; i< pronounMatchFoundCtrs.Count()-1; i++)
			{
				var currentMatchCounter = pronounMatchFoundCtrs[i];
				var nextMatchCounter = pronounMatchFoundCtrs[i+1];
				var difference = nextMatchCounter - currentMatchCounter;

				Assert.True(difference > pronounPreviousSentenceCheckBatchSize);
			}
		}

		#endregion

		#region Specific subject changes verb to has

		[Theory]
		[InlineData("It")]
		[InlineData("She")]
		[InlineData("He")]
		public void GenerateSentence_SpecificSubjectChangesVerbHaveToHas(string testSubject)
		{
			var ctr = 1;
			var sentence = "";
			bool matchFound = false;
			var maxCounter = this.sentenceService.GetMaxCounter();
			while (ctr < maxCounter)
			{
				sentence = sentenceService.GenerateSentence();

				var sentenceAsArray = sentence.Split(" ");
				var subject = sentenceAsArray[0];
				var verb = sentenceAsArray[1];
				if (subject == testSubject && verb == "has")
				{
					matchFound = true;
					break;
				}

				ctr++;
			}

			Assert.True(matchFound);
		}

		[Theory]
		[InlineData("It")]
		[InlineData("She")]
		[InlineData("He")]
		public void GenerateSentence_SpecificSubjectChangesVerbHaveToHas_IsUsedMoreThanOnce(string testSubject)
		{
			var ctr = 1;
			var sentence = "";
			var matchFoundCtr = 0;
			var maxCounter = this.sentenceService.GetMaxCounter();
			while (ctr < maxCounter)
			{
				sentence = sentenceService.GenerateSentence();

				var sentenceAsArray = sentence.Split(" ");
				var subject = sentenceAsArray[0];
				var verb = sentenceAsArray[1];
				if (subject == testSubject && verb == "has")
				{
					matchFoundCtr++;
				}

				ctr++;
			}

			Assert.True(matchFoundCtr > 1);
		}

		#endregion

		// NOTE: General test to view generated sentences and not meant to be something that is 'tested'
		[Fact]
		public void GenerateSentence()
		{
			var ctr = 1;
			var sentence = "";
			var maxCounter = this.sentenceService.GetMaxCounter();
			while (ctr < maxCounter)
			{
				sentence = sentenceService.GenerateSentence();

				System.Diagnostics.Debug.WriteLine(sentence + " --- " + ctr.ToString());

				//System.Threading.Thread.Sleep(1000);

				ctr++;
			}
		}
	}
}