using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using PercorsoCircolare.BL;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Mappers;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Models;

namespace PercorsoCircolare.PercorsoCircolare.SL.Api.Controllers
{
    [EnableCors("http://localhost:60559", "*", "*")]
    public class BookingController : ApiController
    {
        [HttpGet]
        [Route("api/Booking")]
        public IEnumerable<BookingVM> GetAllBookings()
        {
            var mng = new BookingManager();
            var bookings = BookingMapper.MapListOfBookings(mng.GetAllBookings());

            return bookings;
        }

        [HttpGet]
        [Route("api/Booking/{id:int}")]
        public IHttpActionResult GetBooking(int id)
        {
            var mng = new BookingManager();
            var booking = BookingMapper.MapBooking(mng.GetBookingById(id));

            if (booking == null)
                return NotFound();
            return Ok(booking);
        }

        [HttpPost]
        [Route("api/Booking/add")]
        public IHttpActionResult CreateBooking(BookingVM res)
        {
            var mng = new BookingManager();
            mng.AddNewBooking(BookingMapper.MapBookingVM(res));

            return Ok(res);
        }

        [HttpDelete]
        [Route("api/Booking/del/{id:int}")]
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

        [HttpGet]
        [Route("api/Booking/range")]
        public IEnumerable<BookingVM> GetBookingFromDateRange(DateTime start, DateTime end, int roomId)
        {
            var mng = new BookingManager();
            var bookings = BookingMapper.MapListOfBookings(mng.GetBookingInRange(start, end));

            return bookings.Where(b => b.RoomId == roomId);
        }
    }
}