using Bl.Bo;
using Bo;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscribedControl : ControllerBase
    {
        private BlManager _bl;
        public InscribedControl(BlManager bl)
        {
            this._bl = bl;
        }
        [Route("Post")]
        [HttpPost]
        public int Post(BInscribed i) =>
            _bl.blinscribed.Post(i);
        [Route("Put")]
        [HttpPut]
        public bool Put(BInscribed i) =>
                _bl.blinscribed.Put(i);

        [Route("delete")]
        [HttpDelete]
        public bool Delete(List<BInscribed> b) =>
            _bl.blinscribed.Delete(b);

    }
}
