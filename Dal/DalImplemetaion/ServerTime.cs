using Dal.DalApi;
using Dal.Do;

namespace Dal.DalImplemetaion
{
    public class ServerTime : IdTime
    {
        private dbcontext _db;

        public ServerTime(dbcontext db)
        {
            _db = db;
        }

        public bool Delete(ICollection<Time> t)
        {
            try
            {
                foreach (Time t2 in t)
                {
                    DeleteOne(t2);
                }
            }
            catch (Exception ex) { return false; }
            return true;
        }
        public bool DeleteOne(Time t)
        {
            var d = _db.Times.FirstOrDefault(z => z.CodeTime == z.CodeTime);
            if (d == null)
            {
                try
                {
                    _db.Times.Remove(d);
                    _db.SaveChanges();
                }
                catch (Exception ex) { return false; }
                return true;
            }
            return false;
        }

        public List<Time>? GetAll()
        {
            throw new NotImplementedException();
        }

        public int Post(Time t)
        {
            try
            {
                _db.Times.Add(t);
                /* List<Course>? list = _IDcourse.GetAll();
                 Course? mycours = list?.FirstOrDefault(x => x.CodeCourse == t.CodeCourse);
                 mycours?.Times.Add(t);*/
                _db.SaveChanges();
            }
            catch (Exception ex) { return 0; }
            return t.CodeTime;
        }


        public bool Put(Time t)
        {
            Time? my = _db.Times.ToList<Time>().Find(x => x.CodeTime == t.CodeTime);
            if (t != null || my != null)
            {
                if (t.HourOfCourse != null)
                    my.HourOfCourse = t.HourOfCourse;
                if (t.DaysOfCourse != null)
                    my.DaysOfCourse = t.DaysOfCourse;
                _db.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
