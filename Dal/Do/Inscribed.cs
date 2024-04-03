using System;
using System.Collections.Generic;

namespace Dal.Do
{
    public partial class Inscribed
    {
        public string TzInscribed { get; set; } = null!;
        public string? InscribedName { get; set; }
        public int? Age { get; set; }
        public string? SortInscribed { get; set; }
        public int? InscribedSubjectCode { get; set; }
        public string? PhoneInscribed { get; set; }
        public string? Tests { get; set; }
        public string? FileToMatch { get; set; }

        public virtual MySubject? InscribedSubjectCodeNavigation { get; set; }
    }
}
