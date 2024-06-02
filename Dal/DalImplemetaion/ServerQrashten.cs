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
    public class ServerQrashten : IDQweshten
    {
        private dbcontext _db;
        public ServerQrashten(dbcontext db) 
        { 
            this._db = db; 
        }
        public List<Qrashten>? GetAll()=>
            _db.Qrashtens.Include(q=>q.Answors).ToList<Qrashten>();

        public int Post(Qrashten t)
        {
            var n = t;
           var r= _db.Qrashtens.Add(n);
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex) { return -1; }
            return r.Entity.CodeQrashten;
        }

        public bool Put(Qrashten t)
        {
            Qrashten? my = _db.Qrashtens.ToList<Qrashten>().Find(x => x.CodeQrashten == t.CodeQrashten);
            if (my != null || t != null)
            {
                my.CodeTest = t.CodeTest;
                my.Qrashten1 = t.Qrashten1;
                try { _db.SaveChanges();
                }catch (Exception ex) { return false; } 
                return true;
            }
            else return false;
        }
    }
}
