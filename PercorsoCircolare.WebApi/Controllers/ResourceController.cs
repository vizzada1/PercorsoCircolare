using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using PercorsoCircolare.BL;
using PercorsoCircolare.WebApi.Mappers;
using PercorsoCircolare.WebApi.Models;

namespace PercorsoCircolare.WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:8088", headers: "*", methods: "*")]
    public class ResourceController : ApiController
    {
        [HttpGet]
        public IEnumerable<ResourceVM> GetAllResources()
        {
            var mng = new ResourceManager();
            var resources = ResourceMapper.MapListOfResource(mng.GetAllResources());

            return resources;
        }
    }
}
