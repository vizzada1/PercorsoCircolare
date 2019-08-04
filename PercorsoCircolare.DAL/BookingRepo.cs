using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PercorsoCircolare.DAL.Entities;
using PercorsoCircolare.DAL.Interfaces;

namespace PercorsoCircolare.DAL
{
    public class BookingRepo : RepoBase<Booking>, IBookingRepo
    {
        public Booking GetById(int id)
        {
            return ((DALManager) Context).BookingCollection.Find(id);
        }
    }
}
