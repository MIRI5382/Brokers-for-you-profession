using System;
using System.Collections.Generic;

namespace Dal.Do
{
    public partial class MySubject
    {
        public MySubject()
        {
            Courses = new HashSet<Course>();
            GivenCourses = new HashSet<GivenCourse>();
            Inscribeds = new HashSet<Inscribed>();
        }

        public int CodeSubject { get; set; }
        public string? SubjectName { get; set; }
        public string? SortStudents { get; set; }
        public int? Price { get; set; }
        public string? Place { get; set; }
        public string? City { get; set; }
        public string? Tests { get; set; }
        public float? LengthOf { get; set; }
        public string? ContactMan { get; set; }
        public string? ContactManPhone { get; set; }
        public int? MaxNumInscribed { get; set; }
        public int? NumInscribed { get; set; }
        public string? Categury { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<GivenCourse> GivenCourses { get; set; }
        public virtual ICollection<Inscribed> Inscribeds { get; set; }
    }
}
