//const webApiBaseUrl = "http://localhost:44304/api/";
const webApiBaseUrl = "http://localhost:8089/api/";

function formatUser(item: any): string {
    return item.LastName + " " + item.FirstName + " - " + item.Username;
}

function getAll(): void {
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
        contentType: "json",
    })
        .done(data => {
            alert("dentro");
            $.each(data,
                (_key, item: any) => {
                    $("#list-of-users").append(
                        `<li class="list-group-item">${formatUser(item)
                        }<a style="margin-left:5px;" href="#" onclick="viewUserDetails(${item.ResourceId
                        })">(View)</a><a style="margin-left:5px;" href="#" onclick="updateUser(${item.ResourceId
                        });">(Update)</a><a style="margin-left:5px;" href="#" onclick="deleteUser(${item.ResourceId
                        });">(Delete)</a></li>`);
                });
        })
        .fail(() => {
            alert("Error While Uploading users.");
        });
}