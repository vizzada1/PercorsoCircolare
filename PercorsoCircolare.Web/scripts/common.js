var ajaxManager = /** @class */ (function () {
    function ajaxManager() {
    }
    ajaxManager.getErrorMessage = function (r) {
        var msg;
        if (r.responseJSON) {
            msg = r.responseText.length > 0 ? r.responseText : r.statusText;
            if (r.responseJSON.ExceptionMessage && r.responseJSON.ExceptionMessage.length > 0) {
                msg = r.responseJSON.ExceptionMessage;
            }
            else {
                if (r.responseJSON.Message && r.responseJSON.Message.length > 0) {
                    msg = r.responseJSON.Message;
                }
            }
        }
        else {
            msg = r.statusMessage;
        }
        return msg;
    };
    ajaxManager.apiGet = function (url, pars, success, error) {
        var paramExtended = $.extend({}, pars, { login: "" });
        $.ajax({
            url: ajaxManager.webApiBaseUrl + url,
            data: paramExtended,
            type: "GET",
            dataType: "application/json",
            traditional: true
        })
            .done(function (data) {
            success ? success(data) : console.debug(url + " ok;");
        })
            .fail(function (r, s, e) {
            var msg = ajaxManager.getErrorMessage(r);
            console.error(msg);
        })
            .always(function () {
            console.error("");
        });
    };
    ajaxManager.apiPost = function (url, pars, success, error) {
        var paramExtended = $.extend({}, pars, {});
        $.ajax({
            url: ajaxManager.webApiBaseUrl + url,
            data: paramExtended,
            type: "POST",
            dataType: "json"
        })
            .done(function (data) {
            success ? success(data) : console.debug(url + " ok;");
        })
            .fail(function (r, s, e) {
            var msg = ajaxManager.getErrorMessage(r);
            console.error(msg);
        })
            .always(function () {
        });
    };
    ajaxManager.apiPut = function (url, pars, success, error, always) {
        var paramExtended = $.extend({}, pars, {});
        $.ajax({
            url: ajaxManager.webApiBaseUrl + url,
            data: paramExtended,
            type: "PUT",
            dataType: "json"
        })
            .done(function (data) {
            success ? success(data) : console.debug(url + " ok;");
        })
            .fail(function (r, s, e) {
            var msg = ajaxManager.getErrorMessage(r);
            console.error(msg);
        })
            .always(function () {
            always ? always() : "";
        });
    };
    ajaxManager.webApiBaseUrl = "http://localhost:44304/api/";
    return ajaxManager;
}());
//# sourceMappingURL=common.js.map