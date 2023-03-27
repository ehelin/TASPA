using System.Collections.Generic;
using Shared.Interfaces;
using Shared.Dto;

namespace DAL
{
    // For now, data is either a json file or hard-coded values called here.
    public class SentimentAnalysisData : ISentimentAnalysisData
    {
        public List<string> GetNegativeWords()
        {
            var words = new List<string>();

            return words;
        }

        public List<string> GetPositiveWords()
        {
            var words = new List<string>();

            return words;
        }
    }
}