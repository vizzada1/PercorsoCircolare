﻿webApiBaseUrl = "http://localhost:8089/api/";

var userIdList:string[] = [];

function formatUser(item: User): string {
    return item.LastName + " " + item.FirstName + " - " + item.Username;
}

$(document).ready(() => {
    this.getAllUsers();

    $("#btnCreate").click(() => {
        this.createUser();
        $("#id").val("");
        $("#firstName").val("");
        $("#lastName").val("");
        $("#emailAddress").val("");
        $("#createUser").modal("toggle");
    });
});

function userDetails(id: number): void {
    $.getJSON(webApiBaseUrl + "Resource/" + id)
        .done(((user: any) => {
            alert(user.ResourceId + " " + user.Username + " " + user.FirstName + " " + user.LastName + " " + user.EmailAddress + " " + user.IsActive);
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading user details.");
        });
}

function getAllUsers(): void {
    $("#list-of-users").empty();

    $.getJSON(webApiBaseUrl + "Resource")
        .done(((users: User[]) => {
            $.each(users,
                (_key, user: User) => {
                    userIdList.push(user.ResourceId.toString());
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

function createUser(): void {
    if ($("#id").val() === "" || $("#firstName").val() === "" || $("#lastName").val() === "" || $("#emailAddress").val() === "") {
        alert("You need to valorize every field");
        return;
    }

    if (jQuery.inArray($("#id").val(), userIdList).valueOf() !== -1) {
        alert(`A user with ${$("#id").val()} already exists`);
        return;
    }

    let body = JSON.stringify({
        "ResourceId": $("#id").val(),
        "FirstName": $("#firstName").val(),
        "LastName": $("#lastName").val(),
        "EmailAddress": $("#emailAddress").val(),
        "IsActive": $("#isActive").is(":checked")
    });
    $.ajax({
        type: "POST",
        url: webApiBaseUrl + "Resource/add",
        contentType: "application/json",
        data: body
    }).done((data) => {
        this.getAllUsers();
    }).fail((jqXHR, textStatus, err) => {
        console.error(`jqXHR: ${jqXHR}`);
        console.error(`textStatus: ${textStatus}`);
        console.error(`err: ${err}`);
        console.error("Error While Uploading users.");
    });
}