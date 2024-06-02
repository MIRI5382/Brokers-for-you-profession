
using Dal.DalApi;
using Dal.Do;
using Microsoft.EntityFrameworkCore;

namespace Dal.DalImplemetaion
{
    public class InscribedServer : IdInscribed
    {
        private dbcontext db;
        private int count = 0;
        public InscribedServer(dbcontext db)
        {
            this.db = db;
        }
        public bool Delete(ICollection<Inscribed> i)
        {
            foreach (Inscribed i2 in i)
            {
                DeleteOne(i2);
            }
            db.SaveChanges();
            return true;
        }
        private bool DeleteOne(Inscribed i)
        {
            var n = db.Inscribeds.FirstOrDefault(x => x.TzInscribed == i.TzInscribed);
            if (n != null)
            {
                try
                {
                    db.Inscribeds.Remove(n);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e) { return false; }
            }
            return false;
        }
        public List<Inscribed>? GetAll() =>
            db.Inscribeds.Include(x => x.ToMatches).ToList<Inscribed>();

        public Inscribed? GetById(string t) =>
            db.Inscribeds.ToList<Inscribed>().Find(x => x.TzInscribed == t);

        public bool Put(Inscribed t)
        {
            Inscribed? my = db.Inscribeds.ToList<Inscribed>().Find(x => x.TzInscribed == t.TzInscribed);
            if (my != null || t != null)
            {
                my.InscribedName = t.InscribedName;
                my.Age = t.Age;
                my.SortInscribed = t.SortInscribed;
                my.InscribedSubjectCode = t.InscribedSubjectCode;
                my.PhoneInscribed = t.PhoneInscribed;
                my.Tests = t.Tests;
                db.SaveChanges();
                return true;
            }
            else return false;
        }

        public int Post(Inscribed t)
        {
            var n = t;
            db.Inscribeds.Add(n);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex) { return -1; }
            db.Inscribeds.ToList<Inscribed>().ForEach(x => count++);
            return count;
        }

    }

}
