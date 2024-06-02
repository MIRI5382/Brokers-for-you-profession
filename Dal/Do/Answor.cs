using System;
using System.Collections.Generic;

namespace Dal.Do
{
    public partial class Answor
    {
        public int CodAnswor { get; set; }
        public string? Aswor { get; set; }
        public double? GredToAnswor { get; set; }
        public int? CodQreshten { get; set; }

        public virtual Qrashten? CodQreshtenNavigation { get; set; }
    }
}
