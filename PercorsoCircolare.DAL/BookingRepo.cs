using PercorsoCircolare.DAL.Entities;

namespace PercorsoCircolare.DAL
{
    public class BookingRepo : RepoBase<Booking>
    {
        public Booking GetById(int id)
        {
            return ((DALManager) Context).BookingCollection.Find(id);
        }
    }
}
