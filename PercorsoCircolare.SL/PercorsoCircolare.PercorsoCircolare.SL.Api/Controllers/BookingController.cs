using System;
using System.Collections.Generic;
using System.Web.Http;
using PercorsoCircolare.BL;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Mappers;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Models;

namespace PercorsoCircolare.PercorsoCircolare.SL.Api.Controllers
{
    public class BookingController : ApiController
    {
        [HttpGet]
        public IEnumerable<BookingVM> GetAllBookings()
        {
            var mng = new BookingManager();
            var bookings = BookingMapper.MapListOfBookings(mng.GetAllBookings());

            return bookings;
        }

        [HttpGet]
        public IHttpActionResult GetBooking(int id)
        {
            var mng = new BookingManager();
            var booking = BookingMapper.MapBooking(mng.GetBookingById(id));

            if (booking == null)
                return NotFound();
            return Ok(booking);
        }

        [HttpPost]
        public IHttpActionResult CreateBooking(BookingVM res)
        {
            var mng = new BookingManager();
            mng.AddNewBooking(BookingMapper.MapBookingVM(res));

            return Ok(res);
        }

        [HttpDelete]
        public IHttpActionResult RemoveBooking([FromUri] int id)
        {
            try
            {
                var mng = new BookingManager();
                mng.RemoveBooking(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}