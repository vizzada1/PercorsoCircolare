﻿using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using PercorsoCircolare.BL;
using PercorsoCircolare.WebApi.Mappers;
using PercorsoCircolare.WebApi.Models;

namespace PercorsoCircolare.WebApi.Controllers
{
    [EnableCors("http://localhost:44304", "*", "*")]
    public class BuildingController : ApiController
    {
        [HttpGet]
        public IEnumerable<BuildingVM> GetAllBuildings()
        {
            var mng = new BuildingManager();
            var buildings = BuildingMapper.MapListOfBuildings(mng.GetAllBuildings());

            return buildings;
        }

        [HttpGet]
        public IHttpActionResult GetBuilding(int id)
        {
            var mng = new BuildingManager();
            var building = BuildingMapper.MapBuilding(mng.GetBuildingById(id));

            if (building == null)
                return NotFound();
            return Ok(building);
        }

        [HttpPost]
        public IHttpActionResult CreateBuilding(BuildingVM res)
        {
            var mng = new BuildingManager();
            mng.AddNewBuilding(BuildingMapper.MapBuildingVM(res));

            return Ok(res);
        }
    }
}