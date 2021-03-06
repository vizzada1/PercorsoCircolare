﻿using PercorsoCircolare.Entities;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace PercorsoCircolare.PercorsoCircolare.SL.Api.Mappers
{
    public class BookingMapper
    {
        public static IEnumerable<BookingVM> MapListOfBookings(IEnumerable<Booking> entities)
        {
            var res = entities.Select(entity => new BookingVM()
            {
                BookingId = entity.BookingId,
                DateEnd = entity.DateEnd,
                DateStart = entity.DateStart,
                Description = entity.Description,
                ResourceId = entity.ResourceId,
                RoomId = entity.RoomId
            });

            return res;
        }

        public static BookingVM MapBooking(Booking entity)
        {
            var res = new BookingVM()
            {
                BookingId = entity.BookingId,
                DateEnd = entity.DateEnd,
                DateStart = entity.DateStart,
                Description = entity.Description,
                ResourceId = entity.ResourceId,
                RoomId = entity.RoomId
            };

            return res;
        }

        public static Booking MapBookingVM(BookingVM vm)
        {
            var res = new Booking()
            {
                BookingId = vm.BookingId,
                DateEnd = vm.DateEnd,
                DateStart = vm.DateStart,
                Description = vm.Description,
                ResourceId = vm.ResourceId,
                RoomId = vm.RoomId
            };

            return res;
        }
    }
}