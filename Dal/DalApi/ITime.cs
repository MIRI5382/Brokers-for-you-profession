using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi
{
    public interface IdTime:IdCrud<Time>
    {
        bool Delete(ICollection<Time> times);
        public int Post(Time t);
        bool DeleteOne(Time t);
    }
}
