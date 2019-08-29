using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;
using System.Web.Http.Cors;
using PercorsoCircolare.BL;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Mappers;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Models;

namespace PercorsoCircolare.PercorsoCircolare.SL.Api.Controllers
{
    [EnableCors("http://localhost:60559", "*", "*")]
    public class RoomController : ApiController
    {
        [HttpGet]
        [Route("api/Room")]
        public IEnumerable<RoomVM> GetAllRooms()
        {
            var mng = new RoomManager();
            var rooms = RoomMapper.MapListOfRooms(mng.GetAllRooms());

            return rooms;
        }

        [HttpGet]
        [Route("api/Room/{id:int}")]
        public IHttpActionResult GetRoom(int id)
        {
            var mng = new RoomManager();
            var room = RoomMapper.MapRoom(mng.GetRoomById(id));

            if (room == null)
                return NotFound();
            return Ok(room);
        }

        [HttpPost]
        [Route("api/Room/add")]
        public IHttpActionResult CreateRoom(RoomVM res)
        {
            var mng = new RoomManager();
            var mngBuilding = new BuildingManager();

            var room = RoomMapper.MapRoomVM(res);
            room.Building = mngBuilding.GetBuildingById(res.Building);
            mng.AddNewRoom(room);

            return Ok(res);
        }
    }
}
