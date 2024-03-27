using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi
{
    public interface IdGivenCourses: IdCrud<GivenCourse>
    {
        public GivenCourse? GetById(string tz);
        bool Delete(ICollection<GivenCourse> g);

    }
}
