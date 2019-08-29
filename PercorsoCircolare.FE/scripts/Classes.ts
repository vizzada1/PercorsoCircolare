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
    BuildingId: number;
}

class Booking {
    BookingId: number;
    ResourceId: number;
    Description: string;
    DateStart: Date;
    DateEnd: Date;
    RoomId: number;
}