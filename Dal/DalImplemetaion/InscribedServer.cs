
using Dal.DalApi;
using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalImplemetaion
{
    public class InscribedServer : IInscribed
    {
            private dbcontext db;
            private int count = 0;
            public InscribedServer(dbcontext db)
            {
                this.db = db;
            }
            public bool Delete(Inscribed t)
            {
                db.Inscribeds.Remove(t);
                db.SaveChanges();
                return true;
            }

            public List<Inscribed>? GetAll() =>
                db.Inscribeds.ToList<Inscribed>();

            public Inscribed? GetById(string t) =>
                db.Inscribeds.ToList<Inscribed>().Find(x => x.TzInscribed == t);

            public bool Put(Inscribed t)
            {
            Inscribed? my = db.Inscribeds.ToList<Inscribed>().Find(x => x.TzInscribed == t.TzInscribed);
                if (my != null)
                {
                    my = t;
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }

            public int Post(Inscribed t)
            {
                db.Inscribeds.Add(t);
                db.SaveChanges();
                db.Inscribeds.ToList<Inscribed>().ForEach(x => count++);
                return count;
            }

}

}
