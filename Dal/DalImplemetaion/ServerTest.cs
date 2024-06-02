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
    public class ServerTest : IdTest
    {
        private dbcontext _db;
        public ServerTest(dbcontext db) {
            this._db = db; 
        }
        public List<Test>? GetAll() =>
            _db.Tests.Include(x=>x.Qrashtens).ThenInclude(x => x.Answors).ToList<Test>();

        public int Post(Test t)
        {
            var n = t;            
            var r=_db.Tests.Add(n);
            try { _db.SaveChanges();
            }catch(Exception ex) {return 0;}
            return r.Entity.CodeTest;
        }

        public bool Put(Test t)
        {
            Test? my = _db.Tests.ToList<Test>().Find(x => x.CodeTest == t.CodeTest);
            if (my != null || t != null)
            {
                my.CodeSubject = t.CodeSubject;
                try { _db.SaveChanges(); 
                }catch (Exception ex) { return false;}
                return true;
            }
            else return false;
        }
    }
}
