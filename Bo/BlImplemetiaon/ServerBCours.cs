using Bl.BlApi;
using Bl.Bo;
using Dal;
using Dal.DalApi;
using Dal.Do;

namespace Bl.BlImplemetiaon
{
    public class ServerBCours : IbCours
    {
       // private DalManager _dManager;
        private IdCourses _dcors;
        private IbTime _iTime;

        public ServerBCours(DalManager dM, IbTime iTime)
        {
           
            _dcors = dM.SCourses;
            _iTime = iTime; 
        }
        public BCours ConvertToBl(Course c)
        {
            BCours bc = new BCours();
            bc.CodeSubject = c.CodeSubject;
            bc.CodeCourse = c.CodeCourse;
            bc.DateOfCourseEnd = c.DateOfCourseEnd;
            bc.DateOfCourseStart = c.DateOfCourseStart;
            bc.NameOfCourse = c.NameOfCourse;
            bc.Times = ((SevicTime)_iTime).ConvertTimeListToBl(c.Times.ToList());
            bc.NumQuality = c.NumQuality;
            bc.SortCourse = c.SortCourse;
            return bc;
        }
        public Course ConvertToDal(BCours c)
        {
            Course bc = new Course();
            bc.CodeSubject = c.CodeSubject;
            if (c.CodeCourse != null)
                bc.CodeCourse = (int)(c.CodeCourse);
            else
                bc.CodeCourse = 0;
            bc.DateOfCourseEnd = c.DateOfCourseEnd;
            bc.DateOfCourseStart = c.DateOfCourseStart;
            bc.NameOfCourse = c.NameOfCourse;
            bc.Times = ((SevicTime)_iTime).ConvertTimeListToDal(c.Times.ToList());
            bc.NumQuality = c.NumQuality;
            bc.SortCourse = c.SortCourse;
            return bc;
        }
        public List<Course> ListToDal(List<BCours> list)
        {
            List<Course> lst = new List<Course>();
            list.ForEach(x => lst.Add(ConvertToDal(x)));
            return lst;
        }

        private object mapAll;
        public List<BCours> ListToBl(List<Course> list)
        {
            List<BCours> lst = new List<BCours>();
            list.ForEach(x => lst.Add(ConvertToBl(x)));
            return lst;
        }

        public int Post(BCours courses) =>
             _dcors.Post(ConvertToDal(courses));

        public List<BCours>? GetAll() =>
            ListToBl(_dcors.GetAll());

        public bool Put(BCours item)=>
            _dcors.Put(ConvertToDal(item));

        public bool DeleteOne(BCours c) =>
            _dcors.DeleteOne(ConvertToDal(c));
        public bool Delete(List<BCours> t)=>
           _dcors.Delete(ListToDal(t));
    }
}
