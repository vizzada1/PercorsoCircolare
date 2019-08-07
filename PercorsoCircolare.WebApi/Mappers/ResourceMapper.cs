using System;
using System.Collections.Generic;
using System.Linq;
using PercorsoCircolare.DAL.Entities;
using PercorsoCircolare.WebApi.Models;

namespace PercorsoCircolare.WebApi.Mappers
{
    public class ResourceMapper
    {
        public static IEnumerable<ResourceVM> MapListOfResource(IEnumerable<Resource> entities)
        {
            var res = entities.Select(t => new ResourceVM()
            {
                ResourceId = t.ResourceId,
                Username = t.Username,
                FirstName = t.FirstName,
                LastName = t.LastName,
                IsActive = t.IsActive,
                EmailAddress = t.EmailAddress
            });

            return res;
        }
    }
}