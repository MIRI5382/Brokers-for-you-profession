using Bl.Bo;
using Bo;
using Dal.Do;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers

{
    [Route("api/[controller]")]
    [ApiController]

    public class CoursControler : ControllerBase
    {
        private BlManager _bl;
        public CoursControler(BlManager bl)
        {
            this._bl = bl;
        }
        [Route("PostCours")]
        [HttpPost]
        public int Post(BCours t) =>
            _bl.blcours.Post(t);

        [Route("PutCours")]
        [HttpPut]
        public bool Put(BCours item) =>
           _bl.blcours.Put(item);
        [Route("DeleteOne")]
        [HttpDelete]
        public bool DeleteOne(BCours item) =>
           _bl.blcours.DeleteOne(item);

        [Route("DeleteAll")]
        [HttpDelete]
        public bool Delete(List<BCours> item) =>
           _bl.blcours.Delete(item);




    }
}
