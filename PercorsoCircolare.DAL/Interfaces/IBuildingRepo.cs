using System.Collections.Generic;
using PercorsoCircolare.DAL.Entities;

namespace PercorsoCircolare.DAL.Interfaces
{
    public interface IBuildingRepo
    {
        IEnumerable<Building> GetAll();

        Building GetById(int id);

        void Add(Building newBuilding);
    }
}