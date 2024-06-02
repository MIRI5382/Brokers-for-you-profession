using Bo;
using Dal.Do;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GivensubjectControler
    {
        private BlManager _bl;
        public GivensubjectControler(BlManager bl)
        {
            this._bl = bl;
        }
        [Route("Post")]
        [HttpPost]
        public int Post(BlGivenCourse g) =>
            _bl.blgivensubject.Post(g);

        [Route("Put")]
        [HttpPut]
        public bool Put(BlGivenCourse g) =>
            _bl.blgivensubject.Put(g);


    }
}
