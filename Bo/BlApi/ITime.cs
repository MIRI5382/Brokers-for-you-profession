using Bl.Bo;
using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi
{
    public interface IbTime:IbCrod<BlTime>
    {
        bool DeleteOne(BlTime c);
        bool Delete(List<BlTime> t);
    }
}
