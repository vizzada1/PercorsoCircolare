using PercorsoCircolare.DAL.Entities;

namespace PercorsoCircolare.DAL
{
    public class RoomRepo : RepoBase<Room>
    {
        public Room GetById(int id)
        {
            return ((DALManager) Context).RoomCollection.Find(id);
        }
    }
}