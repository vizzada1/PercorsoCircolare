using System.Collections.Generic;
using PercorsoCircolare.DAL.Entities;

namespace PercorsoCircolare.DAL.Interfaces
{
    public interface IBookingRepo
    {
        IEnumerable<Booking> GetAll();

        Booking GetById(int id);

        void Add(Booking newBooking);

        void Delete(Booking booking);
    }
}