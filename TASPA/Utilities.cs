using BLL;
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
			serviceCollection.AddSingleton<IChatService, ChatServiceOne>();
			serviceCollection.AddSingleton<ISentenceService, SentenceServiceOne>();

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
