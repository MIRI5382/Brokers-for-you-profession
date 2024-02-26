using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi
{
    public interface ISubject:ICrod<MySubject>
    {
        public List<MySubject>? GetByName(string NameSubject);
        public List<MySubject> GetBySivog(MySubject sivog);
    }
}
