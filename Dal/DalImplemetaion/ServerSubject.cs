
using Dal.DalApi;
using Dal.Do;
using Microsoft.EntityFrameworkCore;

namespace Dal.DalImplemetaion
{
    public class ServerSubject : IdSubjects
    {
        private dbcontext db;
        private int count = 0;
        private IdInscribed _Inscribed;
        private IdCourses _courses;
        private IdGivenCourses _givencors;

        public ServerSubject(dbcontext db, IdInscribed Inscribed, IdCourses courses, IdGivenCourses currsesManagers)
        {
            this.db = db;
            _Inscribed = Inscribed;
            _courses = courses;
            _givencors = currsesManagers;
        }
        public bool Delete(MySubject t)
        {
            var n = t;
            if (n.Inscribeds.Count > 0) { return false; }
            db.MySubjects.Remove(n);
            if (n.Courses.Count > 0) { return _courses.Delete(n.Courses); }
            if (n.GivenCourses.Count > 0) { return _givencors.Delete(n.GivenCourses); }
            db.SaveChanges();
            return true;
        }

        public List<MySubject>? GetAll() =>
            db.MySubjects.Include(x => x.Courses).ThenInclude(c => c.Times)
             .Include(x => x.Inscribeds)
             .Include(x => x.GivenCourses)
           .ToList<MySubject>();

        public List<MySubject>? GetByName(string NameSubject) =>
                db.MySubjects.ToList<MySubject>().FindAll(x => x.SubjectName == NameSubject);



        public int Post(MySubject t)
        {
            try
            {
                var n = t;
                var newt = db.MySubjects.Add(n);
                if (newt == null) return 0;
                db.SaveChanges();
                return newt.Entity.CodeSubject;
            }
            catch { return 0; }
        }

        public bool Put(MySubject t)
        {
            MySubject? my = db.MySubjects.ToList<MySubject>().Find(x => x.CodeSubject == t.CodeSubject);
            if (my != null || t != null)
            {
                my.SubjectName = t.SubjectName;
                my.SortStudents = t.SortStudents;
                my.Price = t.Price;
                my.Place = t.Place;
                my.City = t.City;
                my.Tests = t.Tests;
                my.LengthOf = t.LengthOf;
                my.ContactMan = t.ContactMan;
                my.ContactManPhone = t.ContactManPhone;
                my.MaxNumInscribed = t.MaxNumInscribed;
                my.NumInscribed = t.NumInscribed;
                my.Categury = t.Categury;
                my.GivenCourses = t.GivenCourses;
                if (t.Inscribeds != null)
                    _Inscribed.Put(((Inscribed)t.Inscribeds));
                if (t.Courses != null)
                    _courses.Put(((Course)t.Courses));
                if (t.GivenCourses != null)
                    _givencors.Put(((GivenCourse)t.GivenCourses));
                try
                {
                    db.SaveChanges();
                }
                catch { return false; }
                return true;
            }
            else return false;
        }

    }
}




