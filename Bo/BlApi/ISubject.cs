
using Bl.Bo;

namespace Bl.BlApi
{
    public interface ISubject:ICrod<BSubject>
    {
        public List<BSubject>? GetByName(string NameSubject);
        public List<BSubject>? GetById(int code);
        public List<BSubject> GetBySivog(SivogSubject sivog);
        public List<BSubject>? GetSubjectClos();
        public List<BSubject>? GetNewSubject();
    }
}
