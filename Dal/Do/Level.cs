using System;
using System.Collections.Generic;

namespace Dal.Do
{
    public partial class Level
    {
        public Level()
        {
            Courses = new HashSet<Course>();
        }

        public int Num { get; set; }
        public string? Descriptions { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
