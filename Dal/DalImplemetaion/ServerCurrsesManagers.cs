
using Dal.DalApi;
using Dal.Do;
using System.Collections.ObjectModel;

namespace Dal.DalImplemetaion
{
    public class ServerCurrsesManagers : IdGivenCourses
    {
        private dbcontext db;
        private int count = 0;
        public ServerCurrsesManagers(dbcontext db)
        {
            this.db = db;
        }
        public bool Delete(ICollection<GivenCourse> g)
        {
            foreach (GivenCourse g2 in g)
            {
                db.GivenCourses.Remove(g2);
            }
            db.SaveChanges();         
            return true;
        }

        public List<GivenCourse>? GetAll() =>
            db.GivenCourses.ToList<GivenCourse>();

        public GivenCourse? GetById(string t) =>
            db.GivenCourses.ToList<GivenCourse>().Find(x => x.TzGivenCourses == t);

        public bool Put(GivenCourse t)
        {
            GivenCourse? my = db.GivenCourses.ToList<GivenCourse>().Find(x => x.TzGivenCourses == t.TzGivenCourses);
            if (my != null || t != null)
            {
                if (t.NameOfGivenCourses != null)
                    my.NameOfGivenCourses = t.NameOfGivenCourses;
                if (t.PhoneOfGivenCourses != null)
                    my.PhoneOfGivenCourses = t.PhoneOfGivenCourses;
                if (t.CodeSubject != null)
                    my.CodeSubject = t.CodeSubject;
                db.SaveChanges();
                return true;
            }
            else return false;
        }

        public int Post(GivenCourse g)
        {
            db.GivenCourses.Add(g);
            //MySubject? mysub = db.MySubjects.FirstOrDefault(x => x.CodeSubject == g.CodeSubject);
            //mysub?.GivenCourses.Add(g);
            db.SaveChanges();
            return 1;
        }
    }
}
