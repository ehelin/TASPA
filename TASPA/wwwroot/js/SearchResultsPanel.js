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