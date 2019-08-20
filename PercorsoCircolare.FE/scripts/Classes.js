var User = /** @class */ (function () {
    function User() {
    }
    User.mapToUsers = function (data) {
        var users = [];
        $.each(data, function (item) {
            var user = new User();
            user.resourceId = item.ResourceId;
            user.firstName = item.FirstName;
            user.lastName = item.LastName;
            user.username = item.Username;
            user.emailAddress = item.EmailAddress;
            user.isActive = item.IsActive;
            users.push(user);
        });
        return users;
    };
    return User;
}());
var Building = /** @class */ (function () {
    function Building() {
    }
    return Building;
}());
var Room = /** @class */ (function () {
    function Room() {
    }
    return Room;
}());
var Booking = /** @class */ (function () {
    function Booking() {
    }
    return Booking;
}());
//# sourceMappingURL=Classes.js.map