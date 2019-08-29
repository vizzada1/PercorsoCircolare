webApiBaseUrl = "http://localhost:8089/api/";

$(".dropdown").click(function () {
    populateBuildingDropdown();
    $(this).attr("tabindex", 1).focus();
    $(this).toggleClass("active");
    $(this).find(".dropdown-menu").slideToggle(300);
});
$(".dropdown").focusout(function () {
    $(this).removeClass("active");
    $(this).find(".dropdown-menu").slideUp(300);
});
$(".dropdown .dropdown-menu li").click(function () {
    $(this).parents(".dropdown").find("span").text($(this).text());
    $(this).parents(".dropdown").find("input").attr("value", $(this).attr("id"));
});
/*End Dropdown Menu*/

$(document).ready(() => {
    this.getAllRooms();

    $("#btnCreateRoom").click(() => {
        this.createBuilding();
        $("#name").val("");
        $("#address").val("");
        $("#createRoom").modal("toggle");
    });
});

function populateBuildingDropdown(): void {
    $("#dropdown-rooms").empty();

    $.getJSON(webApiBaseUrl + "Building")
        .done(((buildings: Building[]) => {
            $.each(buildings,
                (_key, building: Building) => {
                    $("#dropdown-rooms").append(`<li id="${building.BuildingId}">${building.Name}</li>`);
                });
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading buildings.");
        });
    
}

function formatRoom(item: Room): string {
    return item.Name + " con " + item.AvailableSeats + " posti ed è in edificio:" + item.Building;
}

function roomDetails(id: number): void {
    $.getJSON(webApiBaseUrl + "Room/" + id)
        .done(((room: Room) => {
            alert(formatRoom(room));
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading building details.");
        });
}

function getAllRooms(): void {
    $("#list-of-rooms").empty();

    $.getJSON(webApiBaseUrl + "Room")
        .done(((rooms: Room[]) => {
            $.each(rooms,
                (_key, room: Room) => {
                    console.debug(`<li class="list-group-item">${formatRoom(room)}<a style="margin-left:5px;" href="#" onclick="roomDetails(${room.RoomId})">(View)</a></li>`);
                    $("#list-of-rooms").append(`<li class="list-group-item">${formatRoom(room)}<a style="margin-left:5px;" href="#" onclick="buildingDetails(${room.RoomId})">(View)</a></li>`);
                });
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading buildings.");
        });
}

function createRooms(): void {
    let body = JSON.stringify({
        "AvailableSeats": $("#availableSeats").val(),
        "Name": $("#roomName").val(),
        "IsActive": $("#isActive").is(":checked")
    });
    console.log(body);
    $.ajax({
        type: "POST",
        url: webApiBaseUrl + "Rooms/add",
        contentType: "application/json",
        data: body
    }).done((data) => {
        console.log(JSON.stringify(data));
        this.getAllRooms();
    }).fail((jqXHR, textStatus, err) => {
        console.error(`jqXHR: ${jqXHR}`);
        console.error(`textStatus: ${textStatus}`);
        console.error(`err: ${err}`);
        console.error("Error While Uploading buildings.");
    });
}