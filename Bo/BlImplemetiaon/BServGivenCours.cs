using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlImplemetiaon
{
    public class BServGivenCours
    {

        public BServGivenCours() { }
        public BlGivenCourse ConvertToBl(GivenCourse givenCourse)
        {
            if (givenCourse == null) return null;
             BlGivenCourse bgiven = new BlGivenCourse();
            bgiven.CodeSubject = givenCourse.CodeSubject;
            bgiven.PhoneOfGivenCourses= givenCourse.PhoneOfGivenCourses;
            bgiven.NameOfGivenCourses=givenCourse.NameOfGivenCourses;
            bgiven.TzGivenCourses = givenCourse.TzGivenCourses;
            return bgiven;
        }
        public GivenCourse ConvertToDal(BlGivenCourse givenCourse)
        {
            GivenCourse bgiven = new GivenCourse();
            bgiven.CodeSubject = givenCourse.CodeSubject;
            bgiven.PhoneOfGivenCourses = givenCourse.PhoneOfGivenCourses;
            bgiven.NameOfGivenCourses = givenCourse.NameOfGivenCourses;
            bgiven.TzGivenCourses = givenCourse.TzGivenCourses;
            return bgiven;
        }
    }
}
