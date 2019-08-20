class User {
    resourceId: number;
    username: string;
    firstName: string;
    lastName: string;
    emailAddress: string;
    isActive: boolean;

    public static mapToUsers(data): Array<User> {
        let users: Array<User> = [];
        $.each(data,
            (item: any) => {
                let user = new User();
                user.resourceId = item.ResourceId;
                user.firstName = item.FirstName;
                user.lastName = item.LastName;
                user.username = item.Username;
                user.emailAddress = item.EmailAddress;
                user.isActive = item.IsActive;

                users.push(user);
            });
        return users;
    }
}

class Building {
    buildingId: number;
    name: string;
    address: string;
    isActive: boolean;
}

class Room {
    roomId: number;
    name: string;
    availableSeats: number;
    isActive: boolean;
    building: Building;
}

class Booking {
    bookingId: number;
    resource: User;
    description: string;
    dateStart: Date;
    dateEnd: Date;
}