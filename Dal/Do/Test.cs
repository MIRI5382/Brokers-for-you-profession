using System;
using System.Collections.Generic;

namespace Dal.Do
{
    public partial class Test
    {
        public Test()
        {
            Qrashtens = new HashSet<Qrashten>();
        }

        public int CodeTest { get; set; }
        public int CodeSubject { get; set; }
        public int? MoveGred { get; set; }

        public virtual MySubject CodeSubjectNavigation { get; set; } = null!;
        public virtual ICollection<Qrashten> Qrashtens { get; set; }
    }
}
