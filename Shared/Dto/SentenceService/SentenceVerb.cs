using System.Collections.Generic;

namespace Shared.Dto.Sentence
{
	public class SentenceVerb
	{
		public string name { get; set; }
		public VerbType type { get; set; }
		public bool pronouns { get; set; }

		public List<NounType> nounType { get; set;}
	}
}
