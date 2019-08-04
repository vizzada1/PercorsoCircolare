using PercorsoCircolare.DAL.Entities;
using PercorsoCircolare.DAL.Interfaces;

namespace PercorsoCircolare.DAL
{
    public class RoomRepo : RepoBase<Room>, IRoomRepo
    {
        public Room GetById(int id)
        {
            return ((DALManager) Context).RoomCollection.Find(id);
        }
    }
}