using System;
using System.Collections.Generic;

namespace Bl.Do
{
    public partial class GivenCourse
    {
        public string TzGivenCourses { get; set; } = null!;
        public string? NameOfGivenCourses { get; set; }
        public string? PhoneOfGivenCourses { get; set; }
        public int? CodeSubject { get; set; }

        public virtual MySubject? CodeSubjectNavigation { get; set; }
    }
}
