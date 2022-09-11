var ServerCalls = {};

ServerCalls.GetVerbList = function (listName) {
    try {
        var path = '/TaspaApi/getVerbList?verbListName=' + listName;
        return ServerCall.Get(path)
            .then(
                function (jsonResponse) {
                    var jsonParsed = JSON.parse(jsonResponse);
                    SetJson(jsonParsed, listDisplay);
                });
    }
    catch (ex) {
        return Error_Handler('ServerCalls.GetJson(3 args) - ' + view + ' - Error: ' + ex);
    }
};