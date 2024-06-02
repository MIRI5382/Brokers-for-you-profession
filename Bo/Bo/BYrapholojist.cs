using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Bo
{
    public class BYrapholojist
    {
        public BYrapholojist() { }
        public string TzYrapholojist { get; set; } = null!;
        public string? Sort { get; set; }
        public  List<BToMatch> YToMatches { get; set; }=new List<BToMatch>();
    }
}
