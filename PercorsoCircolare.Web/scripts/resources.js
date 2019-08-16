function formatUser(item) {
    return item.lastName + " " + item.FirstName + " - " + item.Username;
}
function getAll() {
    $("#list-of-users").empty();
    ajaxManager.apiGet("Resource", null, function (users) {
        $.each(users, function (_key, item) {
            $("#list-of-users").append("<li class=\"list-group-item\">" + formatUser(item) + "<a style=\"margin-left:5px;\" href=\"#\" onclick=\"viewUserDetails(" + item.ResourceId + ")\">(View)</a><a style=\"margin-left:5px;\" href=\"#\" onclick=\"updateUser(" + item.ResourceId + ");\">(Update)</a><a style=\"margin-left:5px;\" href=\"#\" onclick=\"deleteUser(" + item.ResourceId + ");\">(Delete)</a></li>");
        });
    });
}
//# sourceMappingURL=resources.js.map