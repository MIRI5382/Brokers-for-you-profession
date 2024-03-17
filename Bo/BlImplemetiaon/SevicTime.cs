using Bl.BlApi;
using Dal;
using Dal.DalApi;
using Dal.Do;

namespace Bl.BlImplemetiaon
{
    public class SevicTime : ITime
    {
        private DalManager _dManager;
        private IdTime _idtime;

        public SevicTime(DalManager d)
        {
            _dManager = d;
        }
        public BlTime ConvertToBl(Time time)
        {
            BlTime t = new BlTime();
            t.CodeTime = time.CodeTime;
            t.CodeCourse = time.CodeCourse;
            t.DaysOfCourse = time.DaysOfCourse;
            t.HourOfCourse = time.HourOfCourse;
            return t;
        }
        public Time ConvertToDal(BlTime time)
        {
            Time t = new Time();
            t.CodeTime = (int)time.CodeTime;
            t.CodeCourse = time.CodeCourse;
            t.DaysOfCourse = time.DaysOfCourse;
            t.HourOfCourse = time.HourOfCourse;
            return t;
        }
        public List<BlTime> ConvertTimeListToBl(List<Time> t)
        {
            List<BlTime> lst = new();
            foreach (Time t2 in t)
            {
                ConvertToBl(t2);
            }
            return lst;
        }

        public List<Time> ConvertTimeListToDal(List<BlTime> t)
        {
            List<Time> lst = new();
            foreach (BlTime t2 in t)
            {
                ConvertToDal(t2);
            }
            return lst;
        }

        public List<BlTime>? GetAll()
        {
            throw new NotImplementedException();
        }

        public int Post(BlTime t) =>
             _idtime.Post(ConvertToDal(t));

        public bool Put(BlTime item)=>      
            _idtime.Put(ConvertToDal(item));

        
    }
}
