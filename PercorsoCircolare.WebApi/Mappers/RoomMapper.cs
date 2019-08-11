﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PercorsoCircolare.Entities;
using PercorsoCircolare.WebApi.Models;

namespace PercorsoCircolare.WebApi.Mappers
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
                Building = BuildingMapper.MapBuilding(entity.Building)
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
                Building = BuildingMapper.MapBuilding(entity.Building)
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
                Building = BuildingMapper.MapBuildingVM(vm.Building)
            };

            return res;
        }
    }
}