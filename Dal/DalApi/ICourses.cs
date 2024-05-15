
using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi
{
    public interface IdCourses:IdCrud<Course>
    {
        bool Delete(ICollection<Course> courses);
        public Course? GetById(int CodeCourse);
        bool DeleteOne(Course t);



    }
}
