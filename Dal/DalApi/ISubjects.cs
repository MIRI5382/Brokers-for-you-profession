
using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi
{
    public interface IdSubjects:IdCrud<MySubject>
    {
        public List<MySubject>? GetByName(string  NameSubject);
        public bool Delete(MySubject s);

    }
}
