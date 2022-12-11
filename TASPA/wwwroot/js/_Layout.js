var skipExecution = false;
function SetNavMenu(show) {
    var mnu = document.getElementById("navMenu");
    var mnuExpd = document.getElementById("navMenuExpanded");

    if (skipExecution === true) {
        skipExecution = false;
        return;
    }

    if (show == 1) {
        mnu.style.display = 'none';
        mnuExpd.style.display = 'block';
        skipExecution = true;
    }
    else if (show === 0) {
        mnu.style.display = 'block';
        mnuExpd.style.display = 'none';
    }
}

function Search() {
    var searchTextBox = document.getElementById("searchTerm");
    var searchTerm = searchTextBox.value;

    var host = window.location.origin; 
    var subUrl = "/Panels/SearchResultsPanel";
    var query = "?searchTerm=" + searchTerm;
    var fullUrl = host + subUrl + query;
    window.location.href = fullUrl;
}

function DisplaySelectedSearchResult(selectedSearchTerm, selectedSearchTermPath)
{
    // TODO - add if based on existing logic and direct to verb or vocabulary page w/appropriate query string
//    var host = window.location.origin; 
//    var subUrl = "/Panels/SearchResultsPanel";
//    var query = "?selectedSearchTerm=" + selectedSearchTerm;
//    var fullUrl = host + subUrl + query;
//    window.location.href = fullUrl;
}

function Resize() {
    var width = window.innerWidth;

    // TODO - make 768 a constant
    if (width <= 768) {
        document.getElementById("mobileMenu").classList.remove('collasped');
        document.getElementById("mobileMenu").classList.add('expanded');
        document.getElementById("desktopMenu").classList.remove('expanded');
        document.getElementById("desktopMenu").classList.add('collasped');
    }
    else {
        document.getElementById("mobileMenu").classList.remove('expanded');
        document.getElementById("mobileMenu").classList.add('collasped');
        document.getElementById("desktopMenu").classList.remove('collasped');
        document.getElementById("desktopMenu").classList.add('expanded');
    }

    VolcabularyPanelResize();
}
