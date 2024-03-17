
using Dal.DalApi;
using Dal.Do;
using Microsoft.EntityFrameworkCore;

namespace Dal.DalImplemetaion
{
    public class ServerSubject : ISubjects
    {
        private dbcontext db;
        private int count = 0;
        private InscribedServer _InscribedServer;
        private ServerCourses _ServerCourses;
        private ServerCurrsesManagers _ServerCurrsesManagers;

        public ServerSubject(dbcontext db,InscribedServer InscribedServer,ServerCourses ServerCourses, ServerCurrsesManagers ServerCurrsesManagers)
        {
            this.db = db;
            _InscribedServer= InscribedServer;
            _ServerCourses= ServerCourses;
            _ServerCurrsesManagers= ServerCurrsesManagers;
        }
        public bool Delete(MySubject t)
        {
            db.MySubjects.Remove(t);
            db.SaveChanges();
            return true;
        }

        public List<MySubject>? GetAll() =>
            db.MySubjects.Include(x => x.Courses).ThenInclude(c => c.Times)
             .Include(x => x.Inscribeds)
             .Include(x => x.GivenCourses)
           .ToList();

        public List<MySubject>? GetByName(string NameSubject) =>
                db.MySubjects.ToList<MySubject>().FindAll(x => x.SubjectName == NameSubject);



        public int Post(MySubject t)
        {
            var newt = db.MySubjects.Add(t);
            db.SaveChanges();
            db.MySubjects.ToList<MySubject>().ForEach(x => count++);
            return newt.Entity.CodeSubject;
        }

        public bool Put(MySubject t)
        {
            MySubject? my = db.MySubjects.ToList<MySubject>().Find(x => x.CodeSubject == t.CodeSubject);
            if (my != null||t!=null)
            {
                if (t.SubjectName != null)
                    my.SubjectName = t.SubjectName;
                if (t.SortStudents != null)
                    my.SortStudents = t.SortStudents;
                if (t.Price != null)
                    my.Price = t.Price;
                if (t.Place != null)
                    my.Place = t.Place;
                if (t.City != null)
                    my.City = t.City;
                if (t.Tests != null)
                    my.Tests = t.Tests;
                if (t.LengthOf != null)
                    my.LengthOf = t.LengthOf;
                if (t.ContactMan != null)
                    my.ContactMan = t.ContactMan;
                if (t.ContactManPhone != null)
                    my.ContactManPhone = t.ContactManPhone;
                if (t.MaxNumInscribed != null)
                    my.MaxNumInscribed = t.MaxNumInscribed;
                if (t.NumInscribed != null)
                    my.NumInscribed = t.NumInscribed;
                if (t.Categury != null)
                    my.Categury = t.Categury;
                if (t.GivenCourses != null)
                    my.GivenCourses = t.GivenCourses;
                if (t.Inscribeds != null)
                    _InscribedServer.Put(((Inscribed)t.Inscribeds));
                if (t.Courses != null)
                    _ServerCourses.Put(((Course)t.Courses));
                if (t.GivenCourses != null)
                    _ServerCurrsesManagers.Put(((GivenCourse)t.GivenCourses));
                db.SaveChanges();
                return true;
            }
            else return false;
        }

    }
}




