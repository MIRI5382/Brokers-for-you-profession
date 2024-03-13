using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlImplemetiaon
{
    public class SevicTime
    {

        public SevicTime() { }
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

    }
}
