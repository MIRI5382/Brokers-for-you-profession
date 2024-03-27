using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi
{
    public interface IdInscribed:IdCrud<Inscribed>
    {
        public Inscribed? GetById(string tz);
        bool Delete(ICollection<Inscribed> i);
    }
}
