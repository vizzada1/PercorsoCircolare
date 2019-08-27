using PercorsoCircolare.BL;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Mappers;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PercorsoCircolare.PercorsoCircolare.SL.Api.Controllers
{
    [EnableCors("http://localhost:60559", "*", "*")]
    public class ResourceController : ApiController
    {
        [HttpGet]
        [Route("api/Resource")]
        public IEnumerable<ResourceVM> GetAllResources()
        {
            var mng = new ResourceManager();
            var resources = ResourceMapper.MapListOfResource(mng.GetAllResources());

            return resources;
        }

        [HttpGet]
        [Route("api/Resource/{id:int}")]
        public IHttpActionResult GetResource([FromUri]int id)
        {
            var mng = new ResourceManager();
            var resource = ResourceMapper.MapResource(mng.GetResourceById(id));

            if (resource == null)
                return NotFound();
            return Ok(resource);
        }

        [HttpPost]
        [Route("api/Resource/add")]
        public IHttpActionResult CreateResource([FromBody]ResourceVM res)
        {
            var mng = new ResourceManager();
            mng.AddNewResource(ResourceMapper.MapResourceVM(res));

            return Ok(res);
        }
    }
}
