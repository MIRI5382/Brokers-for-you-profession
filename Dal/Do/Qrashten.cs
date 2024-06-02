using System;
using System.Collections.Generic;

namespace Dal.Do
{
    public partial class Qrashten
    {
        public Qrashten()
        {
            Answors = new HashSet<Answor>();
        }

        public int CodeQrashten { get; set; }
        public int? CodeTest { get; set; }
        public string? Qrashten1 { get; set; }

        public virtual Test? CodeTestNavigation { get; set; }
        public virtual ICollection<Answor> Answors { get; set; }
    }
}
