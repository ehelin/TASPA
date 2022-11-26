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
    alert("You clicked Search with term '" + searchTerm + "'");
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
