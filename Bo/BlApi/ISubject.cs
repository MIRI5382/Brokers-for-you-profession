using Bl.Bo;
using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi
{
    public interface IbSubject:IbCrod<BSubject>
    {
        public List<BSubject>? GetByName(string NameSubject);
        //public List<BSubject> GetBySivog(SivogSubject sivog);
        public List<BSubject>? GetSubjectClos();
        public List<BSubject>? GetNewSubject();
        public bool Delet(BSubject s);

    }
}
