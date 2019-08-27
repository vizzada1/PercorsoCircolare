var _this = this;
var webApiBaseUrl = "http://localhost:8089/api/";
function formatUser(item) {
    return item.LastName + " " + item.FirstName + " - " + item.Username;
}
$(document).ready(function () {
    _this.getAllUsers();
    $("#btnCreate").click(function () {
        _this.createUser();
    });
});
function userDetails(id) {
    $.getJSON(webApiBaseUrl + "Resource/" + id)
        .done((function (user) {
        alert(user.Username + " " + user.FirstName + " " + user.LastName + " " + user.EmailAddress + " " + user.IsActive);
    }))
        .fail(function (jqXHR, textStatus, err) {
        console.error("jqXHR: " + jqXHR);
        console.error("textStatus: " + textStatus);
        console.error("err: " + err);
        console.error("Error While Uploading user details.");
    });
}
function getAllUsers() {
    $("#list-of-users").empty();
    $.getJSON(webApiBaseUrl + "Resource")
        .done((function (users) {
        $.each(users, function (_key, user) {
            console.debug("<li class=\"list-group-item\">" + formatUser(user) + "<a style=\"margin-left:5px;\" href=\"#\" onclick=\"userDetails(" + user.ResourceId + ")\">(View)</a></li>");
            $("#list-of-users").append("<li class=\"list-group-item\">" + formatUser(user) + "<a style=\"margin-left:5px;\" href=\"#\" onclick=\"userDetails(" + user.ResourceId + ")\">(View)</a></li>");
        });
    }))
        .fail(function (jqXHR, textStatus, err) {
        console.error("jqXHR: " + jqXHR);
        console.error("textStatus: " + textStatus);
        console.error("err: " + err);
        console.error("Error While Uploading users.");
    });
}
function createUser() {
    var _this = this;
    var body = JSON.stringify({
        "ResourceId": $("#id").val(),
        "FirstName": $("#firstName").val(),
        "LastName": $("#lastName").val(),
        "EmailAddress": $("#emailAddress").val(),
        "IsActive": $("#isActive").is(":checked")
    });
    console.log(body);
    $.ajax({
        type: "POST",
        url: webApiBaseUrl + "Resource/add",
        contentType: "application/json",
        data: body
    }).done(function (data) {
        console.log(JSON.stringify(data));
        _this.getAllUsers();
    }).fail(function (jqXHR, textStatus, err) {
        console.error("jqXHR: " + jqXHR);
        console.error("textStatus: " + textStatus);
        console.error("err: " + err);
        console.error("Error While Uploading users.");
    });
}
//# sourceMappingURL=resources.js.map