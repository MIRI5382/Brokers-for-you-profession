using Bl.BlApi;
using Bl.Bo;
using Bo;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class AnssworController : ControllerBase
    {
        private BlManager _bl;

        public AnssworController(BlManager bl) { _bl = bl; }
        [Route("Post")]
        [HttpPost]
        public int Post(BAnswor t) =>
             _bl.blanswor.Post(t);

        [Route("Put")]
        [HttpPut]
        public bool Put(BAnswor t) =>
            _bl.blanswor.Put(t);

    }
}
