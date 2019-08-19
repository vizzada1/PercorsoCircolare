using System.Collections.Generic;
using System.Linq;
using PercorsoCircolare.Entities;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Models;

namespace PercorsoCircolare.PercorsoCircolare.SL.Api.Mappers
{
    public class BuildingMapper
    {
        public static IEnumerable<BuildingVM> MapListOfBuildings(IEnumerable<Building> entities)
        {
            var res = entities.Select(entity => new BuildingVM()
            {
                BuildingId = entity.BuildingId,
                Address = entity.Address,
                Name = entity.Name,
                IsActive = entity.IsActive
            });

            return res;
        }

        public static BuildingVM MapBuilding(Building entity)
        {
            var res = new BuildingVM()
            {
                BuildingId = entity.BuildingId ,
                Address = entity.Address,
                Name = entity.Name,
                IsActive = entity.IsActive
            };

            return res;
        }

        public static Building MapBuildingVM(BuildingVM vm)
        {
            var res = new Building()
            {
                BuildingId = vm.BuildingId,
                Address = vm.Address,
                Name = vm.Name,
                IsActive = vm.IsActive
            };

            return res;
        }
    }
}