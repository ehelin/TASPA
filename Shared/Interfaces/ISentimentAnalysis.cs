using System.Collections.Generic;
using Shared.Dto.Sentence;

namespace Shared.Interfaces
{
	public interface ISentenceService
	{
        public string GenerateSentence();

		List<string> GetPronouns();
		List<SentenceVerb> GetVerbs();
		int GetMaxCounter();
		int GetPronounPreviousSentenceCheckBatchSize();
	}
}
