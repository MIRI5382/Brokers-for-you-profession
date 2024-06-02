using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Bo
{
    public class BTast
    {
        public BTast() { }
        public int CodeTest { get; set; }
        public int CodeSubject { get; set; }
        public List<BQreshten>? TQrashten { get; set; } = new List<BQreshten>();

    }
}
