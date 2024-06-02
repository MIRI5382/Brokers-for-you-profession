using Bl.BlApi;
using Bl.Bo;
using Bo;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrashtenController : ControllerBase
    {
        private BlManager _bl;

        public QrashtenController(BlManager ib) { _bl = ib; }
        [Route("Post")]
        [HttpPost]
        public int Post(BQreshten t) =>
              _bl.blqrashten.Post(t);

        [Route("Put")]
        [HttpPut]
        public bool Put(BQreshten t) =>
            _bl.blqrashten.Put(t);

    }
}
