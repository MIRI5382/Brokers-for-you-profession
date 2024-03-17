using Bl.BlApi;
using Bl.Bo;
using Dal.Do;
using Dal;
using Dal.DalApi;

namespace Bl.BlImplemetiaon
{
    public class BServGivenCours: IGivensubject
    {
        private DalManager _dmenager;
        private IGivenCourses _dGivenCourses;
        public BServGivenCours(DalManager d, IGivenCourses i) 
        { 
            _dmenager = d;
            _dGivenCourses = i;
        }
        public BlGivenCourse ConvertToBl(GivenCourse givenCourse)
        {
            if (givenCourse == null) return null;
             BlGivenCourse bgiven = new BlGivenCourse();
            bgiven.CodeSubject = givenCourse.CodeSubject;
            bgiven.PhoneOfGivenCourses= givenCourse.PhoneOfGivenCourses;
            bgiven.NameOfGivenCourses=givenCourse.NameOfGivenCourses;
            bgiven.TzGivenCourses = givenCourse.TzGivenCourses;
            return bgiven;
        }
        public GivenCourse ConvertToDal(BlGivenCourse givenCourse)
        {
            GivenCourse bgiven = new GivenCourse();
            bgiven.CodeSubject = givenCourse.CodeSubject;
            bgiven.PhoneOfGivenCourses = givenCourse.PhoneOfGivenCourses;
            bgiven.NameOfGivenCourses = givenCourse.NameOfGivenCourses;
            bgiven.TzGivenCourses = givenCourse.TzGivenCourses;
            return bgiven;
        }
        public List<BlGivenCourse> ListToBl(List<GivenCourse> list)
        {
            List<BlGivenCourse> lst = new List<BlGivenCourse>();
            list.ForEach(x => lst.Add(ConvertToBl(x)));
            return lst;
        }

        public List<BlGivenCourse>? GetAll()=>
             ListToBl(_dGivenCourses.GetAll());
        
        public int Post(BlGivenCourse t)=>              
            _dGivenCourses.Post(ConvertToDal(t));

        public bool Put(BlGivenCourse item)=>
            _dGivenCourses.Put(ConvertToDal(item)); 
             
        
    }
}
