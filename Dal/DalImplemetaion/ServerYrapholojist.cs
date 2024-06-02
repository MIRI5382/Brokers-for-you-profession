using Dal.DalApi;
using Dal.Do;
using Microsoft.EntityFrameworkCore;

namespace Dal.DalImplemetaion
{
    public class ServerYrapholojist : IdYrapholojist
    {
        private dbcontext _db;
        public ServerYrapholojist(dbcontext db)
        {
            this._db = db;
        }
        public List<Yrapholojist>? GetAll()=>
            _db.Yrapholojists.Include(x=>x.ToMatches).ToList<Yrapholojist>();        

        public int Post(Yrapholojist t)
        {
            var n=t;
            try
            {
                _db.Yrapholojists.Add(n);
                _db.SaveChanges();
            }
            catch (Exception ex) { return 0; }
            return 1;
        }

        public bool Put(Yrapholojist t)
        {
            Yrapholojist? my = _db.Yrapholojists.ToList<Yrapholojist>().Find(x => x.TzYrapholojist == t.TzYrapholojist);
            if (my != null || t != null)
            {
                my.Sort = t.Sort;
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
