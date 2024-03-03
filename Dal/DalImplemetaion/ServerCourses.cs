
using Dal.DalApi;
using Dal.Do;
using Microsoft.EntityFrameworkCore;

namespace Dal.DalImplemetaion
{
    public class ServerCourses : ICourses
    {
        private dbcontext db;
        private int count=0;

        public ServerCourses(dbcontext db) { this.db = db; }
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
            db.Courses.ToList<Course>().ForEach(x => count++);
            return count;
        }
    }
}