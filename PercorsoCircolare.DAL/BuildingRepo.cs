using PercorsoCircolare.DAL.Entities;
using PercorsoCircolare.DAL.Interfaces;

namespace PercorsoCircolare.DAL
{
    public class BuildingRepo : RepoBase<Building>, IBuildingRepo
    {
        public Building GetById(int id)
        {
            return ((DALManager) Context).BuildingCollection.Find(id);
        }
    }
}