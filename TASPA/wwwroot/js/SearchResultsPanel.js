//function InitializeSearch(jsonResults) {
//    verbList = [];
//    verbListIndex = 0;

//    var searchResults = '<table width="80%">';
//    for(var ctr=0; ctr<jsonResults.length; ctr++)
//    {
//        searchResults = searchResults + '<tr><td>';

//        var currentResult = 'Name: ' + jsonResults[ctr].name 
//            + ', English Meaning: ' + jsonResults[ctr].englishMeaning 
//            + ', <a href="' + jsonResults[ctr].jsonPath + '">Source List</a>'; 

//        searchResults = searchResults + currentResult;

//        searchResults = searchResults + '</td></tr>';
//    }
//    searchResults = searchResults + '</table>';

//    var searchResultsPanel = document.getElementById("searchResultsPanel");
//    searchResultsPanel.innerHTML = searchResults;
//}

function Search() {
    var searchTextBox = document.getElementById("searchTerm");
    var searchTerm = searchTextBox.value;

    var host = window.location.origin;
    var subUrl = "/Panels/SearchResultsPanel";
    var query = "?searchTerm=" + searchTerm;
    var fullUrl = host + subUrl + query;
    window.location.href = fullUrl;
}

function DisplaySelectedSearchResult(selectedSearchTerm, selectedSearchTermPath) {
    try {
        var subUrl = '';
        if (selectedSearchTermPath.indexOf('verb') != -1) {
            subUrl = "/Panels/VerbsPanel";
        }
        else {
            subUrl = "/Panels/VocabularyPanel";
        }
        var host = window.location.origin;
        var query = "?selectedSearchTerm=" + selectedSearchTerm;// + "&jsonPath=" + selectedSearchTermPath;
        var fullUrl = host + subUrl + query;
                
        window.location.href = null;

        window.location.href = fullUrl;
    }
    catch (err) {
        let test = 1;
        //document.getElementById("demo").innerHTML = err.message;
    }
}