const webApiBaseUrl = "http://localhost:8089/api/";

function formatBuilding(item: Building): string {
    return item.Name + " " + item.Address;
}

$(document).ready(() => {
    this.getAllBuildings();

    $("#btnCreateBuilding").click(() => {
        this.createBuilding();
        $("#name").val("");
        $("#address").val("");
        $("#createBuilding").modal("toggle");
    });
});

function buildingDetails(id: number): void {
    $.getJSON(webApiBaseUrl + "Building/" + id)
        .done(((building: any) => {
            alert(building.Name + " " + building.Address + " " + building.IsActive);
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading building details.");
        });
}

function getAllBuildings(): void {
    $("#list-of-buildings").empty();

    $.getJSON(webApiBaseUrl + "Building")
        .done(((buildings: Building[]) => {
            $.each(buildings,
                (_key, building: Building) => {
                    console.debug(`<li class="list-group-item">${formatBuilding(building)}<a style="margin-left:5px;" href="#" onclick="buildingDetails(${building.BuildingId})">(View)</a></li>`);
                    $("#list-of-buildings").append(`<li class="list-group-item">${formatBuilding(building)}<a style="margin-left:5px;" href="#" onclick="buildingDetails(${building.BuildingId})">(View)</a></li>`);
                });
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading buildings.");
        });
}

function createBuilding(): void {
    let body = JSON.stringify({
        "Address": $("#address").val(),
        "Name": $("#name").val(),
        "IsActive": $("#isActive").is(":checked")
    });
    console.log(body);
    $.ajax({
        type: "POST",
        url: webApiBaseUrl + "Building/add",
        contentType: "application/json",
        data: body
    }).done((data) => {
        console.log(JSON.stringify(data));
        this.getAllBuildings();
    }).fail((jqXHR, textStatus, err) => {
        console.error(`jqXHR: ${jqXHR}`);
        console.error(`textStatus: ${textStatus}`);
        console.error(`err: ${err}`);
        console.error("Error While Uploading buildings.");
    });
}