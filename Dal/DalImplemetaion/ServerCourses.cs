
using Dal.DalApi;
using Dal.Do;
using Microsoft.EntityFrameworkCore;

namespace Dal.DalImplemetaion
{
    public class ServerCourses : IdCourses
    {
        private dbcontext db;
        private int count = 0;

        private IdTime _time;
        private bool r;

        public ServerCourses(dbcontext db, IdTime time)
        {
            this.db = db;

            this._time = time;
        }
        public bool Delete(ICollection<Course> t)
        {
            foreach (Course c in t)
            {
                db.Courses.Remove(c);
                if (c.Times.Count > 0)
                {
                    r = _time.Delete(c.Times);
                    if (!r) { return r; }
                }
            }
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
            var x = db.Courses.Add(t);
            if (x == null) return 0;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex) { return 0; }
            return x.Entity.CodeCourse;
        }
        public List<Course>? GetAll() =>
            db.Courses.Include(x => x.Times).ToList<Course>();


    }
}
