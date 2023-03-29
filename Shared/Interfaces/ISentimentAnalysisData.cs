using System.Collections.Generic;
using Shared.Dto;

namespace Shared.Interfaces
{
    public interface ISentimentAnalysisData
    {
        public List<string> GetPositiveWords();
        public List<string> GetNegativeWords();
    }
}
