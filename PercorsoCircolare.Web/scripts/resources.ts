function formatUser(item: any): string {
    return item.lastName + " " + item.FirstName + " - " + item.Username;
}

function getAll(): void {
    $("#list-of-users").empty();
    ajaxManager.apiGet("Resource", null, (users: any) => {
        $.each(users,
            (_key, item: any) => {
                $("#list-of-users").append(
                    `<li class="list-group-item">${formatUser(item)
                    }<a style="margin-left:5px;" href="#" onclick="viewUserDetails(${item.ResourceId
                    })">(View)</a><a style="margin-left:5px;" href="#" onclick="updateUser(${item.ResourceId
                    });">(Update)</a><a style="margin-left:5px;" href="#" onclick="deleteUser(${item.ResourceId});">(Delete)</a></li>`);
            });
    });
}