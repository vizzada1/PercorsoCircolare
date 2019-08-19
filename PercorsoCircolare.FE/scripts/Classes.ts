class User {
        resourceId: number;
        username: string;
        firstName: string;
        lastName: string;
        emailAddress: string;
        isActive: boolean;
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