
using Dal.DalApi;
using Dal.Do;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Dal.DalImplemetaion
{
    public class ServerSubject : ISubjects
    {
        private dbcontext db;
        private int count = 0;


        public ServerSubject(dbcontext db)
        {
            this.db = db;
        }
        public bool Delete(MySubject t)
        {
            db.MySubjects.Remove(t);
            db.SaveChanges();
            return true;
        }

        public List<MySubject>? GetAll() {
            var x = db.MySubjects.ToList();
           var l = db.MySubjects//.Include(x => x.Courses).ThenInclude(c => c.Times)
              // .Include(x => x.Inscribeds)
              // .Include(x => x.GivenCourses)
             .ToList();
            if (l.Count()==0)
                return null;
            return l;
        }

        public List<MySubject>? GetByName(string NameSubject) =>
                db.MySubjects.ToList<MySubject>().FindAll(x => x.SubjectName == NameSubject);

        public List<MySubject>? GetById(int CodeSubject) =>
               db.MySubjects.ToList<MySubject>().FindAll(x => x.CodeSubject == CodeSubject);

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
            if (t != null && my != null)
            {
                if (t.SubjectName != null)
                    my.SubjectName = t.SubjectName;
                if (t.SortStudents != null)
                    my.CodeSubject = t.CodeSubject;
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
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}




