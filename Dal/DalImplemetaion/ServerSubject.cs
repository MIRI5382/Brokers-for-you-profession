
using Dal.DalApi;
using Dal.Do;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalImplemetaion
{
    public class ServerSubject:ISubjects
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
       
            public List<MySubject>? GetAll() =>
                db.MySubjects.Include(x=>x.Courses).ThenInclude(c=>c.Times)
                 .Include(x => x.Inscribeds)
                 .Include(x => x.GivenCourses)
               .ToList<MySubject>();

        public List<MySubject>? GetByName(string NameSubject) =>
                db.MySubjects.ToList<MySubject>().FindAll(x=>x.SubjectName == NameSubject);

 

        public int Post(MySubject t)
        {                                            
            var newt= db.MySubjects.Add(t);
            db.SaveChanges();
            db.MySubjects.ToList<MySubject>().ForEach(x => count++);
            return newt.Entity.CodeSubject;
        }

        public bool Put(MySubject t)
        {
            MySubject? my = db.MySubjects.ToList<MySubject>().Find(x => x.CodeSubject == t.CodeSubject);
            if (my != null)
            {
                my = t;
                return true;
            }
            else return false;
        }
       
        }
}




