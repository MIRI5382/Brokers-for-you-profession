
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
    public class ServerCurrsesManagers : IGivenCourses
    {
        private dbcontext db;
        private int count=0;
        public ServerCurrsesManagers(dbcontext db)
        {
            this.db = db;
        }
        public bool Delete(GivenCourse t)
        {
           db.GivenCourses.Remove(t);
           return true;
        }
      
        public List<GivenCourse>? GetAll()=>
            db.GivenCourses.ToList< GivenCourse>();       

        public GivenCourse? GetById(string t)=>
            db.GivenCourses.ToList<GivenCourse>().Find(x=>x.TzGivenCourses==t);

        public bool Put(GivenCourse t)
        {
          GivenCourse? my = db.GivenCourses.ToList<GivenCourse>().Find(x => x.TzGivenCourses == t.TzGivenCourses);
          if (my != null)
            {
                my = t;
                return true; 
            }           
           else return false;
        }

        public int Post(GivenCourse t)
        {
            db.GivenCourses.Add(t);
            db.GivenCourses.ToList<GivenCourse>().ForEach(x=>count++);
            return count;
        }
    }
}
