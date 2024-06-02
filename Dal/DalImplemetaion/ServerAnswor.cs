using Dal.DalApi;
using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalImplemetaion
{
    public class ServerAnswor : IdAnswor
    {
        private dbcontext _db;
        public ServerAnswor(dbcontext db) 
        { 
            _db = db; 
        }
        public List<Answor>? GetAll()=>
            _db.Answors.ToList<Answor>();      

        public int Post(Answor t)
        {
            var n = t;
            var r=_db.Answors.Add(n);
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex) { return -1; }
            return r.Entity.CodAnswor;
        }

        public bool Put(Answor t)
        {
            Answor? my = _db.Answors.ToList<Answor>().Find(x => x.CodAnswor == t.CodAnswor);
            if (my != null || t != null)
            {
                my.Aswor = t.Aswor;
                my.GredToAnswor = t.GredToAnswor;
                try { _db.SaveChanges(); 
                }catch (Exception ex) { return false; }  
                return true;
            }
            else return false;
        }
    }
}
