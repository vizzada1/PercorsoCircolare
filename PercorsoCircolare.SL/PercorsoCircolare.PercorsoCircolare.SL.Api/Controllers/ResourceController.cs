﻿using System.Collections.Generic;
using System.Web.Http;
using PercorsoCircolare.BL;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Mappers;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Models;

namespace PercorsoCircolare.PercorsoCircolare.SL.Api.Controllers
{
    public class ResourceController : ApiController
    {
        [HttpGet]
        public IEnumerable<ResourceVM> GetAllResources()
        {
            var mng = new ResourceManager();
            var resources = ResourceMapper.MapListOfResource(mng.GetAllResources());

            return resources;
        }

        [HttpGet]
        public IHttpActionResult GetResource(int id)
        {
            var mng = new ResourceManager();
            var resource = ResourceMapper.MapResource(mng.GetResourceById(id));

            if (resource == null)
                return NotFound();
            return Ok(resource);
        }

        [HttpPost]
        public IHttpActionResult CreateResource(ResourceVM res)
        {
            var mng = new ResourceManager();
            mng.AddNewResource(ResourceMapper.MapResourceVM(res));

            return Ok(res);
        }
    }
}