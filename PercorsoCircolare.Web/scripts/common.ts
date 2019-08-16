    class ajaxManager {
        static webApiBaseUrl = "http://localhost:44304/api/";
        static BaseUrl: string;

        static getErrorMessage(r: any): string {
            let msg: string;
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
        }

        static apiGet(url: string, pars?: any, success?: Function, error?: Function) {
            //const paramExtended = $.extend({}, pars, {  });
            $.ajax({
                    url: ajaxManager.webApiBaseUrl + url,
                    //data: paramExtended,
                    type: "GET",
                    dataType: "json",
                    traditional: true
                })
                .done(data => {
                    success ? success(data) : console.debug(url + " ok;");
                })
                .fail((r, s, e) => {
                    const msg = ajaxManager.getErrorMessage(r);
                    console.error(msg);
                })
                .always(() => {
                });
        }

        static apiPost(url: string, pars?: any, success?: Function, error?: Function) {
            const paramExtended = $.extend({}, pars, {  });
            $.ajax({
                url: ajaxManager.webApiBaseUrl + url,
                    data: paramExtended,
                    type: "POST",
                    dataType: "json"
                })
                .done(data => {
                    success ? success(data) : console.debug(url + " ok;");
                })
                .fail((r, s, e) => {
                    const msg = ajaxManager.getErrorMessage(r);
                    console.error(msg);
                })
                .always(() => {
                });
        }

        static apiPut(url: string, pars?: any, success?: Function, error?: Function, always?: Function) {
            const paramExtended = $.extend({}, pars, {  });
            $.ajax({
                    url: ajaxManager.webApiBaseUrl + url,
                    data: paramExtended,
                    type: "PUT",
                    dataType: "json"
                })
                .done(data => {
                    success ? success(data) : console.debug(url + " ok;");
                })
                .fail((r, s, e) => {
                    var msg = ajaxManager.getErrorMessage(r);
                    console.error(msg);
                })
                .always(() => {
                    always ? always() : "";
                });
        }
    }
