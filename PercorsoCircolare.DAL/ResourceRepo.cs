using System;
using System.Linq;
using System.Text;
using PercorsoCircolare.DAL.Entities;

namespace PercorsoCircolare.DAL
{
    public class ResourceRepo : RepoBase<Resource>
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
            //Aggiungo la risorsa con il progressivo giusto
            for (var i = 1;; i++)
            {
                var comp = user.Append(i).ToString();
                var resource = ((DALManager) Context).ResourceCollection.FirstOrDefault(r => r.Username == comp);
                if (resource != null) continue;
                newResource.Username = comp;
                ((DALManager) Context).ResourceCollection.Add(newResource);
                return;
            }
        }
    }
}