class User {
    ResourceId: number;
    Username: string;
    FirstName: string;
    LastName: string;
    EmailAddress: string;
    IsActive: boolean;
}

class Building {
    BuildingId: number;
    Name: string;
    Address: string;
    IsActive: boolean;
}

class Room {
    RoomId: number;
    Name: string;
    AvailableSeats: number;
    IsActive: boolean;
    Building: Building;
}

class Booking {
    BookingId: number;
    Resource: User;
    Description: string;
    DateStart: Date;
    DateEnd: Date;
}