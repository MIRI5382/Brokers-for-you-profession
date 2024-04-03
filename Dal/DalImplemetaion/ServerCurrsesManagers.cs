
using Dal.DalApi;
using Dal.Do;

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
                try
                {
                    db.GivenCourses.Remove(g2);
                }
                catch (Exception ex) { return false; }
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex) { return false; }
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
                try
                {
                    my.NameOfGivenCourses = t.NameOfGivenCourses;
                    my.PhoneOfGivenCourses = t.PhoneOfGivenCourses;
                    my.CodeSubject = t.CodeSubject;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
            else return false;
        }

        public int Post(GivenCourse g)
        {
            var n = g;
            try { 
            db.GivenCourses.Add(n);
            db.SaveChanges();}catch (Exception ex) {return 0;}
            return 1;
        }
    }
}
