function InitializeSearch(jsonResults) {
    verbList = [];
    verbListIndex = 0;

    var searchResults = '<table width="80%">';
    for(var ctr=0; ctr<jsonResults.length; ctr++)
    {
        searchResults = searchResults + '<tr><td>';

        var currentResult = 'Name: ' + jsonResults[ctr].name 
            + ', English Meaning: ' + jsonResults[ctr].englishMeaning 
            + ', <a href="' + jsonResults[ctr].jsonPath + '">Source List</a>'; 
                
        searchResults = searchResults + currentResult;
        
        searchResults = searchResults + '</td></tr>';
    }
    searchResults = searchResults + '</table>';
    
    var searchResultsPanel = document.getElementById("searchResultsPanel");
    searchResultsPanel.innerHTML = searchResults;
}