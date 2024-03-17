
using Dal.DalApi;
using Dal.Do;
using Microsoft.EntityFrameworkCore;

namespace Dal.DalImplemetaion
{
    public class ServerCourses : ICourses
    {
        private dbcontext db;
        private int count = 0;
        private ServerSubject _subjectSetv;
        private ServerTime _time;

        public ServerCourses(dbcontext db, ServerSubject subject)
        {
            this.db = db;
            this._subjectSetv = subject;
        }
        public bool Delete(Course t)
        {
            db.Courses.Remove(t);
            db.SaveChanges();
            return true;
        }

        public Course? GetById(int CodeCourse) =>
             db.Courses.ToList<Course>().Find(x => x.CodeCourse == CodeCourse);


        public bool Put(Course t)
        {
            Course? my = db.Courses.ToList<Course>().Find(x => x.CodeCourse == t.CodeCourse);
            if (my != null || t != null)
            {
                if (t.NameOfCourse != null)
                    my.NameOfCourse = t.NameOfCourse;
                if (t.DateOfCourseStart != null)
                    my.DateOfCourseStart = t.DateOfCourseStart;
                if (t.DateOfCourseEnd != null)
                    my.DateOfCourseEnd = t.DateOfCourseEnd;
                if (t.NumQuality != null)
                    my.NumQuality = t.NumQuality;
                if (t.SortCourse != null)
                    my.SortCourse = t.SortCourse;
                if (t.Times != null)
                    _time.Put((Time)t.Times);
                db.SaveChanges();
                return true;
            }
            else return false;
        }

        public int Post(Course t)
        {
            db.Courses.Add(t);
            Course? c = db.Courses.ToList<Course>().FirstOrDefault(x => x == t);
            MySubject? sub = _subjectSetv?.GetAll()?.FirstOrDefault(x => x.CodeSubject == t.CodeSubject);
            sub?.Courses.Add(t);
            db.SaveChanges();
            return c.CodeCourse;
        }
        public List<Course>? GetAll() =>
            db.Courses.Include(x => x.Times).ToList<Course>();

       
    }
}
