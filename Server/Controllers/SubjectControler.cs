using Dal.Do;
using Bo;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectControler: ControllerBase
    {
        public BlManager bl;
        public SubjectControler(BlManager bl) 
        {
            this.bl = bl;
        }
        [Route("GetAllSubject")]
        [HttpGet]
        public List<MySubject> GetAllSubject() =>      
            bl.blsubjects.GetAll();

        [Route("GetBySivog/{sivog}")]
        [HttpGet]
        public List<MySubject> GetSubjectBySivog(MySubject sivog) => 
            bl.blsubjects.GetBySivog(sivog);

        [Route("GetSubjectByName")]
        [HttpGet]
        public List<MySubject>? GetByName(string name) =>
            bl.blsubjects.GetByName(name);

        [Route("PostSubject")]
        [HttpPost]
        public int Post(MySubject s) => 
            bl.blsubjects.Post(s);
      


    }
}
