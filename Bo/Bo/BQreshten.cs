using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Bo
{
    public class BQreshten
    {
        public BQreshten() { }
        public int CodeQrashten { get; set; }
        public int? CodeTest { get; set; }
        public string? Qrashten1 { get; set; }
        public List<BAnswor>? QAnswors { get; set; } = new List<BAnswor>();


    }
}
