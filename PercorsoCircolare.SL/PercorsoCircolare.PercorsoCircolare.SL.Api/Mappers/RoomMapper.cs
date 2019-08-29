using System.Collections.Generic;
using System.Linq;
using PercorsoCircolare.Entities;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Models;

namespace PercorsoCircolare.PercorsoCircolare.SL.Api.Mappers
{
    public class RoomMapper
    {
        public static IEnumerable<RoomVM> MapListOfRooms(IEnumerable<Room> entities)
        {
            var res = entities.Select(entity => new RoomVM()
            {
                RoomId = entity.RoomId,
                AvailableSeats = entity.AvailableSeats,
                Name = entity.Name,
                IsActive = entity.IsActive,
                BuildingId = entity.BuildingId
            });

            return res;
        }

        public static RoomVM MapRoom(Room entity)
        {
            var res = new RoomVM()
            {
                RoomId = entity.RoomId,
                AvailableSeats = entity.AvailableSeats,
                Name = entity.Name,
                IsActive = entity.IsActive,
                BuildingId = entity.BuildingId
            };

            return res;
        }

        public static Room MapRoomVM(RoomVM vm)
        {
            var res = new Room()
            {
                RoomId = vm.RoomId,
                AvailableSeats = vm.AvailableSeats,
                Name = vm.Name,
                IsActive = vm.IsActive,
                BuildingId = vm.BuildingId
            };

            return res;
        }
    }
}