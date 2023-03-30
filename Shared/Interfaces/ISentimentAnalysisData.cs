using System.Collections.Generic;
using Shared.Dto;
using Shared.Dto.SentimentAnalysis;

namespace Shared.Interfaces
{
    public interface ISentimentAnalysisData
    {
        public List<SentimentAnalysisWord> NegativeWords { get; }
        public List<SentimentAnalysisWord> PositiveWords { get; }
    }
}
