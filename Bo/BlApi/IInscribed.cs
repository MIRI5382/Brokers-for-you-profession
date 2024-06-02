using Bl.Bo;
using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi
{
    public interface IBInscribed : IbCrod<BInscribed>
    {
        bool Delete(List<BInscribed> item);
    }
}
