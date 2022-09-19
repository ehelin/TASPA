var ServerCalls = {};

ServerCalls.SetVerbLists = function () {
    try {
        var path = '/TaspaApi/getVerbLists';
        return ServerCall.Get(path)
            .then(
                function (response) {
                    var jsonParsed = JSON.parse(response);
                    var verbListSelectListControl = document.getElementById("verbListSelectList");
                    
                    for (var i = 0; i < jsonParsed.length; i++) {
                        var currentJson = jsonParsed[i];
                        verbListSelectListControl.options[verbListSelectListControl.options.length] = new Option(currentJson, currentJson);
                    }
                });
    }
    catch (ex) {
        throw ex;
    }
};

ServerCalls.SetVerbList = function (listName) {
    try {
        var path = '/TaspaApi/getVerbList?verbListName=' + listName;
        return ServerCall.Get(path)
            .then(
                function (response) {
                    var jsonParsed = JSON.parse(response);

                    Initialize();

                    verbList = jsonParsed;

                    ServerCalls.SetVerbJson(jsonParsed[0]);
                });
    }
    catch (ex) {
        throw ex;
    }
};

ServerCalls.SetVerbJson = function (verbName) {
    try {
        var path = '/json/spanish/' + verbName + '.json'; 
        return ServerCall.Get(path)
            .then(
                function (response) {
                    var jsonParsed = JSON.parse(response);
                    verbJson = jsonParsed;

                    VerbListNext(verbName, verbJson);
                });
    }
    catch (ex) {
        throw ex;
    }
};