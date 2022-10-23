var ServerCalls = {};

ServerCalls.SetPhraseLists = function () {
    try {
        var path = '/TaspaApi/getPhraseLists';
        return ServerCall.Get(path)
            .then(
                function (response) {
                    var jsonParsed = JSON.parse(response);
                    var phraseListSelectListControl = document.getElementById("phraseListSelectList");

                    for (var i = 0; i < jsonParsed.length; i++) {
                        var currentJson = jsonParsed[i];
                        phraseListSelectListControl.options[phraseListSelectListControl.options.length] = new Option(currentJson, currentJson);
                    }
                });
    }
    catch (ex) {
        throw ex;
    }
};

ServerCalls.SetPhraseList = function (listName) {
    try {
        var path = '/TaspaApi/getPhraseList?phraseListName=' + listName;
        return ServerCall.Get(path)
            .then(
                function (response) {
                    var jsonParsed = JSON.parse(response);

                    InitializePhrases();

                    phraseList = jsonParsed;

                    ServerCalls.SetPhraseJson(jsonParsed[0]);
                });
    }
    catch (ex) {
        throw ex;
    }
};

ServerCalls.SetPhraseJson = function (phraseName) {
    try {
        var path = '/json/spanish/phrases/' + phraseName + '.json';
        return ServerCall.Get(path)
            .then(
                function (response) {
                    var jsonParsed = JSON.parse(response);
                    phraseJson = jsonParsed;

                    PhraseListNext(phraseName, phraseJson);
                });
    }
    catch (ex) {
        throw ex;
    }
};

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

                    InitializeVerbs();

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
        var path = '/json/spanish/verbs/' + verbName + '.json'; 
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