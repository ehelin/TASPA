﻿using BLL;
using BLL.Experiments;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using Shared.Dto;
using Shared.Interfaces;

namespace TASPA
{
    public class Utilities
    {
        public static IServiceCollection SetDI(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITaspaData, TaspaData>();
            serviceCollection.AddSingleton<ITaspaService, TaspaService>();
			serviceCollection.AddSingleton<ISentenceService, SentenceService>();
            serviceCollection.AddSingleton<ISentimentAnalysis, SentimentAnalysis>();
            serviceCollection.AddSingleton<ISentimentAnalysisData, SentimentAnalysisData>();

			// the 'goal' is to add ways to grab either implementation in constructor...so far, doesn't work (.net 8 has native solution I think)
			serviceCollection.AddSingleton<IChatService, ChatServiceOne>(sp =>
			{
				var dependency1 = sp.GetRequiredService<ISentenceService>();
				var dependency2 = sp.GetRequiredService<ISentimentAnalysis>();
				return new ChatServiceOne(dependency1, dependency2);
			});
			serviceCollection.AddSingleton<IChatService, ChatServiceAiModelApi>(sp => new ChatServiceAiModelApi());

			return serviceCollection;
        }

        public static string GetSearchResultsTargetUrl(SearchTerm searchResult)
        {
            var searchResultsTargetUrl = string.Empty;
            if(searchResult.JsonPath.ToLower().Contains("verb"))
            {
                searchResultsTargetUrl = string.Format("/Panels/VerbsPanel?selectedSearchTerm={0}", searchResult.Name);
            }
            else
            {
                var jsonPath = searchResult.JsonPath;
                var end = jsonPath.LastIndexOf("\\");
                if(end > 0)
                {
                    var vocabularyListName = jsonPath.Substring(0,end);
                    var start = vocabularyListName.LastIndexOf("\\");
                    if(start > 0)
                    {
                        start += 1;
                        vocabularyListName = vocabularyListName.Substring(start,vocabularyListName.Length - start);
                        searchResultsTargetUrl = string.Format("/Panels/VocabularyPanel?selectedSearchTerm={0}&vocabularyList={1}", searchResult.Name, vocabularyListName);
                    }
                }
            }

            return searchResultsTargetUrl;
        }
    }
}
