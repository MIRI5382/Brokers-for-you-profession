
using Bo;
using Microsoft.AspNetCore.Mvc;
using Bl.Bo;
using Bl.BlApi;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectControler: ControllerBase
    {
        private ISubject bl;
        public SubjectControler(BlManager bl) 
        {
            this.bl = bl.blsubjects;
        }
        [Route("GetAllSubject")]
        [HttpGet]
        public List<BSubject>? GetAllSubject() =>      
            bl.GetAll();

        [Route("GetBySivog")]
        [HttpPost]
        public List<BSubject> GetSubjectBySivog(SivogSubject s) => 
            bl.GetBySivog(s);

        [Route("GetSubjectByName")]
        [HttpGet]
        public List<BSubject>? GetByName(string name) =>
            bl.GetByName(name);

        [Route("PostSubject")]
        [HttpPost]
        public int Post(BSubject s) => 
            bl.Post(s);


        [Route("SubjectClos")]
        [HttpGet]
        public List<BSubject>? SubjectClos() =>
            bl.GetSubjectClos();

        [Route("NewSubject")]
        [HttpGet]
        public List<BSubject>? NewSubject() =>
            bl.GetNewSubject();

        [Route("put")]
        [HttpPut]
        public bool Put(BSubject b) =>
            bl.Put(b);

    }
}
