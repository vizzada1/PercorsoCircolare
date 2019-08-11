using System.Collections.Generic;
using System.Linq;
using PercorsoCircolare.Entities;
using PercorsoCircolare.WebApi.Models;

namespace PercorsoCircolare.WebApi.Mappers
{
    public class ResourceMapper
    {
        public static IEnumerable<ResourceVM> MapListOfResource(IEnumerable<Resource> entities)
        {
            var res = entities.Select(entity => new ResourceVM()
            {
                ResourceId = entity.ResourceId,
                Username = entity.Username,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                IsActive = entity.IsActive,
                EmailAddress = entity.EmailAddress
            });

            return res;
        }

        public static ResourceVM MapResource(Resource entity)
        {
            var res = new ResourceVM
            {
                ResourceId = entity.ResourceId,
                Username = entity.Username,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };

            return res;
        }

        public static Resource MapResourceVM(ResourceVM vm)
        {
            var res = new Resource
            {
                ResourceId = vm.ResourceId,
                Username = vm.Username,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                IsActive = vm.IsActive,
                EmailAddress = vm.EmailAddress
            };

            return res;
        }
    }
}