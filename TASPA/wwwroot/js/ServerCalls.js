var ServerCalls = {};

//ServerCalls.SetVocabularyLists = function () {
//    try {
//        var path = '/TaspaApi/getVocabularyLists';
//        return ServerCall.Get(path)
//            .then(
//                function (response) {
//                    var jsonParsed = JSON.parse(response);
//                    var vocabularyListSelectListControl = document.getElementById("vocabularyListSelectList");

//                    for (var i = 0; i < jsonParsed.length; i++) {
//                        var currentJson = jsonParsed[i];
//                        vocabularyListSelectListControl.options[vocabularyListSelectListControl.options.length] = new Option(currentJson, currentJson);
//                    }
//                });
//    }
//    catch (ex) {
//        throw ex;
//    }
//};

ServerCalls.SetVocabularyList = function (vocabularyFolder, listName) {
    try {
        var path = '/TaspaApi/getVocabularyList?vocabularyListName=' + listName;
        return ServerCall.Get(path)
            .then(
                function (response) {
                    var jsonParsed = JSON.parse(response);

                    InitializeVocabulary();

                    vocabularyList = jsonParsed;

                    ServerCalls.SetVocabularyJson(vocabularyFolder, jsonParsed[0]);
                });
    }
    catch (ex) {
        throw ex;
    }
};

ServerCalls.SetVocabularyJson = function (vocabularyFolder, vocabularyName) {
    try {
        var path = '/json/spanish/vocabulary/' + vocabularyFolder + '/' + vocabularyName + '.json';
        return ServerCall.Get(path)
            .then(
                function (response) {
                    var jsonParsed = JSON.parse(response);
                    vocabularyJson = jsonParsed;

                    VocabularyListNext(vocabularyName, vocabularyJson);
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