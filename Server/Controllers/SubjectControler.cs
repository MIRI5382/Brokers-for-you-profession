using Dal.Do;
using Bo;
using Microsoft.AspNetCore.Mvc;
using Bl.BlApi;
using Bl.BlImplemetiaon;
using Bl.Bo;

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
        public List<BSubject> GetAllSubject() =>      
            bl.blsubjects.GetAll();

        [Route("GetBySivog")]
        [HttpPost]
        public List<BSubject> GetSubjectBySivog(SivogSubject s) => 
            bl.blsubjects.GetBySivog(s);

        [Route("GetSubjectByName")]
        [HttpGet]
        public List<BSubject>? GetByName(string name) =>
            bl.blsubjects.GetByName(name);

        [Route("GetSubjectById")]
        [HttpGet]
        public List<BSubject>? GetById(int code) =>
            bl.blsubjects.GetById(code);

        [Route("PostSubject")]
        [HttpPost]
        public int Post(BSubject s) => 
            bl.blsubjects.Post(s);


        [Route("SubjectClos")]
        [HttpGet]
        public List<BSubject>? SubjectClos() =>
            bl.blsubjects.GetSubjectClos();

        [Route("Put")]
        [HttpPut]
        public bool SubjectPut(BSubject subject) =>
            bl.blsubjects.Put(subject);
        [Route("GetNewSubject")]
        [HttpGet]
        public List<BSubject>? GetNewSubject() =>
            bl.blsubjects.GetNewSubject();
    }
}
