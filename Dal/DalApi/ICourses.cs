
using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi
{
    public interface ICourses:ICrud<Course>
    {
        public Course? GetById(int CodeCourse);
        

    }
}
