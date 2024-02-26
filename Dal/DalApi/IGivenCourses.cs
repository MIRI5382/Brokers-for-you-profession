using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi
{
    internal interface IGivenCourses: ICrud<GivenCourse>
    {
        public GivenCourse? GetById(string tz);
    }
}
