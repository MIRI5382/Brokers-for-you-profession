using System;
using System.Collections.Generic;

namespace Dal.Do
{
    public partial class Course
    {
        public Course()
        {
            Times = new HashSet<Time>();
        }

        public int CodeCourse { get; set; }
        public int? CodeSubject { get; set; }
        public string? NameOfCourse { get; set; }
        public DateTime? DateOfCourseStart { get; set; }
        public DateTime? DateOfCourseEnd { get; set; }
        public int? NumQuality { get; set; }
        public string? SortCourse { get; set; }

        public virtual MySubject? CodeSubjectNavigation { get; set; }
        public virtual ICollection<Time> Times { get; set; }
    }
}
