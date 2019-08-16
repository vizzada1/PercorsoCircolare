var classes;
(function (classes) {
    var User = /** @class */ (function () {
        function User() {
        }
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
    function createUser() {
        ajaxManager.apiPost("/Resources", {});
    }
})(classes || (classes = {}));
//# sourceMappingURL=Classes.js.map