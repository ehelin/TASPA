using System;
using System.Collections.Generic;
using System.Linq;
using BLL;
using Shared.Dto.Sentence;
using Shared.Interfaces;
using Xunit;

namespace IntegrationTests
{
	[CollectionDefinition("ChatServiceOneTests", DisableParallelization = true)]
	public class SentenceServiceOneTests
	{
		private readonly ISentenceService sentenceService;
		private int maxCounter = 1000;

		public SentenceServiceOneTests()
		{
			ISentenceService sentenceService = new SentenceServiceOne();
			this.sentenceService = new SentenceServiceOne();
		}

		#region Manipulation Tests

		#region Pronouns

		[Fact]
		public void GenerateSentence_PronounIsUsed()
		{
			var ctr = 1;
			var sentence = "";
			bool matchFound = false;
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

		#region Specific subject adds s to present tense verbs

		[Theory]
		[InlineData("It")]
		[InlineData("She")]
		[InlineData("He")]
		public void GenerateSentence_SpecificSubjectAddsAnSToVerb(string testSubject)
		{
			var ctr = 1;
			var sentence = "";
			bool matchFound = false;
			var presentTenseVerbs = this.sentenceService.GetVerbs()
				.Where(x => x.type == Shared.Dto.Sentence.VerbType.Present)
				.Select(x => x.name);

			while (ctr < 1000)
			{
				sentence = sentenceService.GenerateSentence();

				var sentenceAsArray = sentence.Split(" ");
				var subject = sentenceAsArray[0];
				var verb = sentenceAsArray[1];

				var verbToCompare = verb.ToLower().EndsWith("s") ? verb.Substring(0, verb.Length - 1) : verb;
				if (subject == testSubject && presentTenseVerbs.Contains(verbToCompare) && verb.Substring(verb.Length- 1, 1) == "s")
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
		public void GenerateSentence_SpecificSubjectAddsAnSToVerb_IsUsedMoreThanOnce(string testSubject)
		{
			var ctr = 1;
			var sentence = "";
			var matchFoundCtr = 0;
			var presentTenseVerbs = this.sentenceService.GetVerbs()
				.Where(x => x.type == Shared.Dto.Sentence.VerbType.Present)
				.Select(x => x.name);

			while (ctr < maxCounter)
			{
				sentence = sentenceService.GenerateSentence();

				var sentenceAsArray = sentence.Split(" ");
				var subject = sentenceAsArray[0];
				var verb = sentenceAsArray[1];
				var verbToCompare = verb.ToLower().EndsWith("s") ? verb.Substring(0, verb.Length - 1) : verb;
				if (subject == testSubject && presentTenseVerbs.Contains(verbToCompare) && verb.Substring(verb.Length-1, 1) == "s")
				{
					matchFoundCtr++;
				}

				ctr++;
			}

			Assert.True(matchFoundCtr > 1);
		}

		#endregion

		#region Past Tense Type Verbs Add Article

		[Fact]
		public void GenerateSentence_HavePastTenseTypeVerbsAddArticle()
		{
			var ctr = 1;
			var sentence = "";
			bool matchFound = false;
			var pastTenseHaveVerbs = this.sentenceService.GetVerbs()
				.Where(x => x.type == VerbType.Have || x.type == VerbType.Past)
				.Select(x => x.name);

			while (ctr < maxCounter)
			{
				sentence = sentenceService.GenerateSentence();

				var sentenceAsArray = sentence.Split(" ");
				var verb = sentenceAsArray[1];
				if (pastTenseHaveVerbs.Contains(verb) && sentenceAsArray.Length == 4)
				{
					matchFound = true;
					break;
				}

				ctr++;
			}

			Assert.True(matchFound);
		}

		[Fact]
		public void GenerateSentence_HavePastTenseTypeVerbsAddArticle_IsUsedMoreThanOnce()
		{
			var ctr = 1;
			var sentence = "";
			var matchFoundCtr = 0;
			var pastTenseHaveVerbs = this.sentenceService.GetVerbs()
				.Where(x => x.type == VerbType.Have || x.type == VerbType.Past)
				.Select(x => x.name);

			while (ctr < maxCounter)
			{
				sentence = sentenceService.GenerateSentence();

				var sentenceAsArray = sentence.Split(" ");
				var verb = sentenceAsArray[1];
				if (pastTenseHaveVerbs.Contains(verb) && sentenceAsArray.Length == 4)
				{
					matchFoundCtr++;
				}

				ctr++;
			}

			Assert.True(matchFoundCtr > 1);
		}

		#endregion

		#endregion

		#region Fixed Error Conditions

		[Fact]
		public void NoWordHasMoreThanTwoSS()
		{
			var ctr = 1;
			var sentence = "";
			while (ctr < maxCounter)
			{
				sentence = sentenceService.GenerateSentence();
				
				if (sentence.Contains("sss") || sentence.Contains("ssss") || sentence.Contains("ssss"))
				{
					//System.Diagnostics.Debug.WriteLine(sentence + " --- " + ctr.ToString());
					Assert.True(false);
					break;
				}

				ctr++;
			}
		}

		#endregion

		// NOTE: General test to view generated sentences and not meant to be something that is 'tested'
		[Fact]
		public void GenerateSentence()
		{
			var ctr = 1;
			var sentence = "";
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