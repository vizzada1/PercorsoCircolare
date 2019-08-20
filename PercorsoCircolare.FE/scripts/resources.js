//const webApiBaseUrl = "http://localhost:61147/api/";
var webApiBaseUrl = "http://localhost:44346/api/";
function formatUser(item) {
    return item.lastName + " " + item.firstName + " - " + item.username;
}
function getAll() {
    $("#list-of-users").empty();
    $.ajax({
        type: "GET",
        url: webApiBaseUrl + "Resource",
        contentType: "application/json",
    })
        .done((function (data) {
        alert("dentro");
        console.debug("dentro");
        var users = User.mapToUsers(data);
        $.each(users, function (_key, item) {
            $("#list-of-users").append("<li class=\"list-group-item\">" + formatUser(item) + "<a style=\"margin-left:5px;\" href=\"#\" onclick=\"viewUserDetails(" + item.resourceId + ")\">(View)</a><a style=\"margin-left:5px;\" href=\"#\" onclick=\"updateUser(" + item.resourceId + ");\">(Update)</a><a style=\"margin-left:5px;\" href=\"#\" onclick=\"deleteUser(" + item.resourceId + ");\">(Delete)</a></li>");
        });
    }))
        .fail(function (jqXHR, textStatus, err) {
        console.error("jqXHR: " + jqXHR);
        console.error("textStatus: " + textStatus);
        console.error("err: " + err);
        alert("Error While Uploading users.");
        console.error("Error While Uploading users.");
    });
    //$.getJSON(webApiBaseUrl + "Resource")
    //    .done(((data: any) => {
    //        alert("dentro");
    //        console.debug("dentro");
    //        let users: Array<User> = User.mapToUsers(data);
    //        $.each(users,
    //            (_key, item: User) => {
    //                $("#list-of-users").append(
    //                    `<li class="list-group-item">${formatUser(item)
    //                    }<a style="margin-left:5px;" href="#" onclick="viewUserDetails(${item.resourceId
    //                    })">(View)</a><a style="margin-left:5px;" href="#" onclick="updateUser(${item.resourceId
    //                    });">(Update)</a><a style="margin-left:5px;" href="#" onclick="deleteUser(${item.resourceId
    //                    });">(Delete)</a></li>`);
    //            });
    //    }) as any)
    //    .fail((jqXHR, textStatus, err) => {
    //        console.error(`jqXHR: ${jqXHR}`);
    //        console.error(`textStatus: ${textStatus}`);
    //        console.error(`err: ${err}`);
    //        alert("Error While Uploading users.");
    //        console.error("Error While Uploading users.");
    //    });
}
//# sourceMappingURL=resources.js.map