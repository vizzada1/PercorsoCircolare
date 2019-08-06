using System;
using System.Collections.Generic;
using PercorsoCircolare.Common;
using PercorsoCircolare.DAL;
using PercorsoCircolare.DAL.Entities;

namespace PercorsoCircolare.BL
{
    public class BookingManager
    {
        private readonly BookingRepo repo = new BookingRepo();

        /// <summary>
        /// Returns a list of all bookings
        /// </summary>
        /// <returns>A list of all bookings</returns>
        public IEnumerable<Booking> GetAllBookings()
        {
            try
            {
                return repo.GetAll();
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Returns a Booking with a specific id
        /// </summary>
        /// <param name="id">The id of the Booking</param>
        /// <returns>The booking specified</returns>
        public Booking GetBookingById(int id)
        {
            try
            {
                return repo.Single(r => r.BookingId == id);
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Create a given booking on registry
        /// </summary>
        /// <param name="newBooking">The new booking to create</param>
        public void AddNewBuilding(Booking newBooking)
        {
            try
            {
                repo.Add(newBooking);
                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message);
                throw;
            }
        }
    }
}
