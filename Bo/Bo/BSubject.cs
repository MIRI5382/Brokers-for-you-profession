using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Bo
{
    public class BSubject
    {
        public BSubject() { }
        public int? CodeSubject { get; set; }
        public string? SubjectName { get; set; }
        public string? SortStudents { get; set; }
        public int? Price { get; set; }
        public string? Place { get; set; }
        public string? City { get; set; }
        public string? Tests { get; set; }
        public int? LengthOf { get; set; }
        public string? ContactMan { get; set; }
        public string? ContactManPhone { get; set; }
        public int? MaxNumInscribed { get; set; }
        public int? NumInscribed { get; set; }
        public string? Categury { get; set; }
        public List<BCours>? SCourses { get;  set; }=new List<BCours>();
        public List<BInscribed>? SInscribed { get;  set; }=new List<BInscribed>();
        public BlGivenCourse? SGivenCourse { get;  set; }

    }
}
