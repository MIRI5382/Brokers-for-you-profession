using Bo;
using Dal.Do;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeControler : ControllerBase
    {
        private BlManager _bl;
        public TimeControler(BlManager bl)
        {
            this._bl = bl;
        }
        [Route("PostTimes")]
        [HttpPost]
        public int PostTime(BlTime t) =>
            _bl.bltime.Post(t);

        [Route("PutTimes")]
        [HttpPut]
        public bool PutTime(BlTime t) =>
            _bl.bltime.Put(t);
        [Route("DeleteTime")]
        [HttpDelete]
        public bool DeletTime(BlTime t) =>
           _bl.bltime.DeleteOne(t);
        [Route("DeleteAllTimes")]
        [HttpDelete]
        public bool DeleteAllTimes(List<BlTime> t) =>
           _bl.bltime.Delete(t);
    }
}
