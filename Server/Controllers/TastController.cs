using Bl.Bo;
using Bo;
using Dal;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TastController: ControllerBase
    {
        private BlManager _blManager;
        public TastController(BlManager blManager) { _blManager = blManager; }
        [Route("GetAll")]
        [HttpGet]
        public List<BTast> GetAll() =>
            _blManager.bltast.GetAll();

        [Route("Post")]
        [HttpPost]
        public int Post(BTast t) =>
              _blManager.bltast.Post(t);

        [Route("Put")]
        [HttpPut]
        public bool Put(BTast t) =>
            _blManager.bltast.Put(t);


    }
}
