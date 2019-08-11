using System;
using System.Collections.Generic;
using PercorsoCircolare.Common;
using PercorsoCircolare.DAL;
using PercorsoCircolare.Entities;

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
        public void AddNewBooking(Booking newBooking)
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

        /// <summary>
        /// Removes a booking from the registry
        /// </summary>
        /// <param name="id">id used to identify the booking to delete</param>
        public void RemoveBooking(int id)
        {
            try
            {
                var booking = GetBookingById(id);
                repo.Delete(booking);
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
