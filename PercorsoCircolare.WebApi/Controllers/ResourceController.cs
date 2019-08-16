using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using PercorsoCircolare.BL;
using PercorsoCircolare.WebApi.Mappers;
using PercorsoCircolare.WebApi.Models;

namespace PercorsoCircolare.WebApi.Controllers
{
    [EnableCors("http://localhost:44304", "*", "*")]
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
