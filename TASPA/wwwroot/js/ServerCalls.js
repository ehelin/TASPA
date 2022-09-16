var ServerCalls = {};

ServerCalls.SetVerbList = function (listName) {
    try {
        var path = '/TaspaApi/getVerbList?verbListName=' + listName;
        return ServerCall.Get(path)
            .then(
                function (response) {
                    var jsonParsed = JSON.parse(response);

                    Initialize();
                    verbList = jsonParsed;

                    var verbSubPanelContent = document.getElementById("verbSubPanel");
                    verbSubPanelContent.classList.remove('collasped');
                    verbSubPanelContent.classList.add('expanded');

                    VerbListNext();
                });
    }
    catch (ex) {
        throw ex;
    }
};