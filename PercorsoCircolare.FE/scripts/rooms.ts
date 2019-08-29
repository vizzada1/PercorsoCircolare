webApiBaseUrl = "http://localhost:8089/api/";

$(document).ready(() => {
    this.getAllRooms();

    $("#btnCreateRoom").click(() => {
        this.createRoom();
        $("#name").val("");
        $("#address").val("");
        $("#createRoom").modal("toggle");
    });
    populateBuildingDropdown();
});

function populateBuildingDropdown(): void {
    //$("#roomSelect").empty();

    $.getJSON(webApiBaseUrl + "Building")
        .done(((buildings: Building[]) => {
            $.each(buildings,
                (_key, building: Building) => {
                    $("#roomSelect").append(`<option value="${building.BuildingId}">${building.Name}</li>`);
                });
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading rooms.");
        });
    
}

function formatRoom(item: Room): string {
    return item.Name + " con " + item.AvailableSeats + " posti";
}

function formatRoomDetail(item: Room, buildingName: string): string {
    return item.Name + " con " + item.AvailableSeats + " posti ed è in edificio " + buildingName;
}

function roomDetails(id: number): void {
    $.getJSON(webApiBaseUrl + "Room/" + id)
        .done(((room: Room) => {
            $.getJSON(webApiBaseUrl + "Building/" + room.BuildingId)
                .done(((building: Building) => {
                    alert(formatRoomDetail(room, building.Name));
                }) as any)
                .fail((jqXHR, textStatus, err) => {
                    console.error(`jqXHR: ${jqXHR}`);
                    console.error(`textStatus: ${textStatus}`);
                    console.error(`err: ${err}`);
                    console.error("Error While Uploading building details.");
                });
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading room details.");
        });
}

function getAllRooms(): void {
    $("#list-of-rooms").empty();

    $.getJSON(webApiBaseUrl + "Room")
        .done(((rooms: Room[]) => {
            $.each(rooms,
                (_key, room: Room) => {
                    console.debug(`<li class="list-group-item">${formatRoom(room)}<a style="margin-left:5px;" href="#" onclick="roomDetails(${room.RoomId})">(View)</a></li>`);
                    $("#list-of-rooms").append(`<li class="list-group-item">${formatRoom(room)}<a style="margin-left:5px;" href="#" onclick="roomDetails(${room.RoomId})">(View)</a></li>`);
                });
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading rooms.");
        });
}

function createRoom(): void {
    let body = JSON.stringify({
        "AvailableSeats": $("#availableSeats").val(),
        "Name": $("#roomName").val(),
        "IsActive": $("#isActive").is(":checked"),
        "BuildingId": $("#roomSelect").children("option:selected").val()
});
    console.log(body);
    $.ajax({
        type: "POST",
        url: webApiBaseUrl + "Room/add",
        contentType: "application/json",
        data: body
    }).done((data) => {
        console.log(JSON.stringify(data));
        this.getAllRooms();
    }).fail((jqXHR, textStatus, err) => {
        console.error(`jqXHR: ${jqXHR}`);
        console.error(`textStatus: ${textStatus}`);
        console.error(`err: ${err}`);
        console.error("Error While Uploading rooms.");
    });
}