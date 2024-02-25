using Bl.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi
{
    public interface ISubjects:ICrud<MySubject>
    {
        public List<MySubject>? GetByName(string  NameSubject);

    }
}
