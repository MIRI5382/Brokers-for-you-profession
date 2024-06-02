using Bl.Bo;
using Bo;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YrapholojistControler: ControllerBase
    {
        private BlManager _bl;
        public YrapholojistControler(BlManager bl)
        {
            this._bl = bl;
        }
        [Route("GetAll")]
        [HttpGet]
        public List<BYrapholojist>? GetAll() =>
            _bl.blYrapholojist.GetAll();

        [Route("Post")]
        [HttpPost]
        public int Post(BYrapholojist t) =>
            _bl.blYrapholojist.Post(t);
        [Route("Put")]
        [HttpPut]
        public bool Put(BYrapholojist t) =>
            _bl.blYrapholojist.Put(t);
    }
}
