using System.Collections.Generic;
using Shared.Dto;

namespace Shared.Interfaces
{
    public interface ISentimentAnalysisData
    {
        public List<string> NegativeWords { get; }
        public List<string> PositiveWords { get; }
        //List<string> ParentNumber
        //{
        //    get;
        //}
    }
}
