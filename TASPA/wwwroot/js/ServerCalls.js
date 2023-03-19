var ServerCalls = {};

ServerCalls.Search = function (searchTerm) {
    try {
        var path = '/TaspaApi/search?searchTerm=' + searchTerm;
        return ServerCall.Get(path)
            .then(
                function (response) {
                    var jsonParsed = JSON.parse(response);

                    InitializeSearch(jsonParsed);
                });
    }
    catch (ex) {
        throw ex;
    }
}

ServerCalls.SetVocabularyList = function (folder, searchTerm) {
    try {
        var path = '/TaspaApi/getVocabularyList?vocabularyListName=' + folder;
        return ServerCall.Get(path)
            .then(
                function (response) {
                    var jsonParsed = JSON.parse(response);

                    InitializeVocabulary();

                    vocabularyList = jsonParsed;
                    vocabularyFolder = folder;

                    var jsonTerm = jsonParsed[0];
                    if (searchTerm != null && searchTerm != undefined && searchTerm.length > 0)
                    {
                        var textArea = document.createElement('textarea');
                        textArea.innerHTML = searchTerm;
                        var decodedSearchTerm = textArea.value;
                        jsonTerm = decodedSearchTerm.replace(' ', '_');
                    }

                    ServerCalls.SetVocabularyJson(folder, jsonTerm);
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

                    ServerCalls.SetLastVocabularyListUsedDisplay();
                });
    }
    catch (ex) {
        throw ex;
    }
};

ServerCalls.SetVerbLists = function (searchTerm, searchVerbList) {
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

                    if (searchTerm != null && searchTerm != undefined && searchTerm.length>0)
                    {
                        ServerCalls.SetVerbList(searchVerbList, searchTerm);
                    }

                    ServerCalls.SetLastVerbListUsedDisplay();
                });        
    }
    catch (ex) {
        throw ex;
    }
};

ServerCalls.SetLastVerbListUsedDisplay = function (searchTerm, searchVerbList) {
    try {
        var path = '/TaspaApi/getLastVerbListUsed';
        return ServerCall.Get(path)
            .then(
                function (response) {
                    SetLastVerbListUsed(response);
                });
    }
    catch (ex) {
        throw ex;
    }
};

ServerCalls.SetLastVocabularyListUsedDisplay = function (searchTerm, searchVerbList) {
    try {
        var path = '/TaspaApi/getLastVocabularyListUsed';
        return ServerCall.Get(path)
            .then(
                function (response) {
                    SetLastVocabularyListUsed(response);
                });
    }
    catch (ex) {
        throw ex;
    }
};

// NOTE: searchTerm is sometimes null
ServerCalls.SetVerbList = function (listName, searchTerm) {
    try {
        var path = '/TaspaApi/getVerbList?verbListName=' + listName;
        return ServerCall.Get(path)
            .then(
                function (response) {
                    var jsonParsed = JSON.parse(response);

                    InitializeVerbs();

                    verbList = jsonParsed;

                    if (searchTerm != null && searchTerm != undefined && searchTerm.length>0)
                    {
                        ServerCalls.SetVerbJson(searchTerm);
                    }
                    else
                    {
                        ServerCalls.SetVerbJson(jsonParsed[0]);
                    }
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

                    ServerCalls.SetLastVerbListUsedDisplay();
                });
    }
    catch (ex) {
        throw ex;
    }
};

// Chat
ServerCalls.SendChatMessage = function (chatMessage, chatConversationTextArea) {
    try {
        var path = '/TaspaApi/sendChatMessage?chatMessage=' + chatMessage;
        return ServerCall.Get(path)
            .then(
                function (response) {
                    var chatResponse = response;

                    var chatTextBox = document.getElementById("chatMessage");
                    chatTextBox.value = '';

                    var chatContents = chatConversationTextArea.value;
                    chatConversationTextArea.value = chatContents + '\r\n' + chatResponse;
                    chatConversationTextArea.blur();
                    chatConversationTextArea.focus(); // this scrolls the textarea
                });
    }
    catch (ex) {
        throw ex;
    }
};

ServerCalls.ClearChatSession = function () {
    try {
        var path = '/TaspaApi/clearChatSession';
        return ServerCall.Get(path);
    }
    catch (ex) {
        throw ex;
    }
};