using System.Collections.Generic;
using PercorsoCircolare.DAL.Entities;

namespace PercorsoCircolare.DAL.Interfaces
{
    public interface IRoomRepo
    {
        IEnumerable<Room> GetAll();
        Room GetById(int id);
        void Add(Room newBuilding);
    }
}