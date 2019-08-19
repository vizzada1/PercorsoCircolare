var webApiBaseUrl = "http://localhost:61147/api/";
//const webApiBaseUrl = "http://localhost:44346/api/";
function formatUser(item) {
    return item.LastName + " " + item.FirstName + " - " + item.Username;
}
function getAll() {
    $("#list-of-users").empty();
    //ajaxManager.apiGet("Resource", null, (users: any) => {
    //    $.each(users,
    //        (_key, item: any) => {
    //            $("#list-of-users").append(
    //                `<li class="list-group-item">${formatUser(item)
    //                }<a style="margin-left:5px;" href="#" onclick="viewUserDetails(${item.ResourceId
    //                })">(View)</a><a style="margin-left:5px;" href="#" onclick="updateUser(${item.ResourceId
    //                });">(Update)</a><a style="margin-left:5px;" href="#" onclick="deleteUser(${item.ResourceId});">(Delete)</a></li>`);
    //        });
    //$.getJSON(webApiBaseUrl + "Resource")
    //    .done((users: any) => {
    //        $.each(users,
    //            (_key, item: any) => {
    //                $("#list-of-users").append(
    //                    `<li class="list-group-item">${formatUser(item)
    //                    }<a style="margin-left:5px;" href="#" onclick="viewUserDetails(${item.ResourceId
    //                    })">(View)</a><a style="margin-left:5px;" href="#" onclick="updateUser(${item.ResourceId
    //                    });">(Update)</a><a style="margin-left:5px;" href="#" onclick="deleteUser(${item.ResourceId
    //                    });">(Delete)</a></li>`);
    //            });
    //    })
    //    .fail(() => {
    //        alert("Error While Uploading users.");
    //    });
    $.ajax({
        type: "GET",
        url: webApiBaseUrl + "Resource",
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
        success: function (data) {
            console.debug("dentro");
            $.each(data, function (_key, item) {
                $("#list-of-users").append("<li class=\"list-group-item\">" + formatUser(item) + "<a style=\"margin-left:5px;\" href=\"#\" onclick=\"viewUserDetails(" + item.ResourceId + ")\">(View)</a><a style=\"margin-left:5px;\" href=\"#\" onclick=\"updateUser(" + item.ResourceId + ");\">(Update)</a><a style=\"margin-left:5px;\" href=\"#\" onclick=\"deleteUser(" + item.ResourceId + ");\">(Delete)</a></li>");
            });
        },
        error: function () {
            alert("Error While Uploading users.");
            console.error("Error While Uploading users.");
        }
    });
    //    .done(data => {
    //        alert("dentro");
    //        console.debug("dentro");
    //        $.each(data,
    //            (_key, item: any) => {
    //                $("#list-of-users").append(
    //                    `<li class="list-group-item">${formatUser(item)
    //                    }<a style="margin-left:5px;" href="#" onclick="viewUserDetails(${item.ResourceId
    //                    })">(View)</a><a style="margin-left:5px;" href="#" onclick="updateUser(${item.ResourceId
    //                    });">(Update)</a><a style="margin-left:5px;" href="#" onclick="deleteUser(${item.ResourceId
    //                    });">(Delete)</a></li>`);
    //            });
    //    })
    //    .fail(() => {
    //        alert("Error While Uploading users.");
    //        console.error("Error While Uploading users.");
    //    });
}
//# sourceMappingURL=resources.js.map