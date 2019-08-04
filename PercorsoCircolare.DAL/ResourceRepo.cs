using System;
using System.Linq;
using System.Text;
using PercorsoCircolare.DAL.Entities;
using PercorsoCircolare.DAL.Interfaces;

namespace PercorsoCircolare.DAL
{
    public class ResourceRepo : RepoBase<Resource>, IResourceRepo
    {
        public override void Add(Resource newResource)
        {
            if (newResource == null)
                throw new ArgumentNullException();
            if (newResource.Username != null) return;
            //Calcolo username
            var user = newResource.LastName.Length >= 5
                ? new StringBuilder(newResource.LastName.Substring(0, 5)
                                    + newResource.FirstName.Substring(0, 2))
                : new StringBuilder(newResource.LastName.Substring(0, newResource.LastName.Length)
                                    + newResource.FirstName.Substring(0, 2));
            newResource.Username = user.ToString();
            //Aggiungo la risorsa con il progressivo giusto
            for (var i = 1;; i++)
            {
                var resource = ((DALManager) Context).Resources.GetByUser(user + i.ToString());
                if (resource != null) continue;
                user.Append(i.ToString());
                newResource.Username = user.ToString();
                ((DALManager) Context).ResourceCollection.Add(newResource);
                ((DALManager) Context).SaveChanges();
                return;
            }
        }

        public Resource GetById(int id)
        {
            return ((DALManager) Context).ResourceCollection.Find(id);
        }

        public Resource GetByUser(string username)
        {
            return ((DALManager) Context).ResourceCollection.FirstOrDefault(t => t.Username == username);
        }
    }
}