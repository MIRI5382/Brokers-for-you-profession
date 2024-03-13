using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Bo
{
    public class BCours

    {
        public BCours() { }
        public int? CodeCourse { get; set; }
        public int? CodeSubject { get; set; }
        public string? NameOfCourse { get; set; }
        public DateTime? DateOfCourseStart { get; set; }
        public DateTime? DateOfCourseEnd { get; set; }
        public int? NumQuality { get; set; }
        public string? SortCourse { get; set; }

       // public  List<MySubject>? CodeSubjectNavigation { get; set; }
       // public  List<Level>? NumQualityNavigation { get; set; }
       public  List<BlTime>? Times { get; set; }
    }

}
