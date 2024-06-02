using Bl.Bo;
using Dal.Do;

namespace Bl.BlApi
{
    public interface IbCours : IbCrod<BCours>
    {
        bool DeleteOne(BCours c);
        bool Delete(List<BCours> t);




    }
}
