var ServerCalls = {};

ServerCalls.SetVerbList = function (listName) {
    try {
        var path = '/TaspaApi/getVerbList?verbListName=' + listName;
        return ServerCall.Get(path)
            .then(
                function (response) {
                    var jsonParsed = JSON.parse(response);

                    var verbSubPanelContent = document.getElementById("verbSubPanel");
                    verbSubPanelContent.classList.remove('collasped');
                    verbSubPanelContent.classList.add('expanded');

                    var verbSubPanelContent = document.getElementById("verbSubPanelContent");
                    verbSubPanelContent.append(jsonParsed);
                });
    }
    catch (ex) {
        throw ex;
    }
};

//ServerCalls.SetNavigationLinks = function () {
//    try {
//        var path = '/TaspaApi/getNavigationLinks';
//        return ServerCall.Get(path)
//            .then(
//                function (response) {
//                    var jsonParsed = JSON.parse(response);
//                    var mobileNavigationLinksContainer = document.getElementById("navMenuExpanded");
//                    var desktopNavigationLinksContainer = document.getElementById("deskNavigationLinks");

//                    var desktopNavigationLinks = '<br />';
//                    for (var i = 0; i < jsonParsed.length; i++) {
//                        var currentLink = jsonParsed[i];
//                        desktopNavigationLinks += '<a href="' + currentLink.linkAction + '">' + currentLink.linkText + '</a>&nbsp;';
//                    }

//                    desktopNavigationLinksContainer.innerHTML = desktopNavigationLinks;

//                    var mobileNavigationLinks = '<br />';
//                    mobileNavigationLinks += '<a href="" onclick="SetNavMenu(0);">close</a>';
//                    for (var i = 0; i < jsonParsed.length; i++) {
//                        var currentLink = jsonParsed[i];
//                        mobileNavigationLinks += '<a href="' + currentLink.linkAction + '">' + currentLink.linkText + '</a>';
//                    }

//                    mobileNavigationLinksContainer.innerHTML = 'hi mom';
//                });
//    }
//    catch (ex) {
//        throw ex;
//    }
//};