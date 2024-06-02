using Bl.BlApi;
using Bl.Bo;
using Dal;
using Dal.DalApi;
using Dal.Do;

namespace Bl.BlImplemetiaon
{
    public class ServicBToMatch : IbToMatch
    {
        private IdToMatch _dToMatch;
        public ServicBToMatch(DalManager dToMatch)
        {
            _dToMatch = dToMatch.SIdToMatch;
        }
        public BToMatch ConvertToBl(ToMatch t)
        {
            BToMatch m = new BToMatch();
            m.CodToMatch = t.CodToMatch;
            m.FileToMatch = t.FileToMatch;
            m.WoritMatch = t.WoritMatch;
            m.Sort = t.Sort;
            m.TzYrapholojist = t.TzYrapholojist;
            return m;
        }
        public ToMatch ConvertToDal(BToMatch t)
        {
            ToMatch m = new ToMatch();
            m.CodToMatch = t.CodToMatch;
            m.FileToMatch = t.FileToMatch;
            m.WoritMatch = t.WoritMatch;
            m.Sort = t.Sort;
            m.TzYrapholojist = t.TzYrapholojist;
            return m;
        }
        public List<BToMatch> ConvertTimeListToBl(List<ToMatch> t)
        {
            List<BToMatch> lst = new();
            foreach (ToMatch t2 in t)
            {
                lst.Add(ConvertToBl(t2));
            }
            return lst;
        }

        public List<ToMatch> ConvertTimeListToDal(List<BToMatch> t)
        {
            List<ToMatch> lst = new();
            foreach (BToMatch t2 in t)
            {
                ConvertToDal(t2);
            }
            return lst;
        }
        public List<BToMatch>? GetAll() =>
            ConvertTimeListToBl(_dToMatch.GetAll());

        public int Post(BToMatch item)=>
           _dToMatch.Post(ConvertToDal(item));  

        public bool Put(BToMatch item)=>
           _dToMatch.Put(ConvertToDal(item));
    }
}
