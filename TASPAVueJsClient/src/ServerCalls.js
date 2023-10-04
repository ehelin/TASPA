import { get, post } from './ServerCall';

export function getNavigationLinks() {
    try {
        var path = '/TaspaApi/getVueJsNavigationLinks'; 

        return get(path)
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