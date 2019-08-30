webApiBaseUrl = "http://localhost:8089/api/";
var allBookings: Booking[] = [];

$(document).ready(() => {
     this.getAllBookings();

    $("#btnCreateBooking").click(() => {
        this.createBooking();
        $("#description").val("");
        $("#datepickerStart").val("");
        $("#datepickerEnd").val("");
        $("#createBooking").modal("toggle");
        $("#resourceSelect").prop("selectedIndex", 0);
        $("#roomSelect").prop("selectedIndex", 0);
    });
    populateResourceDropdown();
    populateRoomDropdown();
});

function searchFilter(): void {
    var input, filter, ul, li, a, i, txtValue;
    input = document.getElementById("filterNames");
    filter = input.value.toUpperCase();
    ul = document.getElementById("list-of-bookings");
    li = ul.getElementsByTagName("li");
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("a")[0];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}

function populateResourceDropdown(): void {
    //$("#roomSelect").empty();

    $.getJSON(webApiBaseUrl + "Resource")
        .done(((resources: User[]) => {
            $.each(resources,
                (_key, resource: User) => {
                    $("#resourceSelect").append(`<option value="${resource.ResourceId}">${resource.FirstName} ${resource.LastName}: ${resource.Username}</li>`);
                });
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading rooms.");
        });
}

function populateRoomDropdown(): void {
    //$("#roomSelect").empty();

    $.getJSON(webApiBaseUrl + "Room")
        .done(((rooms: Room[]) => {
            $.each(rooms,
                (_key, room: Room) => {
                    $("#roomSelect").append(`<option value="${room.RoomId}">${room.Name}</li>`);
                });
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading rooms.");
        });
}

function formatBooking(item: Booking): string {
    let splittedStart = item.DateStart.toLocaleString().split("-");
    return `Prenotazione <a href="#">${item.Description}</a> del ${splittedStart[0]}/${splittedStart[1]}/${splittedStart[2].split("T")[0]}`;
}

function formatBookingDetail(item: Booking, resourceName: string): string {
    let splittedStart = item.DateStart.toLocaleString().split("-");
    let splittedEnd = item.DateEnd.toLocaleString().split("-");
    let hoursSplittedStart = item.DateStart.toLocaleString().split("T")[1].split(":");
    let hoursSplittedEnd = item.DateEnd.toLocaleString().split("T")[1].split(":");
    return `Prenotazione in sala ${item.RoomId} prenotata dall'utente ${resourceName} il ${splittedStart[0]}/${splittedStart[1]}/${splittedStart[2].split("T")[0]} dalle ${hoursSplittedStart[0]}:${hoursSplittedStart[1]} fino al ${splittedEnd[0]}/${splittedEnd[1]}/${splittedEnd[2].split("T")[0]} alle ${hoursSplittedEnd[0]}:${hoursSplittedEnd[1]}, con prenotazione `;
}

function bookingDetails(id: number): void {
    $.getJSON(webApiBaseUrl + "Booking/" + id)
        .done(((booking: Booking) => {
            $.getJSON(webApiBaseUrl + "Resource/" + booking.ResourceId)
                .done(((resource: User) => {
                    alert(formatBookingDetail(booking, resource.Username));
                }) as any)
                .fail((jqXHR, textStatus, err) => {
                    console.error(`jqXHR: ${jqXHR}`);
                    console.error(`textStatus: ${textStatus}`);
                    console.error(`err: ${err}`);
                    console.error("Error While Uploading resource details.");
                });
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading booking details.");
        });
}

function getAllBookings(): void {
    $("#list-of-bookings").empty();

    $.getJSON(webApiBaseUrl + "Booking")
        .done(((bookings: Booking[]) => {
            allBookings = bookings;
            $.each(bookings,
                (_key, booking: Booking) => {
                    $("#list-of-bookings").append(`<li class="list-group-item">${formatBooking(booking)}<a style="margin-left:5px;" href="#" onclick="bookingDetails(${booking.BookingId})">(View)</a><a style="margin-left:5px;" href="#" onclick="deleteBooking(${booking.BookingId})">(Delete)</a></li>`);
                });
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading bookings.");
        });
}

function deleteBooking(id: number): void {
    $.ajax({
        type: "DELETE",
        url: webApiBaseUrl + "Booking/del/" + id,
        contentType: "application/json",
    }).done(() => {
        this.getAllBookings();
    }).fail((jqXHR, textStatus, err) => {
        console.error(`jqXHR: ${jqXHR}`);
        console.error(`textStatus: ${textStatus}`);
        console.error(`err: ${err}`);
        console.error("Error While creating bookings.");
    });
}

function createBooking(): void {
    if ($("#description").val() === "" || $("#datepickerStart").val() === "" || $("#datepickerEnd").val() === "" || $("#resourceSelect").children("option:selected").val() === "" || $("#roomSelect").children("option:selected").val()) {
        alert("You need to valorize every field");
        return;
    }

    let body = JSON.stringify({
        "Description": $("#description").val(),
        "DateStart": $("#datepickerStart").val(),
        "DateEnd": $("#datepickerEnd").val(),
        "ResourceId": $("#resourceSelect").children("option:selected").val(),
        "RoomId": $("#roomSelect").children("option:selected").val()
    });

    let filtered: Booking[];

    $.getJSON(webApiBaseUrl + "Booking/range/?start=" + $("#datepickerStart").val() + "&&end=" + $("#datepickerEnd").val() + "&&roomId=" + $("#roomSelect").children("option:selected").val())
        .done(((bookings: Booking[]) => {
            filtered = bookings;

            if (filtered.length > 0) {
                alert("esiste già una prenotazione a quest'orario");
                return;
            }

            $.ajax({
                type: "POST",
                url: webApiBaseUrl + "Booking/add",
                contentType: "application/json",
                data: body
            }).done((data) => {
                this.getAllBookings();
            }).fail((jqXHR, textStatus, err) => {
                console.error(`jqXHR: ${jqXHR}`);
                console.error(`textStatus: ${textStatus}`);
                console.error(`err: ${err}`);
                console.error("Error While creating bookings.");
            });
        }) as any)
        .fail((jqXHR, textStatus, err) => {
            console.error(`jqXHR: ${jqXHR}`);
            console.error(`textStatus: ${textStatus}`);
            console.error(`err: ${err}`);
            console.error("Error While Uploading bookings.");
        });

    

    
}