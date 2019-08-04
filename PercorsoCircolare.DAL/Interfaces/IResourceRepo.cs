using System.Collections.Generic;
using PercorsoCircolare.DAL.Entities;

namespace PercorsoCircolare.DAL.Interfaces
{
    public interface IResourceRepo
    {
        IEnumerable<Resource> GetAll();

        Resource GetByUser(string username);

        Resource GetById(int id);

        void Add(Resource newResource);
    }
}