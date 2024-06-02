using Dal.DalApi;
using Dal.Do;
using Microsoft.EntityFrameworkCore;

namespace Dal.DalImplemetaion
{
    public class ServesToMatch : IdToMatch
    {

        private dbcontext _db;
        public ServesToMatch(dbcontext db)
        {
            this._db = db;
        }

        public List<ToMatch>? GetAll() =>
            _db.ToMatches.ToList<ToMatch>();

        
        public int Post(ToMatch t)
        {
            var r = _db.ToMatches.Add(t);
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex) { return -1; }
            return r.Entity.CodToMatch;
        }

        public bool Put(ToMatch t)
        {
            ToMatch? my = _db.ToMatches.ToList<ToMatch>().Find(x => x.CodToMatch == t.CodToMatch);
            if (my != null || t != null)
            {
                my.FileToMatch = t.FileToMatch;
                my.WoritMatch = t.WoritMatch;
                my.Sort = t.Sort;
                my.TzYrapholojist = t.TzYrapholojist;
                try
                {
                    _db.SaveChanges();
                }
                catch (Exception ex) { return false; }
                return true;
            }
            else return false;
        }
    }
}
