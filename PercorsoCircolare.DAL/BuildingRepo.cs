using PercorsoCircolare.DAL.Entities;

namespace PercorsoCircolare.DAL
{
    public class BuildingRepo : RepoBase<Building>
    {
        public Building GetById(int id)
        {
            return ((DALManager) Context).BuildingCollection.Find(id);
        }
    }
}