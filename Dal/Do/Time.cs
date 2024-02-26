using System;
using System.Collections.Generic;

namespace Dal.Do
{
    public partial class Time
    {
        public int CodeTime { get; set; }
        public int? CodeCourse { get; set; }
        public int? HourOfCourse { get; set; }
        public string? DaysOfCourse { get; set; }

        public virtual Course? CodeCourseNavigation { get; set; }
    }
}
