using System.Collections.Generic;

namespace Shared.Interfaces
{
    public interface ISentenceService
	{
        public string GenerateSentence();

		List<string> GetPronouns();
		int GetMaxCounter();
		int GetPronounPreviousSentenceCheckBatchSize();
	}
}
