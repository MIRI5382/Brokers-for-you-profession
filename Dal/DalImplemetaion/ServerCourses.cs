
using Dal.DalApi;
using Dal.Do;
using Microsoft.EntityFrameworkCore;

namespace Dal.DalImplemetaion
{
    public class ServerCourses : ICourses
    {
        private dbcontext db;
        private int count=0;
        private ServerSubject _subjectSetv ;

        public ServerCourses(dbcontext db, ServerSubject subject) 
        { 
            this.db = db;
            this._subjectSetv = subject;
        }
        public bool Delete(Course t)
        {
            db.Courses.Remove(t);
            return true;
        }

        public List<Course>? GetAll()=>
            db.Courses.Include(x=> x.CodeSubjectNavigation).ToList<Course>();
    

        public Course? GetById(int CodeCourse)=>
             db.Courses.ToList<Course>().Find(x => x.CodeCourse == CodeCourse);
       

        public bool Put(Course t)
        {
            Course? my = db.Courses.ToList<Course>().Find(x => x.CodeCourse == t.CodeCourse);
            if (my != null)
            {
                my = t;
                return true;
            }
            else return false;
        }

        public int Post(Course t)
        {
            db.Courses.Add(t);
            Course? c = db.Courses.ToList<Course>().FirstOrDefault(x => x==t);
            MySubject? sub= _subjectSetv?.GetAll()?.FirstOrDefault(x=>x.CodeSubject==t.CodeSubject);
            sub?.Courses.Add(t);
            return c.CodeCourse;
        }
    }
}