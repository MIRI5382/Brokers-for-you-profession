
using Dal.DalApi;
using Dal.Do;

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
            return true;
        }

        public List<Inscribed>? GetAll() =>
            db.Inscribeds.ToList<Inscribed>();

        public Inscribed? GetById(string t) =>
            db.Inscribeds.ToList<Inscribed>().Find(x => x.TzInscribed == t);

        public bool Put(Inscribed t)
        {
            Inscribed? my = db.Inscribeds.ToList<Inscribed>().Find(x => x.TzInscribed == t.TzInscribed);
            if (my != null||t!=null)
            {
                if (my.InscribedName != null)
                    my.InscribedName = t.InscribedName;
                if (my.Age != null)
                    my.Age = t.Age;
                if (my.SortInscribed != null)
                    my.SortInscribed = t.SortInscribed;
                if (my.InscribedSubjectCode != null)
                    my.InscribedSubjectCode = t.InscribedSubjectCode;
                if (my.PhoneInscribed != null)
                    my.PhoneInscribed = t.PhoneInscribed;
                if (my.Tests != null)
                    my.Tests = t.Tests;
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
