const webApiBaseUrl = "http://localhost:8089/api/";

function formatUser(item: User): string {
    return item.LastName + " " + item.FirstName + " - " + item.Username;
}

function userDetails(id: number): void {
    $.getJSON(webApiBaseUrl + "Resource/" + id)
        .done(((user: User) => {
            alert(user.Username + " " + user.FirstName + " " + user.LastName + " " + user.EmailAddress + " " + user.IsActive);
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading user details.");
        });
}

function getAll(): void {
    $("#list-of-users").empty();

    $.getJSON(webApiBaseUrl + "Resource")
        .done(((users: User[]) => {
            $.each(users,
                (_key, user: User) => {
                    console.debug(`<li class="list-group-item">${formatUser(user)}<a style="margin-left:5px;" href="#" onclick="userDetails(${user.ResourceId})">(View)</a></li>`);
                    $("#list-of-users").append(`<li class="list-group-item">${formatUser(user)}<a style="margin-left:5px;" href="#" onclick="userDetails(${user.ResourceId})">(View)</a></li>`);
                });
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading users.");
        });
}