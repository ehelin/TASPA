export function get(subUrl) {
    var promise = new Promise(
        function (resolve, reject) {
            var request = new XMLHttpRequest();

            request.onreadystatechange = function (err) {
                if (request.readyState === 4) {
                    successCallback();
                }
            };

            var base_url = window.location.origin;
            var url = base_url + subUrl;
            request.open('GET', url, true);

            request.send('');

            successCallback = function () {
                return resolve(request.responseText);
            }
        }
    );

    return promise;
};

export function post(subUrl, formData) {
    var promise = new Promise(
        function (resolve, reject) {
            var request = new XMLHttpRequest();

            request.onreadystatechange = function (err) {
                if (request.readyState === 4) {
                    successCallback();
                }
            };

            var base_url = window.location.origin;
            request.open("POST", base_url + subUrl);
            request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
            request.send(formData);

            successCallback = function () {
                return resolve(request.responseText);
            }
        }
    );

    return promise;
};
